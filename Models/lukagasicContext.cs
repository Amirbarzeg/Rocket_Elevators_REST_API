using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rocket_Elevators_REST_API.Models
{
    public partial class lukagasicContext : DbContext
    {
        public lukagasicContext()
        {
        }

        public lukagasicContext(DbContextOptions<lukagasicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActiveStorageAttachments> ActiveStorageAttachments { get; set; }
        public virtual DbSet<ActiveStorageBlobs> ActiveStorageBlobs { get; set; }
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<ArInternalMetadata> ArInternalMetadata { get; set; }
        public virtual DbSet<Batteries> Batteries { get; set; }
        public virtual DbSet<BuildingDetails> BuildingDetails { get; set; }
        public virtual DbSet<Buildings> Buildings { get; set; }
        public virtual DbSet<Columns> Columns { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Elevators> Elevators { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<Quotes> Quotes { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SchemaMigrations> SchemaMigrations { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersRoles> UsersRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=codeboxx.cq6zrczewpu2.us-east-1.rds.amazonaws.com;Port=3306;Database=lukagasic;Uid=codeboxx;Pwd=Codeboxx1!;SslMode=none");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiveStorageAttachments>(entity =>
            {
                entity.ToTable("active_storage_attachments");

                entity.HasIndex(e => e.BlobId)
                    .HasName("index_active_storage_attachments_on_blob_id");

                entity.HasIndex(e => new { e.RecordType, e.RecordId, e.Name, e.BlobId })
                    .HasName("index_active_storage_attachments_uniqueness")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BlobId)
                    .HasColumnName("blob_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.RecordId)
                    .HasColumnName("record_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.RecordType)
                    .IsRequired()
                    .HasColumnName("record_type")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Blob)
                    .WithMany(p => p.ActiveStorageAttachments)
                    .HasForeignKey(d => d.BlobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_c3b3935057");
            });

            modelBuilder.Entity<ActiveStorageBlobs>(entity =>
            {
                entity.ToTable("active_storage_blobs");

                entity.HasIndex(e => e.Key)
                    .HasName("index_active_storage_blobs_on_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ByteSize)
                    .HasColumnName("byte_size")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Checksum)
                    .IsRequired()
                    .HasColumnName("checksum")
                    .HasMaxLength(255);

                entity.Property(e => e.ContentType)
                    .HasColumnName("content_type")
                    .HasMaxLength(255);

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("filename")
                    .HasMaxLength(255);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasMaxLength(255);

                entity.Property(e => e.Metadata).HasColumnName("metadata");
            });

            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Apt).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.Entity).HasMaxLength(255);

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.NumberAndStreet).HasMaxLength(255);

                entity.Property(e => e.PostalCode).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.TypeOfAddress).HasMaxLength(255);
            });

            modelBuilder.Entity<ArInternalMetadata>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PRIMARY");

                entity.ToTable("ar_internal_metadata");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasMaxLength(255);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Batteries>(entity =>
            {
                entity.ToTable("batteries");

                entity.HasIndex(e => e.BuildingId)
                    .HasName("index_batteries_on_building_id");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("index_batteries_on_employee_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Btype)
                    .HasColumnName("BType")
                    .HasMaxLength(255);

                entity.Property(e => e.BuildingId)
                    .HasColumnName("building_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CertificateOfOperations).HasMaxLength(255);

                entity.Property(e => e.DateOfCommissioning).HasColumnType("date");

                entity.Property(e => e.DateOfLastInspection).HasColumnType("date");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_fc40470545");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_rails_ceeeaf55f7");
            });

            modelBuilder.Entity<BuildingDetails>(entity =>
            {
                entity.ToTable("building_details");

                entity.HasIndex(e => e.BuildingId)
                    .HasName("index_building_details_on_building_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingId)
                    .HasColumnName("building_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.InformationKey).HasMaxLength(255);

                entity.Property(e => e.Value).HasMaxLength(255);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.BuildingDetails)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_51749f8eac");
            });

            modelBuilder.Entity<Buildings>(entity =>
            {
                entity.ToTable("buildings");

                entity.HasIndex(e => e.AddressId)
                    .HasName("index_buildings_on_address_id");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("index_buildings_on_customer_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.EmailOfTheAdministratorOfTheBuilding).HasMaxLength(255);

                entity.Property(e => e.FullNameOfTheBuildingAdministrator).HasMaxLength(255);

                entity.Property(e => e.FullNameOfTheTechContactForTheBuilding).HasMaxLength(255);

                entity.Property(e => e.PhoneNumberOfTheBuildingAdministrator).HasMaxLength(255);

                entity.Property(e => e.TechContactEmail).HasMaxLength(255);

                entity.Property(e => e.TechContactPhone).HasMaxLength(255);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk_rails_6dc7a885ab");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_rails_c29cbe7fb8");
            });

            modelBuilder.Entity<Columns>(entity =>
            {
                entity.ToTable("columns");

                entity.HasIndex(e => e.BatteryId)
                    .HasName("index_columns_on_battery_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BatteryId)
                    .HasColumnName("battery_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ColumnType).HasMaxLength(255);

                entity.Property(e => e.NbOfFloorsServed).HasColumnType("int(11)");

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.BatteryId)
                    .HasConstraintName("fk_rails_021eb14ac4");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.AddressId)
                    .HasName("index_customers_on_address_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_customers_on_user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CompanyContactPhone).HasMaxLength(255);

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.EmailOfTheCompany).HasMaxLength(255);

                entity.Property(e => e.NameOfContact).HasMaxLength(255);

                entity.Property(e => e.NameOfServiceTechAuthority).HasMaxLength(255);

                entity.Property(e => e.TechAuhtorityPhone).HasMaxLength(255);

                entity.Property(e => e.TechManagerServiceEmail).HasMaxLength(255);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk_rails_3f9404ba26");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_9917eeaf5d");
            });

            modelBuilder.Entity<Elevators>(entity =>
            {
                entity.ToTable("elevators");

                entity.HasIndex(e => e.ColumnId)
                    .HasName("index_elevators_on_column_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CertificateOfInspection).HasMaxLength(255);

                entity.Property(e => e.ColumnId)
                    .HasColumnName("column_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.DateOfCommissioning).HasColumnType("date");

                entity.Property(e => e.DateOfLastInspection).HasColumnType("date");

                entity.Property(e => e.ElevatorType).HasMaxLength(255);

                entity.Property(e => e.Model).HasMaxLength(255);

                entity.Property(e => e.SerialNumber).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Elevators)
                    .HasForeignKey(d => d.ColumnId)
                    .HasConstraintName("fk_rails_69442d7bc2");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_employees_on_user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_dcfd3d4fc3");
            });

            modelBuilder.Entity<Leads>(entity =>
            {
                entity.ToTable("leads");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AttachedFile).HasColumnType("blob");

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.Departement).HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.ProjectDescription).HasMaxLength(255);

                entity.Property(e => e.ProjectName).HasMaxLength(255);
            });

            modelBuilder.Entity<Quotes>(entity =>
            {
                entity.ToTable("quotes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingType).HasMaxLength(255);

                entity.Property(e => e.ColumnAmount).HasColumnType("int(11)");

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.ElevatorAmount).HasColumnType("int(11)");

                entity.Property(e => e.ElevatorTotalCost).HasColumnType("int(11)");

                entity.Property(e => e.ElevatorUnitCost).HasColumnType("int(11)");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.InstallationCost).HasColumnType("int(11)");

                entity.Property(e => e.NumberOfApartments).HasColumnType("int(11)");

                entity.Property(e => e.NumberOfBasements).HasColumnType("int(11)");

                entity.Property(e => e.NumberOfBusinessHours).HasColumnType("int(11)");

                entity.Property(e => e.NumberOfCorporations).HasColumnType("int(11)");

                entity.Property(e => e.NumberOfElevators).HasColumnType("int(11)");

                entity.Property(e => e.NumberOfFloors).HasColumnType("int(11)");

                entity.Property(e => e.NumberOfOccupany).HasColumnType("int(11)");

                entity.Property(e => e.NumberOfParkingSpots).HasColumnType("int(11)");

                entity.Property(e => e.NumberOfcompanies).HasColumnType("int(11)");

                entity.Property(e => e.ProductLine).HasMaxLength(255);

                entity.Property(e => e.TotalPrice).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.HasIndex(e => e.Name)
                    .HasName("index_roles_on_name");

                entity.HasIndex(e => new { e.ResourceType, e.ResourceId })
                    .HasName("index_roles_on_resource_type_and_resource_id");

                entity.HasIndex(e => new { e.Name, e.ResourceType, e.ResourceId })
                    .HasName("index_roles_on_name_and_resource_type_and_resource_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.ResourceId)
                    .HasColumnName("resource_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ResourceType)
                    .HasColumnName("resource_type")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SchemaMigrations>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PRIMARY");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("index_users_on_email")
                    .IsUnique();

                entity.HasIndex(e => e.ResetPasswordToken)
                    .HasName("index_users_on_reset_password_token")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EncryptedPassword)
                    .IsRequired()
                    .HasColumnName("encrypted_password")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ResetPasswordToken)
                    .HasColumnName("reset_password_token")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<UsersRoles>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("users_roles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("index_users_roles_on_role_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_users_roles_on_user_id");

                entity.HasIndex(e => new { e.UserId, e.RoleId })
                    .HasName("index_users_roles_on_user_id_and_role_id");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
