
using System.Dynamic;
using System.Text.Json;

namespace _4EPlatForm.Infrastrucure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;
        private IDbContextTransaction _transaction;
        public Guid _loggedInUserId;
        public UnitOfWork(AppDBContext context, IHttpContextAccessor _httpContextAccessor)
        {
            _context = context;
            _loggedInUserId = LoggedInUserProvider.GetLoggedInUserId(_httpContextAccessor);
            repoistories = new Hashtable();

        }
        Hashtable repoistories;
        public IGRepository<TEntity> Repository<TEntity>() where TEntity : AuditEntity<Guid>
        {
            var key = typeof(TEntity).Name;
            if (!repoistories.ContainsKey(key))
            {
                var repository = new GRepository<TEntity>(_context);
                repoistories.Add(key, repository);
            }
            return repoistories[key] as IGRepository<TEntity>;


        }
        public IGRepository<TEntity> LK_Repository<TEntity>() where TEntity : AuditEntity<int>
        {
            var key = typeof(TEntity).Name;
            if (!repoistories.ContainsKey(key))
            {
                var repository = new GRepository<TEntity>(_context);
                repoistories.Add(key, repository);
            }
            return repoistories[key] as IGRepository<TEntity>;


        }
        #region Transaction
        public void BeginTransaction() => _transaction = _context.Database.BeginTransaction();
        public async Task BeginTransactionAsync() => _transaction = await _context.Database.BeginTransactionAsync();
        public void Commit() => _transaction.Commit();
        public async Task CommitAsync() => await _transaction.CommitAsync();
        public void Rollback() => _transaction?.Rollback();
        public async Task RollbackAsync() => await _transaction.RollbackAsync();

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
        public async Task DisposeAsync()
        {
            await _transaction.DisposeAsync();
            await _context.DisposeAsync();
        }
        #endregion


        #region SaveChanges
        public void SaveChanges()
        {
            try
            {
                var tablesName = new List<string>() { "Session", "SessionNote", "SessionAssignee", "JudgementGround", "CauseStage" };

                var entries = _context.ChangeTracker.Entries()
                       .Where(e => (e.Entity is BaseEntity<Guid>) && (
                         e.State == EntityState.Added
                                  || e.State == EntityState.Modified)).ToList();

                foreach (var entityEntry in entries)
                {
                      if (entityEntry.State == EntityState.Modified)
                        {
                            ((AuditEntity<Guid>)entityEntry.Entity).UpdatedOn = DateTime.Now;
                            ((AuditEntity<Guid>)entityEntry.Entity).UpdatedBy = _loggedInUserId;
                            entityEntry.Property("CreatedOn").IsModified = false;
                            entityEntry.Property("CreatedBy").IsModified = false;
                        //History
                        var tableName = entityEntry.Entity.GetType().Name.Replace("Proxy", "");
                        if (tablesName.Any(name => tableName == name))
                        {

                            if (((AuditEntity<Guid>)entityEntry.Entity).State == 0)
                            {
                                var changes = entityEntry.Properties.Select(p => new
                                {
                                    Property = p.Metadata.Name,
                                    OriginalValue = p.OriginalValue,
                                    CurrentValue = p.CurrentValue
                                });
                                dynamic OriginalObj = new ExpandoObject();
                                dynamic CurrentObj = new ExpandoObject();
                                foreach (var change in changes)
                                {
                                    if (change.OriginalValue is not null && change.CurrentValue is not null)
                                    {
                                        if (change.OriginalValue.ToString() != change.CurrentValue.ToString())
                                        {
                                            AddProperty(OriginalObj, change.Property, change.OriginalValue);
                                            AddProperty(CurrentObj, change.Property, change.CurrentValue);
                                        }
                                    }
                                }

                                string jsonStringOriginal = JsonSerializer.Serialize(OriginalObj);
                                string jsonStringCurrent = JsonSerializer.Serialize(CurrentObj);
                                Guid causeStageId = default(Guid);

                                if (entityEntry.Entity.GetType().GetProperty("CauseStageId") != null)
                                {
                                    causeStageId = (Guid)entityEntry.Entity.GetType()
                                        .GetProperty("CauseStageId")
                                        ?.GetValue(entityEntry.Entity);
                                }

                                _context.CauseHistorys.AddAsync(new _4EPlatform.Domain.Models.CasuseModels.CauseHistory
                                {
                                    TableName = tableName,
                                    RecordId = Guid.Parse(entityEntry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.CurrentValue.ToString()),
                                    Action = "update",
                                    CauseStageId = tableName != "CauseStage" ? causeStageId : (Guid)entityEntry.Entity.GetType().GetProperty("Id")?.GetValue(entityEntry.Entity),
                                    OldValue = jsonStringOriginal,
                                    NewValue = jsonStringCurrent,
                                    CreatedBy = _loggedInUserId,
                                    CreatedOn = DateTime.Now
                                });
                            }
                            else
                            {
                                var changes = entityEntry.Properties.Select(p => new
                                {
                                    Property = p.Metadata.Name,
                                    OriginalValue = p.OriginalValue,
                                });
                                dynamic OriginalObj = new ExpandoObject();
                                foreach (var change in changes)
                                {
                                    if (change.OriginalValue is not null)
                                    {
                                        AddProperty(OriginalObj, change.Property, change.OriginalValue);
                                    }
                                }

                                string jsonStringOriginal = JsonSerializer.Serialize(OriginalObj);
                                Guid causeStageId = default(Guid);
                                if (entityEntry.Entity.GetType().GetProperty("CauseStageId") != null)
                                {
                                    causeStageId = (Guid)entityEntry.Entity.GetType()
                                        .GetProperty("CauseStageId")
                                        ?.GetValue(entityEntry.Entity);
                                }

                                _context.CauseHistorys.AddAsync(new _4EPlatform.Domain.Models.CasuseModels.CauseHistory
                                {
                                    TableName = tableName,
                                    RecordId = Guid.Parse(entityEntry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.CurrentValue.ToString()),
                                    Action = "Delete",
                                    CauseStageId = tableName != "CauseStage" ? causeStageId : (Guid)entityEntry.Entity.GetType().GetProperty("Id")?.GetValue(entityEntry.Entity),
                                    OldValue = jsonStringOriginal,
                                    CreatedBy = _loggedInUserId,
                                    CreatedOn = DateTime.Now
                                });
                            }
                        }

                      }

                        if (entityEntry.State == EntityState.Added)
                        {
                            ((AuditEntity<Guid>)entityEntry.Entity).CreatedOn = DateTime.Now;
                            ((AuditEntity<Guid>)entityEntry.Entity).CreatedBy = _loggedInUserId;

                        //History
                        if (tablesName.Any(name => entityEntry.Entity.GetType().Name == name))
                        {

                            var changes = entityEntry.Properties.Select(p => new
                            {
                                Property = p.Metadata.Name,
                                CurrentValue = p.CurrentValue
                            });
                            dynamic CurrentObj = new ExpandoObject();
                            foreach (var change in changes)
                            {
                                if (change.CurrentValue is not null)
                                {
                                    AddProperty(CurrentObj, change.Property, change.CurrentValue);
                                }
                            }

                            string jsonStringCurrent = JsonSerializer.Serialize(CurrentObj);
                            Guid causeStageId = default(Guid);
                            if (entityEntry.Entity.GetType().GetProperty("CauseStageId") != null)
                            {
                                causeStageId = (Guid)entityEntry.Entity.GetType()
                                    .GetProperty("CauseStageId")
                                    ?.GetValue(entityEntry.Entity);
                            }


                            _context.CauseHistorys.AddAsync(new _4EPlatform.Domain.Models.CasuseModels.CauseHistory
                            {
                                TableName = entityEntry.Entity.GetType().Name,
                                RecordId = Guid.Parse(entityEntry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.CurrentValue.ToString()),
                                Action = "Insert",
                                CauseStageId = entityEntry.Entity.GetType().Name != "CauseStage" ? causeStageId : (Guid)entityEntry.Entity.GetType().GetProperty("Id")?.GetValue(entityEntry.Entity),
                                NewValue = jsonStringCurrent,
                                CreatedBy = _loggedInUserId,
                                CreatedOn = DateTime.Now
                            });
                        }
                        }
                    
                }
                if (_context.Database.CurrentTransaction == null)
                    BeginTransaction();
                _context.SaveChanges();
                //Commit();
            }
            catch (Exception)
            {
                Rollback();

            }

        }

        public async Task SaveChangesAsync()
        {
            try
            {
                var tablesName = new List<string>() { "Session", "SessionNote", "SessionAssignee", "JudgementGround",  "CauseStage" };

                var entries = _context.ChangeTracker.Entries()
                    .Where(e => (e.Entity is BaseEntity<Guid>) && (
                         e.State == EntityState.Added
                         || e.State == EntityState.Modified)).ToList();

                foreach (var entityEntry in entries)
                {
                    
                        if (entityEntry.State == EntityState.Modified)
                        {
                            ((AuditEntity<Guid>)entityEntry.Entity).UpdatedOn = DateTime.Now;
                            ((AuditEntity<Guid>)entityEntry.Entity).UpdatedBy = _loggedInUserId;
                            entityEntry.Property("CreatedOn").IsModified = false;
                            entityEntry.Property("CreatedBy").IsModified = false;
                        //History

                       var tableName=  entityEntry.Entity.GetType().Name.Replace("Proxy","");
                        if (tablesName.Any(name => tableName == name))
                        {

                            if (((AuditEntity<Guid>)entityEntry.Entity).State == 0)
                            {
                                var changes = entityEntry.Properties.Select(p => new
                                {
                                    Property = p.Metadata.Name,
                                    OriginalValue = p.OriginalValue,
                                    CurrentValue = p.CurrentValue
                                });
                                dynamic OriginalObj = new ExpandoObject();
                                dynamic CurrentObj = new ExpandoObject();
                                foreach (var change in changes)
                                {
                                    if (change.OriginalValue is not null && change.CurrentValue is not null)
                                    {
                                        if (change.OriginalValue.ToString() != change.CurrentValue.ToString())
                                        {
                                            AddProperty(OriginalObj, change.Property, change.OriginalValue);
                                            AddProperty(CurrentObj, change.Property, change.CurrentValue);
                                        }
                                    }
                                }

                                string jsonStringOriginal = JsonSerializer.Serialize(OriginalObj);
                                string jsonStringCurrent = JsonSerializer.Serialize(CurrentObj);
                                // Guid causeStageId = GetPropertyValueAsGuid(entityEntry, "CauseStageId");
                                Guid causeStageId = default(Guid);

                                if (entityEntry.Entity.GetType().GetProperty("CauseStageId") != null)
                                {
                                    causeStageId = (Guid)entityEntry.Entity.GetType()
                                        .GetProperty("CauseStageId")
                                        ?.GetValue(entityEntry.Entity);
                                }

                                await _context.CauseHistorys.AddAsync(new _4EPlatform.Domain.Models.CasuseModels.CauseHistory
                                {
                                    TableName = tableName,
                                    RecordId = Guid.Parse(entityEntry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.CurrentValue.ToString()),
                                    Action = "update",
                                    CauseStageId = tableName != "CauseStage" ? causeStageId : (Guid)entityEntry.Entity.GetType().GetProperty("Id")?.GetValue(entityEntry.Entity),
                                    OldValue = jsonStringOriginal,
                                    NewValue = jsonStringCurrent,
                                    CreatedBy = _loggedInUserId,
                                    CreatedOn = DateTime.Now
                                });
                            }
                            else
                            {
                                var changes = entityEntry.Properties.Select(p => new
                                {
                                    Property = p.Metadata.Name,
                                    OriginalValue = p.OriginalValue,
                                });
                                dynamic OriginalObj = new ExpandoObject();
                                foreach (var change in changes)
                                {
                                    if (change.OriginalValue is not null)
                                    {
                                        AddProperty(OriginalObj, change.Property, change.OriginalValue);
                                    }
                                }

                                string jsonStringOriginal = JsonSerializer.Serialize(OriginalObj);
                                Guid causeStageId = default(Guid);
                                if (entityEntry.Entity.GetType().GetProperty("CauseStageId") != null)
                                {
                                    causeStageId = (Guid)entityEntry.Entity.GetType()
                                        .GetProperty("CauseStageId")
                                        ?.GetValue(entityEntry.Entity);
                                }

                                await _context.CauseHistorys.AddAsync(new _4EPlatform.Domain.Models.CasuseModels.CauseHistory
                                {
                                    TableName = tableName,
                                    RecordId = Guid.Parse(entityEntry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.CurrentValue.ToString()),
                                    Action = "Delete",
                                    CauseStageId = tableName != "CauseStage" ? causeStageId : (Guid)entityEntry.Entity.GetType().GetProperty("Id")?.GetValue(entityEntry.Entity),
                                    OldValue = jsonStringOriginal,
                                    CreatedBy = _loggedInUserId,
                                    CreatedOn = DateTime.Now
                                });
                            }
                        }

                        }

                        if (entityEntry.State == EntityState.Added)
                        {
                            ((AuditEntity<Guid>)entityEntry.Entity).CreatedOn = DateTime.Now;
                            ((AuditEntity<Guid>)entityEntry.Entity).CreatedBy = _loggedInUserId;

                        if (tablesName.Any(name => entityEntry.Entity.GetType().Name == name))
                        {
                            //History
                            var changes = entityEntry.Properties.Select(p => new
                            {
                                Property = p.Metadata.Name,
                                CurrentValue = p.CurrentValue
                            });
                            dynamic CurrentObj = new ExpandoObject();
                            foreach (var change in changes)
                            {
                                if (change.CurrentValue is not null)
                                {
                                    AddProperty(CurrentObj, change.Property, change.CurrentValue);
                                }
                            }

                            string jsonStringCurrent = JsonSerializer.Serialize(CurrentObj);
                            Guid causeStageId = default(Guid);
                            if (entityEntry.Entity.GetType().GetProperty("CauseStageId") != null)
                            {
                                causeStageId = (Guid)entityEntry.Entity.GetType()
                                    .GetProperty("CauseStageId")
                                    ?.GetValue(entityEntry.Entity);
                            }


                            await _context.CauseHistorys.AddAsync(new _4EPlatform.Domain.Models.CasuseModels.CauseHistory
                            {
                                TableName = entityEntry.Entity.GetType().Name,
                                RecordId = Guid.Parse(entityEntry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.CurrentValue.ToString()),
                                Action = "Insert",
                                CauseStageId = entityEntry.Entity.GetType().Name != "CauseStage" ? causeStageId : (Guid)entityEntry.Entity.GetType().GetProperty("Id")?.GetValue(entityEntry.Entity),
                                NewValue = jsonStringCurrent,
                                CreatedBy = _loggedInUserId,
                                CreatedOn = DateTime.Now
                            });
                        }
                    }

                }
                if (_context.Database.CurrentTransaction == null)
                    await BeginTransactionAsync();
                await _context.SaveChangesAsync();
                //Commit();
            }
            catch (Exception ex)
            {
                await RollbackAsync();

            }

        }
        #endregion

        void AddProperty(ExpandoObject expando, string propertyName, object value)
        {
            // Cast ExpandoObject to IDictionary to add properties dynamically
            var expandoDict = (IDictionary<string, object>)expando;
            expandoDict[propertyName] = value;
        }
        private Guid GetPropertyValueAsGuid(object entity, string propertyName)
        {
            if (entity.GetType().GetProperty(propertyName) != null)
            {
                return (Guid)(entity.GetType().GetProperty(propertyName)?.GetValue(entity) ?? default(Guid));
            }
            return default(Guid);
        }
    }
}
