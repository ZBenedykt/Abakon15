using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations;
using Npgsql;

namespace AbakonDataModel
{
    public class BaseDBContext : DbContext
    {

        #region Constructors

        public BaseDBContext()
            : base()
        {
        }

        public BaseDBContext(string connectionString)
            : base(connectionString)
        {

        }

        #endregion
        //public void MadeDbInitializer()
        //{
        //    Database.SetInitializer(new EntitiesContextInitializer());
        //}

        public DbSet<_Application> _ApplicationDbSet { get; set; }
        public DbSet<_Membership> _MembershipDbSet { get; set; }
        public DbSet<_Role> _RoleDbSet { get; set; }
        public DbSet<_User> _UserDbSet { get; set; }

        public DbSet<Document> DocumentDbSet { get; set; }
              public DbSet<DocumentClassificationPattern> DocumentClassificationPaternDbSet { get; set; }
        public DbSet<FilePath> FilePathDbSet { get; set; }
        public DbSet<Standard> StandardDbSet { get; set; }

      

        public DbSet<Department> DepartmentDbSet { get; set; }
        public DbSet<Partner> PartnerDbSet { get; set; }
        public DbSet<Person> PersonDbSet { get; set; }
        public DbSet<Employee> EmployeeDbSet { get; set; }



        public DbSet<_KeyBoardKey> _KeyBoardKeyDbSet { get; set; }
        public DbSet<Inwestment> InwestmentDbSet { get; set; }
        public DbSet<Inwestment2> Inwestment2DbSet { get; set; }


    }

   


        [DbConfigurationType(typeof(PostgreConfig))]
        public class PgSqlDBContext : BaseDBContext
        {
            static PgSqlDBContext _instance;
            public PgSqlDBContext(string connectionString) : base(connectionString)
            {
            }
        public PgSqlDBContext() : base()
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PgSqlDBContext, PostgreConfiguration<PgSqlDBContext>>(false));
            //MadeDbInitializer();

            //modelBuilder.Entity<_Membership>()
            //          .HasRequired(u => u.applicationMemb)
            //          .WithMany(u => u.memberships)
            //          .HasForeignKey(u => u.ApplicationId)
            //          .WillCascadeOnDelete(true);

            //modelBuilder.Entity<_User>()  //one-to-many
            //.HasRequired(u => u.application)
            //.WithMany(u => u.users)
            //.HasForeignKey(u => u.ApplicationId)
            //.WillCascadeOnDelete(false);

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


            modelBuilder.Entity<Address>()
                .HasRequired(t => t.partner)
                .WithMany(t => t.addressList)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Address>()
                .HasRequired(t => t.person)
                .WithMany(t => t.addressList)
                .WillCascadeOnDelete(true);
        }


        internal static PgSqlDBContext GetModelDbContext()
        {
                if (_instance == null)
                {
                _instance = new PgSqlDBContext ("PgSqlDBContext");
                }
                return _instance;         

        }
    }


    public class PostgreConfiguration<TDbContext> : DbMigrationsConfiguration<TDbContext> where TDbContext : PgSqlDBContext
    {
        public PostgreConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
    internal class PostgreConfig : DbConfiguration
    {
        internal PostgreConfig()
        {
            SetProviderServices("Npgsql", new NpgsqlServices());
            SetDefaultConnectionFactory(new NpgsqlConnectionFactory());
            SetProviderFactory("Npgsql", NpgsqlFactory.Instance);
        }
    }
}