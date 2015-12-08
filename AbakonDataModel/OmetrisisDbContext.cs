using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity.Infrastructure;



namespace AbakonDataModel
{/*
  //  [DbConfigurationType(typeof(MyConfiguration))]
    public class PgSqlDBContext : DbContext 
    {
        private static PgSqlDBContext _instance;
        private static String _connectionString = "User Id=ZBenedykt;Password=kiowdzbp;Host=localhost;Port=5432;Database=AbakonDbDev;Schema=public;Unicode=true";
        // ConnectionString.GetConnectionString();

        //@"Server=.\ZBYSZEKB;Trusted_Connection=true;Database=PomiaroweDevNew";

        //@"Server=IND-S4VMFN3\SQLEXPRESS; User ID=GEIPS-EURO\120012575; Trusted_Connection=true;Database=PomiaroweDevNew";

        //@"Data Source=WITEKXP\SQLEXPRESS;User ID=ZBenedykt;Password=kiowdzbp;Database=PomiaroweZB";


        public PgSqlDBContext()
            : base(_connectionString)
        {
            PgSqlEntityProviderConfig config = PgSqlEntityProviderConfig.Instance;
           config.Workarounds.IgnoreSchemaName = true; 

        }
        private PgSqlDBContext(DbConnection baza)
            : base(baza, true) 
       {     
           PgSqlEntityProviderConfig config = PgSqlEntityProviderConfig.Instance;
           config.Workarounds.IgnoreSchemaName = true;
       }

       public class CustomConnectionFactory : IDbConnectionFactory
       {
        enum Bazy
        {
            Abakon,
            Infoserwis,
            Zbyszek,
            Tadek
        }
        public static string GetCurrentConnectionString()
        {
            Bazy baza = Bazy.Zbyszek;

            switch (baza)
            {
                case Bazy.Abakon:
                    return "User Id=WisecomAdmin;Password=wisecomadmin;Host=192.168.0.152;Port=5432;Database=WIDE-IN;Schema=public;Unicode=true";
                case Bazy.Infoserwis:
                    return "User Id=WisecomAdmin;Password=wisecomadmin;Host=192.168.1.152;Port=5432;Database=WIDE-IN;Schema=public;Unicode=true";
                case Bazy.Zbyszek:
                    return "User Id=ZBenedykt;Password=kiowdzbp;Host=localhost;Port=5432;Database=AbakonDBDev;Schema=public;Unicode=true";
                   // return "User Id=Postgres;Host=localhost;Port=5432;Database=AbakonDbdev;Schema=public;Unicode=true";
                case Bazy.Tadek:
                    return "User Id=postgres;Password=Postgres;Host=localhost;Port=5432;Database=WisecomDev;Schema=public;Unicode=true";
                default:
                    return "User Id=ZBenedykt;Password=kiowdzbp;Host=localhost;Port=5432;Database=WISECOMdev;Schema=public;Unicode=true";
            }
        }
        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            return new PgSqlConnection(GetCurrentConnectionString());
        }
       }
        public static PgSqlDBContext GetModelDbContext(Boolean global = true)
        {

            if (global)
            {
                if (_instance == null)
                {
                    _instance = new PgSqlDBContext();
                }
                return _instance;
            }
            else
            {
                return new PgSqlDBContext();
            }
            //if (global)
            //{
            //    if (_instance == null)
            //    {
            //        _instance = new OmetrisisDbContext();
            //        //   _instance.Database.Log = Console.Write; 

            //    }
            //    // _instance.Configuration.AutoDetectChangesEnabled = false;

            //    return _instance;
            //}
            //else
            //{
            //    return new OmetrisisDbContext();
            //}
        }

        public static void RecreateDbContext(string newConnectionString)
        {
            _connectionString = newConnectionString;
            _instance = new PgSqlDBContext();

        }

        public DbSet<_Application> _ApplicationDbSet { get; set; }
        public DbSet<_Membership> _MembershipDbSet { get; set; }
        public DbSet<_Role> _RoleDbSet { get; set; }
        public DbSet<_User> _UserDbSet { get; set; }

        public DbSet<Document> DocumentDbSet { get; set; }
        public DbSet<EquipmentDocument> EquipmentDocumentDbSet { get; set; }
        public DbSet<DocumentClassificationPattern> DocumentClassificationPaternDbSet { get; set; }
        public DbSet<FilePath> FilePathDbSet { get; set; }
        public DbSet<Standard> StandardDbSet { get; set; }

        public DbSet<PrzyrzadPomiarowy> PrzyrzadPomiarowyDbSet { get; set; }
        public DbSet<Elektryczne> ElektryczneDbSet { get; set; }
        public DbSet<Mechaniczne> MechaniczneDbSet { get; set; }
        public DbSet<Sprawdziany> SprawdzianyDbSet { get; set; }
        public DbSet<SprawdzianyDoGwintow> SprawdzianyDoGwintowDbSet { get; set; }
        public DbSet<WielkoscMierzona> WielkoscMierzonaDbSet { get; set; }
        public DbSet<EquipmentType> EquipmentTypeDbSet { get; set; }

        public DbSet<GrupaWyrobow> GrupaWyrobowSet { get; set; }
        public DbSet<Wyrob> WyrobDbSet { get; set; }
        public DbSet<EquipmentScope> EquipmentScopeDbSet { get; set; }

        public DbSet<Department> DepartmentDbSet { get; set; }
        public DbSet<Partner> PartnerDbSet { get; set; }
        public DbSet<Person> PersonDbSet { get; set; }
        public DbSet<Employee> EmployeeDbSet { get; set; }
        public DbSet<Kalibracja> KalibracjaDbSet { get; set; }
        public DbSet<Kalibracja_Kalibratory> Kalibracja_KalibratoryDbSet { get; set; }

        public DbSet<PersonEquipment> PersonEquipmentDbSet { get; set; }
        public DbSet<AirConditionDevice> AirConditionDeviceDbSet { get; set; }
        public DbSet<_KeyBoardKey> _KeyBoardKeyDbSet { get; set; }


        //http://www.entityframeworktutorial.net/code-first/configure-one-to-one-relationship-in-code-first.aspx

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.ComplexTypeAttributeConvention>();

            modelBuilder.Entity<_Membership>()
                       .HasRequired(u => u.applicationMemb)
                       .WithMany(u => u.memberships)
                       .HasForeignKey(u => u.ApplicationId)
                       .WillCascadeOnDelete(true);

            modelBuilder.Entity<_User>()  //one-to-many
            .HasRequired(u => u.application)
            .WithMany(u => u.users)
            .HasForeignKey(u => u.ApplicationId)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<_Membership>()  // one-to-one
              .HasRequired(u => u.userMemb)
              .WithRequiredDependent(u => u.membership)
              .WillCascadeOnDelete(true);

            modelBuilder.Entity<_Role>()
            .HasRequired(u => u.application)
            .WithMany(u => u.roles)
            .HasForeignKey(u => u.ApplicationId)
            .WillCascadeOnDelete(true);

            modelBuilder.Entity<Document>()  //one-to-many
            .HasRequired(u => u.documentClassificationPattern)
            .WithMany(u => u.documents)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Document>()  //one-to-many
            .HasRequired(u => u.filePath)
            .WithMany(u => u.documents)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasOptional(c => c.manager)
                .WithMany(t => t.managerList)
                .Map(m => m.MapKey("KierownikID"));

            modelBuilder.Entity<Employee>()
                .HasOptional(c => c.deputyManager)
                .WithMany(t => t.deputyManagerList)
                .Map(m => m.MapKey("ZastKierownikID"));

            modelBuilder.Entity<Employee>()
                .HasRequired(c => c.person)
                .WithMany(t => t.employees)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Partner>()
                .Property(t => t.PartnerCode)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_PartnerCode", 1) { IsUnique = true }));

            modelBuilder.Entity<Kalibracja>()
                .HasOptional(t => t.posrednikKalibracji)
                .WithMany(t => t.posrednictwoKalibracjiList)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasRequired(t => t.partner)
                .WithMany(t => t.addressList)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Address>()
                .HasRequired(t => t.person)
                .WithMany(t => t.addressList)
                .WillCascadeOnDelete(true);


        }

        private class DbConfigurationTypeAttribute : Attribute
        {
        }
    }


    //public class MyConfiguration : DbConfiguration
    //{
    //    public MyConfiguration()
    //    {
    //        SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
    //    }
    //}

*/

}
