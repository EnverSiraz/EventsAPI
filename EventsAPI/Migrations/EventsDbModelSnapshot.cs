﻿// <auto-generated />
using System;
using EventsAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventsAPI.Migrations
{
    [DbContext(typeof(EventsDb))]
    partial class EventsDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EventsAPI.Models.ORMs.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EventsAPI.Models.ORMs.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EventCoverUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventEndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventStartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventTypes")
                        .HasColumnType("int");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventsAPI.Models.ORMs.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PlaceAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceMapUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlacePhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("EventsAPI.Models.ORMs.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentMethods")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("EventsAPI.Models.ORMs.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TicketQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TicketType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("EventsAPI.Models.ORMs.Event", b =>
                {
                    b.HasOne("EventsAPI.Models.ORMs.Place", "Place")
                        .WithMany("Events")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("EventsAPI.Models.ORMs.Purchase", b =>
                {
                    b.HasOne("EventsAPI.Models.ORMs.Customer", "Customer")
                        .WithMany("Purchases")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("EventsAPI.Models.ORMs.Ticket", b =>
                {
                    b.HasOne("EventsAPI.Models.ORMs.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventsAPI.Models.ORMs.Purchase", "Purchase")
                        .WithMany("Ticket")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("EventsAPI.Models.ORMs.Customer", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("EventsAPI.Models.ORMs.Event", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("EventsAPI.Models.ORMs.Place", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("EventsAPI.Models.ORMs.Purchase", b =>
                {
                    b.Navigation("Ticket");
                });
#pragma warning restore 612, 618
        }
    }
}
