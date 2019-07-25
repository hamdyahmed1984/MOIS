using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Entities.Lookups;
using System.Linq;
using Application.Interfaces;
using System.Threading.Tasks;
using Domain.Entities.Security;
using Domain.Entities.Documents;

namespace Persistence.EntityFrameworkDataAccess
{
    public class MoisContext : DbContext, IUnitOfWork
    {
        public MoisContext(DbContextOptions<MoisContext> options): base(options)
        {
        }

        #region Security
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        #endregion

        #region Documents
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<BirthDoc> BirthDocs { get; set; }
        public DbSet<CriminalStateRecord> CriminalStateRecords { get; set; }
        public DbSet<DeathDoc> DeathDocs { get; set; }
        public DbSet<DivorceDoc> DivorceDocs { get; set; }
        public DbSet<FamilyRecord> FamilyRecords { get; set; }
        public DbSet<MarriageDoc> MarriageDocs { get; set; }
        public DbSet<NidDoc> NidDocs { get; set; }
        public DbSet<PersonalRecord> PersonalRecords { get; set; }
        public DbSet<WorkPermitRenew> WorkPermitRenews { get; set; }
        public DbSet<WorkPermitReplace> WorkPermitReplaces { get; set; }
        public DbSet<WorkPermitClearance> WorkPermitClearanceaa { get; set; }
        #endregion

        //public DbSet<Address> Addresses { get; set; }
        public DbSet<ClearanceReason> ClearanceReasons { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<DocumentTypeRelation> DocumentTypeRelations { get; set; }
        public DbSet<ForeignContractorType> ForeignContractorTypes { get; set; }
        public DbSet<ForeignContractType> ForeignContractTypes { get; set; }
        //public DbSet<ForeignContractor> ForeignContractors { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Issuer> Issuers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobTypeNID> JobTypeNIDs { get; set; }
        public DbSet<JobTypeWorkPermit> JobTypeWorkPermits { get; set; }
        public DbSet<Ministry> Ministries { get; set; }
        public DbSet<NidIssueReason> NidIssueReasons { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        //public DbSet<Passport> Passports { get; set; }
        public DbSet<PoliceDepartment> PoliceDepartments { get; set; }
        //public DbSet<PublicSector> PublicSectors { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        //public DbSet<Regulation> Regulations { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<WorkPermitIssueReason> WorkPermitIssueReasons { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<RejectionReason> RejectionReasons { get; set; }
        public DbSet<ReturnReason> ReturnReasons { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<RequestState> RequestStates { get; set; }
        public DbSet<EligibleNID> EligibleNIDs { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<QualificationType> QualificationTypes { get; set; }
        public DbSet<PassportIssuer> PassportIssuers { get; set; }
        public DbSet<GovernmentalEstablishmentType> GovernmentalEstablishmentTypes { get; set; }
        public DbSet<GovernmentalEstablishment> GovernmentalEstablishments { get; set; }
        public DbSet<VacationType> VacationTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<RequestFawry> RequestFawrys { get; set; }
        public DbSet<RequestEFinance> RequestEFinances { get; set; }
        public DbSet<RequestPostal> RequestPostals { get; set; }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters) => await Database.ExecuteSqlCommandAsync(sql, parameters);

        public IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class => Set<TEntity>().FromSql(sql, parameters);

        public async Task<int> CommitChangesAsync() => await SaveChangesAsync();
        public int CommitChanges() => SaveChanges();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureDefaultBehaviorsForEntities(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MoisContext).Assembly);
        }

        private void ConfigureDefaultBehaviorsForEntities(ModelBuilder modelBuilder)
        {
            // equivalent of modelBuilder.Conventions.AddFromAssembly(Assembly.GetExecutingAssembly());
            // look at this answer: https://stackoverflow.com/a/43075152/3419825
            // for the other conventions, we do a metadata model loop
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                //// equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                //entityType.Relational().TableName = entityType.DisplayName();

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                // and modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }
        }
    }
}
