﻿// <auto-generated />
using System;
using HealthStabilizer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthStabilizer.Data.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20191001142948_change_VitaminEntity")]
    partial class change_VitaminEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HealthStabilizer.Data.Entities.DailyIntake", b =>
                {
                    b.Property<int>("DailyIntakeId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Calories");

                    b.Property<float>("Carbs");

                    b.Property<float>("Fat");

                    b.Property<int>("ForUserId");

                    b.Property<string>("ForUserId1");

                    b.Property<int>("MineralId");

                    b.Property<string>("Name");

                    b.Property<float>("Protein");

                    b.Property<int>("VitaminId");

                    b.HasKey("DailyIntakeId");

                    b.HasIndex("ForUserId1");

                    b.HasIndex("MineralId");

                    b.HasIndex("VitaminId");

                    b.ToTable("DailyIntake");
                });

            modelBuilder.Entity("HealthStabilizer.Data.Entities.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<float>("Calories");

                    b.Property<string>("Description");

                    b.Property<int?>("ForUserId");

                    b.Property<int>("MineralId");

                    b.Property<string>("Name");

                    b.Property<float?>("PiecesInPackage");

                    b.Property<string>("QrCode");

                    b.Property<int>("VitaminId");

                    b.Property<float?>("WeightPerPiece");

                    b.HasKey("FoodId");

                    b.HasIndex("MineralId");

                    b.HasIndex("VitaminId");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("HealthStabilizer.Data.Entities.Mineral", b =>
                {
                    b.Property<int>("MineralId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Calcium");

                    b.Property<float>("Chlorine");

                    b.Property<float>("Chrome");

                    b.Property<float>("Copper");

                    b.Property<float>("Fluorine");

                    b.Property<float>("Iodine");

                    b.Property<float>("Iron");

                    b.Property<float>("Magnesium");

                    b.Property<float>("Molybdenum");

                    b.Property<float>("Nanganese");

                    b.Property<float>("Phosphorus");

                    b.Property<float>("Potassium");

                    b.Property<float>("Selenium");

                    b.Property<float>("Zinc");

                    b.HasKey("MineralId");

                    b.ToTable("Mineral");
                });

            modelBuilder.Entity("HealthStabilizer.Data.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("HealthStabilizer.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("Age");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<int>("Height");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<float>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("HealthStabilizer.Data.Entities.UserRole", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.Property<string>("RoleId1");

                    b.Property<string>("UserId1");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId1");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("HealthStabilizer.Data.Entities.Vitamin", b =>
                {
                    b.Property<int>("VitaminId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Biotin");

                    b.Property<float>("Choline");

                    b.Property<float>("FolicAcid");

                    b.Property<float>("Niacin");

                    b.Property<float>("PanotehnicAcid");

                    b.Property<float>("Riboflavin");

                    b.Property<float>("Thiamine");

                    b.Property<float>("VitaminA");

                    b.Property<float>("VitaminB12");

                    b.Property<float>("VitaminB6");

                    b.Property<float>("VitaminC");

                    b.Property<float>("VitaminD");

                    b.Property<float>("VitaminE");

                    b.Property<float>("VitaminK");

                    b.HasKey("VitaminId");

                    b.ToTable("Vitamin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HealthStabilizer.Data.Entities.DailyIntake", b =>
                {
                    b.HasOne("HealthStabilizer.Data.Entities.User", "ForUser")
                        .WithMany()
                        .HasForeignKey("ForUserId1");

                    b.HasOne("HealthStabilizer.Data.Entities.Mineral", "Mineral")
                        .WithMany()
                        .HasForeignKey("MineralId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthStabilizer.Data.Entities.Vitamin", "Vitamin")
                        .WithMany()
                        .HasForeignKey("VitaminId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthStabilizer.Data.Entities.Food", b =>
                {
                    b.HasOne("HealthStabilizer.Data.Entities.Mineral", "Mineral")
                        .WithMany()
                        .HasForeignKey("MineralId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthStabilizer.Data.Entities.Vitamin", "Vitamin")
                        .WithMany()
                        .HasForeignKey("VitaminId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthStabilizer.Data.Entities.UserRole", b =>
                {
                    b.HasOne("HealthStabilizer.Data.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthStabilizer.Data.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId1");

                    b.HasOne("HealthStabilizer.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthStabilizer.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("HealthStabilizer.Data.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HealthStabilizer.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HealthStabilizer.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HealthStabilizer.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}