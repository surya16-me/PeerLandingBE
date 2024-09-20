﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240918085655_mstuserpass")]
    partial class mstuserpass
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.MstLoans", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<string>("BorrowerId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("borrower_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("Duration")
                        .HasColumnType("integer")
                        .HasColumnName("duration_in_months");

                    b.Property<decimal>("InterestRate")
                        .HasColumnType("numeric")
                        .HasColumnName("interest_rate");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_updated_at");

                    b.HasKey("Id");

                    b.HasIndex("BorrowerId");

                    b.ToTable("mst_loans");
                });

            modelBuilder.Entity("DAL.Models.MstUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<decimal?>("Balance")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("balance");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("mst_user");
                });

            modelBuilder.Entity("DAL.Models.TrnFund", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<DateTime>("FundedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("funded_at");

                    b.Property<string>("LenderId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lender_id");

                    b.Property<string>("LoanId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("loan_id");

                    b.HasKey("Id");

                    b.HasIndex("LenderId");

                    b.HasIndex("LoanId");

                    b.ToTable("trn_fund");
                });

            modelBuilder.Entity("DAL.Models.TrnRepayment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<string>("LoanId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("PaidAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("paid_at");

                    b.HasKey("Id");

                    b.HasIndex("LoanId");

                    b.ToTable("trn_repayment");
                });

            modelBuilder.Entity("DAL.Models.MstLoans", b =>
                {
                    b.HasOne("DAL.Models.MstUser", "User")
                        .WithMany("MstLoans")
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.TrnFund", b =>
                {
                    b.HasOne("DAL.Models.MstUser", "User")
                        .WithMany("MstFunds")
                        .HasForeignKey("LenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.MstLoans", "Loan")
                        .WithMany("MstFunds")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.TrnRepayment", b =>
                {
                    b.HasOne("DAL.Models.MstLoans", "Loan")
                        .WithMany("TrnRepayments")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("DAL.Models.MstLoans", b =>
                {
                    b.Navigation("MstFunds");

                    b.Navigation("TrnRepayments");
                });

            modelBuilder.Entity("DAL.Models.MstUser", b =>
                {
                    b.Navigation("MstFunds");

                    b.Navigation("MstLoans");
                });
#pragma warning restore 612, 618
        }
    }
}
