using _4EPlatform.Domain.Models.ELibraryModels;
using _4EPlatform.Domain.Models.Lookups;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace _4EPlatForm.Infrastrucure.Context
{
    public class ContextSeed
    {
        private static AppDBContext _dbContext;
        private static IServiceProvider _serviceProvider;
        public static void Seed(AppDBContext appDbContext, IServiceProvider serviceProvider, Microsoft.Extensions.Configuration.IConfiguration configration)
        {
            _dbContext = appDbContext;
            _dbContext.Database.EnsureCreated();
            _serviceProvider = serviceProvider;
            SeedLK_AttachmentSource();
            SeedLK_IdentityType();
            SeedLK_Judgements();
            SeedLK_CauseCategories();
            SeedLK_Stage();
            SeedLK_ClassificationTypeELibraries();
            SeedLK_TypeJudiciary();
            SeedLK_Organization();


            bool isSeedEnabled = configration.GetSection("IsSeedData").Get<bool>();
            if (isSeedEnabled)
            {
                SeedLawyers();
                SeedLitigants();
                SeedELibraries();
                SeedCause();
            }

        }
        private static void SeedLK_AttachmentSource()
        {

            string LK_AttachmentSourceJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "LK_AttachmentSourceSeedData.json");
            var LK_AttachmentSources = JsonConvert.DeserializeObject<List<LK_AttachmentSource>>(LK_AttachmentSourceJson);

            if (LK_AttachmentSources != null && LK_AttachmentSources.Any())
                if (LK_AttachmentSources != null && LK_AttachmentSources.Any())
                {
                    _dbContext.Database.OpenConnection();
                    try
                    {
                        if (!_dbContext.LK_AttachmentSources.Any())
                        {
                            foreach (var AttachmentSource in LK_AttachmentSources)
                            {
                                AttachmentSource.CreatedOn = DateTime.Now;
                            }

                            _dbContext.LK_AttachmentSources.AddRange(LK_AttachmentSources);
                            _dbContext.SaveChanges();
                        }
                        else
                        {
                            var existingLK_AttachmentSources = _dbContext.LK_AttachmentSources.ToList();
                            var newLK_AttachmentSources = LK_AttachmentSources
                                .Where(na => existingLK_AttachmentSources.Any(ea => ea.NameEn == na.NameEn))
                                .ToList();

                            if (!newLK_AttachmentSources.Any())
                            {
                                foreach (var AttachmentSource in newLK_AttachmentSources)
                                {
                                    AttachmentSource.CreatedOn = DateTime.Now;
                                }

                                _dbContext.LK_AttachmentSources.AddRange(newLK_AttachmentSources);
                                _dbContext.SaveChanges();
                            }
                        }
                    }
                    finally
                    {
                        _dbContext.Database.CloseConnection();
                    }
                }

        }
        private static void SeedLK_IdentityType()
        {

            string LK_IdentityTypeJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "LK_IdentityTypesSeedData.json");
            var LK_IdentityTypes = JsonConvert.DeserializeObject<List<LK_IdentityType>>(LK_IdentityTypeJson);

            if (LK_IdentityTypes != null && LK_IdentityTypes.Any())
                if (LK_IdentityTypes != null && LK_IdentityTypes.Any())
                {
                    _dbContext.Database.OpenConnection();
                    try
                    {
                        if (!_dbContext.LK_IdentityTypes.Any())
                        {
                            foreach (var LK_IdentityType in LK_IdentityTypes)
                            {
                                LK_IdentityType.CreatedOn = DateTime.Now;
                            }

                            _dbContext.LK_IdentityTypes.AddRange(LK_IdentityTypes);
                            _dbContext.SaveChanges();
                        }
                        else
                        {
                            var existingLK_IdentityTypes = _dbContext.LK_AttachmentSources.ToList();
                            var newLK_IdentityTypes = LK_IdentityTypes
                                .Where(na => existingLK_IdentityTypes.Any(ea => ea.NameEn == na.NameEn))
                                .ToList();

                            if (!newLK_IdentityTypes.Any())
                            {
                                foreach (var Agreement in newLK_IdentityTypes)
                                {
                                    Agreement.CreatedOn = DateTime.Now;
                                }

                                _dbContext.LK_IdentityTypes.AddRange(newLK_IdentityTypes);
                                _dbContext.SaveChanges();
                            }
                        }
                    }
                    finally
                    {
                        _dbContext.Database.CloseConnection();
                    }
                }

        }
        private static void SeedLK_Judgements()
        {
            string LK_JudgementsJson = File.ReadAllText(
                @"SeedData" + Path.DirectorySeparatorChar + "LK_JudgementSeedData.json"
            );
            var LK_Judgements = JsonConvert.DeserializeObject<List<LK_Judgement>>(LK_JudgementsJson);

            if (LK_Judgements != null && LK_Judgements.Any())
            {
                _dbContext.Database.OpenConnection();
                try
                {
                    _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.LK_Judgements ON");

                    var existingJudgements = _dbContext.LK_Judgements.ToList();

                    foreach (var judgement in LK_Judgements)
                    {
                        var existing = existingJudgements.FirstOrDefault(e => e.Id == judgement.Id);

                        if (existing != null)
                        {
                            // تحديث البيانات لو في اختلاف
                            if (existing.NameAr != judgement.NameAr || existing.NameEn != judgement.NameEn)
                            {
                                existing.NameAr = judgement.NameAr;
                                existing.NameEn = judgement.NameEn;
                                existing.UpdatedOn = DateTime.Now;
                                _dbContext.LK_Judgements.Update(existing);
                            }
                        }
                        else
                        {
                            // إضافة جديدة
                            judgement.CreatedOn = DateTime.Now;
                            _dbContext.LK_Judgements.Add(judgement);
                        }
                    }

                    _dbContext.SaveChanges();

                    _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.LK_Judgements OFF");
                }
                finally
                {
                    _dbContext.Database.CloseConnection();
                }
            }
        }
        private static void SeedLK_CauseCategories()
        {
            string lKCaseCategoryJson = File.ReadAllText(
                @"SeedData" + Path.DirectorySeparatorChar + "LK_CaseCategorySeedData.json"
            );

            var lKCauseCategories = JsonConvert.DeserializeObject<List<LK_CauseCategory>>(lKCaseCategoryJson);

            if (lKCauseCategories != null && lKCauseCategories.Any())
            {
                _dbContext.Database.OpenConnection();
                try
                {
                    _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.LK_CauseCategories ON");

                    var existingDict = _dbContext.LK_CauseCategories
                        .ToDictionary(x => x.Id, x => x);

                    foreach (var causeCategory in lKCauseCategories)
                    {
                        if (existingDict.TryGetValue(causeCategory.Id, out var existing))
                        {
                            if (existing.NameAr != causeCategory.NameAr || existing.NameEn != causeCategory.NameEn)
                            {
                                existing.NameAr = causeCategory.NameAr;
                                existing.NameEn = causeCategory.NameEn;
                                existing.IsSeed = true;
                                existing.UpdatedOn = DateTime.Now;

                                _dbContext.LK_CauseCategories.Update(existing);
                            }
                        }
                        else
                        {
                            causeCategory.CreatedOn = DateTime.Now;
                            causeCategory.IsSeed = true;
                            _dbContext.LK_CauseCategories.Add(causeCategory);
                        }
                    }

                    _dbContext.SaveChanges();

                    _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.LK_CauseCategories OFF");
                }
                finally
                {
                    _dbContext.Database.CloseConnection();
                }
            }
        }
        private static void SeedLK_Stage()
        {
            string LK_StageJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "LK_StageSeedData.json");
            var LK_Stages = JsonConvert.DeserializeObject<List<LK_Stage>>(LK_StageJson);

            if (LK_Stages != null && LK_Stages.Any())
            {
                _dbContext.Database.OpenConnection();
                try
                {
                    _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.LK_Stages ON");

                    var existingStages = _dbContext.LK_Stages.ToList();

                    foreach (var stage in LK_Stages)
                    {
                        var existing = existingStages.FirstOrDefault(e => e.Id == stage.Id);

                        if (existing != null)
                        {
                            if (existing.NameAr != stage.NameAr || existing.NameEn != stage.NameEn)
                            {
                                existing.NameAr = stage.NameAr;
                                existing.NameEn = stage.NameEn;
                                existing.UpdatedOn = DateTime.Now;
                                _dbContext.LK_Stages.Update(existing);
                            }
                        }
                        else
                        {
                            stage.CreatedOn = DateTime.Now;
                            _dbContext.LK_Stages.Add(stage);
                        }
                    }

                    _dbContext.SaveChanges();

                    // إغلاق الـ identity insert
                    _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.LK_Stages OFF");
                }
                finally
                {
                    _dbContext.Database.CloseConnection();
                }
            }
        }
        private static void SeedLK_ClassificationTypeELibraries()
        {

            string LK_ClassificationTypeELibrariesJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "LK_ClassificationTypeELibrariesSeedData.json");
            var LK_ClassificationTypeELibraries = JsonConvert.DeserializeObject<List<LK_ClassificationTypeELibraries>>(LK_ClassificationTypeELibrariesJson);

            if (LK_ClassificationTypeELibraries != null && LK_ClassificationTypeELibraries.Any())
                if (LK_ClassificationTypeELibraries != null && LK_ClassificationTypeELibraries.Any())
                {
                    _dbContext.Database.OpenConnection();
                    try
                    {
                        if (!_dbContext.LK_ClassificationTypeELibraries.Any())
                        {
                            foreach (var LK_ClassificationTypeELibrary in LK_ClassificationTypeELibraries)
                            {
                                LK_ClassificationTypeELibrary.CreatedOn = DateTime.Now;
                            }

                            _dbContext.LK_ClassificationTypeELibraries.AddRange(LK_ClassificationTypeELibraries);
                            _dbContext.SaveChanges();
                        }
                        else
                        {
                            var existingLK_ClassificationTypeELibraries = _dbContext.LK_ClassificationTypeELibraries.ToList();
                            var newLK_ClassificationTypeELibraries = LK_ClassificationTypeELibraries
                                .Where(na => existingLK_ClassificationTypeELibraries.Any(ea => ea.NameEn == na.NameEn))
                                .ToList();

                            if (!newLK_ClassificationTypeELibraries.Any())
                            {
                                foreach (var lK_ClassificationTypeELibrary in newLK_ClassificationTypeELibraries)
                                {
                                    lK_ClassificationTypeELibrary.CreatedOn = DateTime.Now;
                                }

                                _dbContext.LK_ClassificationTypeELibraries.AddRange(newLK_ClassificationTypeELibraries);
                                _dbContext.SaveChanges();
                            }
                        }
                    }
                    finally
                    {
                        _dbContext.Database.CloseConnection();
                    }
                }
        }
        private static void SeedLK_TypeJudiciary()
        {
            string LK_TypeJudiciaryJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "LK_TypeJudiciarySeedData.json");
            var LK_TypeJudiciaries = JsonConvert.DeserializeObject<List<LK_TypeJudiciary>>(LK_TypeJudiciaryJson);

            if (LK_TypeJudiciaries != null && LK_TypeJudiciaries.Any())
            {
                _dbContext.Database.OpenConnection();
                try
                {
                    _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [LK_TypeJudiciary] ON");
                    if (!_dbContext.LK_TypeJudiciary.Any())
                    {
                        foreach (var lk_TypeJudiciary in LK_TypeJudiciaries)
                        {
                            lk_TypeJudiciary.CreatedOn = DateTime.Now;
                        }

                        _dbContext.LK_TypeJudiciary.AddRange(LK_TypeJudiciaries);
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        var existingLK_TypeJudiciaries = _dbContext.LK_TypeJudiciary.ToList();
                        var newLK_TypeJudiciaries = LK_TypeJudiciaries
                            .Where(na => !existingLK_TypeJudiciaries.Any(ea => ea.Id == na.Id))
                            .ToList();

                        if (newLK_TypeJudiciaries.Any())
                        {
                            foreach (var lk_TypeJudiciary in newLK_TypeJudiciaries)
                            {
                                lk_TypeJudiciary.CreatedOn = DateTime.Now;
                            }

                            _dbContext.LK_TypeJudiciary.AddRange(newLK_TypeJudiciaries);
                            _dbContext.SaveChanges();
                        }
                    }
                }
                finally
                {
                    _dbContext.Database.CloseConnection();
                }
            }
        }
        private static void SeedLK_Organization()
        {
            string LK_OrganizationJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "LK_OrganizationSeedData.json");
            var LK_Organizations = JsonConvert.DeserializeObject<List<LK_Organization>>(LK_OrganizationJson);

            if (LK_Organizations != null && LK_Organizations.Any())
            {
                _dbContext.Database.OpenConnection();
                try
                {
                    _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.LK_Organization ON");

                    var existingOrganizations = _dbContext.LK_Organization.ToList();

                    foreach (var org in LK_Organizations)
                    {
                        var existing = existingOrganizations.FirstOrDefault(e => e.Id == org.Id);

                        if (existing != null)
                        {
                            if (existing.NameAr != org.NameAr || existing.NameEn != org.NameEn)
                            {
                                existing.NameAr = org.NameAr;
                                existing.NameEn = org.NameEn;
                                existing.UpdatedOn = DateTime.Now;
                                _dbContext.LK_Organization.Update(existing);
                            }
                        }
                        else
                        {
                            org.CreatedOn = DateTime.Now;
                            _dbContext.LK_Organization.Add(org);
                        }
                    }

                    _dbContext.SaveChanges();

                    _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.LK_Organization OFF");
                }
                finally
                {
                    _dbContext.Database.CloseConnection();
                }
            }
        }
        private static void SeedLitigants()
        {
            var filePath = Path.Combine("SeedData", "LitigantsSeedData.json");

            if (!File.Exists(filePath))
                return;

            var json = File.ReadAllText(filePath);
            var litigants = JsonConvert.DeserializeObject<List<_4EPlatform.Domain.Models.CasuseModels.Litigant>>(json);

            if (litigants is not { Count: > 0 } || _dbContext.Litigants.Any())
                return;

            var now = DateTime.Now;

            litigants.ForEach(l => l.CreatedOn = now);

            try
            {
                _dbContext.Litigants.AddRange(litigants);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during seeding litigants: " + ex.Message);
                throw;
            }
        }
        private static void SeedELibraries()
        {
            var filePath = Path.Combine("SeedData", "ELibrariesSeedData.json");

            if (!File.Exists(filePath))
                return;

            var json = File.ReadAllText(filePath);
            var attachments = JsonConvert.DeserializeObject<List<ELibrary>>(json);

            if (attachments is not { Count: > 0 } || _dbContext.ELibraries.Any())
                return;

            var now = DateTime.Now;

            attachments.ForEach(a => a.CreatedOn = now);

            try
            {
                _dbContext.ELibraries.AddRange(attachments);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during seeding document attachments: " + ex.Message);
                throw;
            }
        }
        private static void SeedLawyers()
        {
            var filePath = Path.Combine("SeedData", "CauseLawyersSeedData.json");

            if (!File.Exists(filePath))
                return;

            var json = File.ReadAllText(filePath);
            var lawyers = JsonConvert.DeserializeObject<List<_4EPlatform.Domain.Models.CasuseModels.CauseLawyer>>(json);

            if (lawyers is not { Count: > 0 } || _dbContext.CauseLawyers.Any())
                return;

            var now = DateTime.Now;

            lawyers.ForEach(l => l.CreatedOn = now);

            try
            {
                _dbContext.CauseLawyers.AddRange(lawyers);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during seeding lawyers: " + ex.Message);
                throw;
            }
        }
        private static void SeedCause()
        {
            var filePath = Path.Combine("SeedData", "LegalSeedData.json");

            if (!File.Exists(filePath))
                return;

            var json = File.ReadAllText(filePath);
            var causes = JsonConvert.DeserializeObject<List<_4EPlatform.Domain.Models.CasuseModels.Cause>>(json);

            if (causes is not { Count: > 0 } || _dbContext.Causes.Any())
                return;

            var now = DateTime.Now;

            foreach (var cause in causes)
            {
                cause.CreatedOn = now;

                cause.CauseAssigns?.ToList().ForEach(assign => assign.CreatedOn = now);
                cause.CauseLitigants?.ToList().ForEach(lit => lit.CreatedOn = now);

                cause.CauseStages?.ToList().ForEach(stage =>
                {
                    stage.CreatedOn = now;

                    stage.CauseStageAttachment?.ToList().ForEach(att => att.CreatedOn = now);
                    stage.CauseHistories?.ToList().ForEach(hist => hist.CreatedOn = now);

                    stage.Sessions?.ToList().ForEach(session =>
                    {
                        session.CreatedOn = now;

                        session.Assignees?.ToList().ForEach(assign => assign.CreatedOn = now);
                        session.Attachments?.ToList().ForEach(att => att.CreatedOn = now);

                        session.SessionNote?.ToList().ForEach(note =>
                        {
                            note.CreatedOn = now;
                            note.CauseStageNoteAttachments?.ToList().ForEach(att => att.CreatedOn = now);
                        });

                        session.JedgementGrounds?.ToList().ForEach(ground =>
                        {
                            ground.CreatedOn = now;
                            ground.Judgements?.ToList().ForEach(att => att.CreatedOn = now);
                            ground.JudgementRequirements?.ToList().ForEach(req => req.CreatedOn = now);
                        });
                    });
                });
            }

            try
            {
                _dbContext.Causes.AddRange(causes);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during seeding causes: " + ex.Message);
                throw;
            }
        }
    }
}
