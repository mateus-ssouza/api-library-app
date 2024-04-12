﻿// <auto-generated />
using System;
using ApiBiblioteca.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiBiblioteca.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240315134418_DbMigrationV1")]
    partial class DbMigrationV1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiBiblioteca.Domain.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ApiBiblioteca.Domain.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("03070683-6607-4d1f-88ba-c4f92d0c4cb3"),
                            Author = "J.R.R. Tolkien",
                            ISBN = "9780547928227",
                            Title = "O Hobbit"
                        },
                        new
                        {
                            Id = new Guid("e889b64d-d435-4a6d-a95d-73c2ff37ee0e"),
                            Author = "Ursula K. Le Guin",
                            ISBN = "9780547773742",
                            Title = "Um Feiticeiro de Terramar"
                        },
                        new
                        {
                            Id = new Guid("b351e787-180d-4c99-8ad2-ce89d37106b2"),
                            Author = "Lewis Carroll",
                            ISBN = "9780061121907",
                            Title = "As Aventuras de Alice no País das Maravilhas"
                        },
                        new
                        {
                            Id = new Guid("1d00dffc-57a9-4547-b74e-3fdf02827708"),
                            Author = "Suzanne Collins",
                            ISBN = "9780439023528",
                            Title = "Jogos Vorazes"
                        },
                        new
                        {
                            Id = new Guid("7b66e07a-eaa0-468d-90dd-390ebf16bbf7"),
                            Author = "Philip Reeve",
                            ISBN = "9780060082070",
                            Title = "Máquinas Mortais"
                        });
                });

            modelBuilder.Entity("ApiBiblioteca.Domain.Models.BookLending", b =>
                {
                    b.Property<Guid>("LoanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CopyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoanId", "CopyId");

                    b.HasIndex("CopyId");

                    b.ToTable("BookLendings");
                });

            modelBuilder.Entity("ApiBiblioteca.Domain.Models.Copy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CopyCode")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("CopyCode")
                        .IsUnique();

                    b.ToTable("Copies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e1908131-b1f7-4f6b-b831-4c1080c46930"),
                            Available = true,
                            BookId = new Guid("03070683-6607-4d1f-88ba-c4f92d0c4cb3"),
                            CopyCode = "A001"
                        },
                        new
                        {
                            Id = new Guid("28e06c2f-5329-4760-95fb-dc40733b2ab5"),
                            Available = true,
                            BookId = new Guid("03070683-6607-4d1f-88ba-c4f92d0c4cb3"),
                            CopyCode = "A002"
                        },
                        new
                        {
                            Id = new Guid("de70b5cc-560d-4ccc-80ee-1b221ec227da"),
                            Available = true,
                            BookId = new Guid("03070683-6607-4d1f-88ba-c4f92d0c4cb3"),
                            CopyCode = "A003"
                        },
                        new
                        {
                            Id = new Guid("a14f200f-a22f-42df-aaf5-07953f728862"),
                            Available = true,
                            BookId = new Guid("03070683-6607-4d1f-88ba-c4f92d0c4cb3"),
                            CopyCode = "A004"
                        },
                        new
                        {
                            Id = new Guid("03f89e6d-aeb7-4970-90ef-5811d4f18a65"),
                            Available = true,
                            BookId = new Guid("e889b64d-d435-4a6d-a95d-73c2ff37ee0e"),
                            CopyCode = "B001"
                        },
                        new
                        {
                            Id = new Guid("5d8a4b9e-25ed-44b4-8fbb-12b60fd19af8"),
                            Available = true,
                            BookId = new Guid("e889b64d-d435-4a6d-a95d-73c2ff37ee0e"),
                            CopyCode = "B002"
                        },
                        new
                        {
                            Id = new Guid("f46d8858-0b19-45cc-bc5a-c3a4a6fed77c"),
                            Available = true,
                            BookId = new Guid("e889b64d-d435-4a6d-a95d-73c2ff37ee0e"),
                            CopyCode = "B003"
                        },
                        new
                        {
                            Id = new Guid("ecbf8148-7f07-423d-b227-a2213e0b3509"),
                            Available = true,
                            BookId = new Guid("e889b64d-d435-4a6d-a95d-73c2ff37ee0e"),
                            CopyCode = "B004"
                        },
                        new
                        {
                            Id = new Guid("6e22fd39-bdd5-4756-8cea-306da06079e3"),
                            Available = true,
                            BookId = new Guid("b351e787-180d-4c99-8ad2-ce89d37106b2"),
                            CopyCode = "C001"
                        },
                        new
                        {
                            Id = new Guid("93c0f4db-a9a0-41fe-8925-02846a3b27d8"),
                            Available = true,
                            BookId = new Guid("b351e787-180d-4c99-8ad2-ce89d37106b2"),
                            CopyCode = "C002"
                        },
                        new
                        {
                            Id = new Guid("afdd9f71-81bc-44e6-9330-db498e36faf1"),
                            Available = true,
                            BookId = new Guid("b351e787-180d-4c99-8ad2-ce89d37106b2"),
                            CopyCode = "C003"
                        },
                        new
                        {
                            Id = new Guid("b7efe9e9-66f9-4dd9-8729-8eccc63c53e5"),
                            Available = true,
                            BookId = new Guid("b351e787-180d-4c99-8ad2-ce89d37106b2"),
                            CopyCode = "C004"
                        },
                        new
                        {
                            Id = new Guid("6bc145ad-87ca-437f-ac49-2106799cb4e2"),
                            Available = true,
                            BookId = new Guid("1d00dffc-57a9-4547-b74e-3fdf02827708"),
                            CopyCode = "D001"
                        },
                        new
                        {
                            Id = new Guid("418c8559-e10f-402d-851f-091f2636ad0d"),
                            Available = true,
                            BookId = new Guid("1d00dffc-57a9-4547-b74e-3fdf02827708"),
                            CopyCode = "D002"
                        },
                        new
                        {
                            Id = new Guid("ac9300dc-f2fa-43c3-8794-28d2a359563d"),
                            Available = true,
                            BookId = new Guid("1d00dffc-57a9-4547-b74e-3fdf02827708"),
                            CopyCode = "D003"
                        },
                        new
                        {
                            Id = new Guid("ff0fd245-4d4d-411e-a146-613673e3ceaa"),
                            Available = true,
                            BookId = new Guid("1d00dffc-57a9-4547-b74e-3fdf02827708"),
                            CopyCode = "D004"
                        },
                        new
                        {
                            Id = new Guid("2d8e7e57-a771-4e1b-9bee-f3a43dcfbc72"),
                            Available = true,
                            BookId = new Guid("7b66e07a-eaa0-468d-90dd-390ebf16bbf7"),
                            CopyCode = "E001"
                        },
                        new
                        {
                            Id = new Guid("bc2cb666-aac0-439f-b546-6c37135d7f45"),
                            Available = true,
                            BookId = new Guid("7b66e07a-eaa0-468d-90dd-390ebf16bbf7"),
                            CopyCode = "E002"
                        },
                        new
                        {
                            Id = new Guid("1cf1dcbf-9c4e-4aa9-8652-4e2ba50847d0"),
                            Available = true,
                            BookId = new Guid("7b66e07a-eaa0-468d-90dd-390ebf16bbf7"),
                            CopyCode = "E003"
                        },
                        new
                        {
                            Id = new Guid("fb938939-ea99-4f52-aa12-2668030cd62b"),
                            Available = true,
                            BookId = new Guid("7b66e07a-eaa0-468d-90dd-390ebf16bbf7"),
                            CopyCode = "E004"
                        });
                });

            modelBuilder.Entity("ApiBiblioteca.Domain.Models.Loan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Fines")
                        .HasColumnType("float");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("ApiBiblioteca.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ApiBiblioteca.Domain.Models.Address", b =>
                {
                    b.HasOne("ApiBiblioteca.Domain.Models.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("ApiBiblioteca.Domain.Models.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiBiblioteca.Domain.Models.BookLending", b =>
                {
                    b.HasOne("ApiBiblioteca.Domain.Models.Copy", "Copy")
                        .WithMany("BookLendings")
                        .HasForeignKey("CopyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiBiblioteca.Domain.Models.Loan", "Loan")
                        .WithMany("BookLendings")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Copy");

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("ApiBiblioteca.Domain.Models.Copy", b =>
                {
                    b.HasOne("ApiBiblioteca.Domain.Models.Book", "Book")
                        .WithMany("Copies")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("ApiBiblioteca.Domain.Models.Loan", b =>
                {
                    b.HasOne("ApiBiblioteca.Domain.Models.User", "User")
                        .WithMany("Loans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiBiblioteca.Domain.Models.Book", b =>
                {
                    b.Navigation("Copies");
                });

            modelBuilder.Entity("ApiBiblioteca.Domain.Models.Copy", b =>
                {
                    b.Navigation("BookLendings");
                });

            modelBuilder.Entity("ApiBiblioteca.Domain.Models.Loan", b =>
                {
                    b.Navigation("BookLendings");
                });

            modelBuilder.Entity("ApiBiblioteca.Domain.Models.User", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}