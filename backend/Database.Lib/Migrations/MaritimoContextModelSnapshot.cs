﻿// <auto-generated />
using System;
using Database.Lib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Database.Lib.Migrations
{
    [DbContext(typeof(MaritimoContext))]
    partial class MaritimoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Database.Lib.Message", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<int?>("StationId")
                        .HasColumnType("integer");

                    b.Property<byte?>("aid_type")
                        .HasColumnType("smallint");

                    b.Property<byte?>("ais_version")
                        .HasColumnType("smallint");

                    b.Property<bool?>("assigned")
                        .HasColumnType("boolean");

                    b.Property<bool?>("band_flag")
                        .HasColumnType("boolean");

                    b.Property<string>("call_sign")
                        .HasColumnType("text");

                    b.Property<float?>("course_over_ground")
                        .HasColumnType("real");

                    b.Property<bool?>("cs_unit")
                        .HasColumnType("boolean");

                    b.Property<string>("destination")
                        .HasColumnType("text");

                    b.Property<int?>("dimension_to_bow")
                        .HasColumnType("integer");

                    b.Property<byte?>("dimension_to_port")
                        .HasColumnType("smallint");

                    b.Property<byte?>("dimension_to_starboard")
                        .HasColumnType("smallint");

                    b.Property<int?>("dimension_to_stern")
                        .HasColumnType("integer");

                    b.Property<bool?>("display_flag")
                        .HasColumnType("boolean");

                    b.Property<float?>("draught")
                        .HasColumnType("real");

                    b.Property<bool?>("dsc_flag")
                        .HasColumnType("boolean");

                    b.Property<bool?>("dte")
                        .HasColumnType("boolean");

                    b.Property<byte?>("eta_day")
                        .HasColumnType("smallint");

                    b.Property<byte?>("eta_hour")
                        .HasColumnType("smallint");

                    b.Property<byte?>("eta_minute")
                        .HasColumnType("smallint");

                    b.Property<byte?>("eta_month")
                        .HasColumnType("smallint");

                    b.Property<bool?>("gnss_position_status")
                        .HasColumnType("boolean");

                    b.Property<long?>("imo_number")
                        .HasColumnType("bigint");

                    b.Property<float?>("latitude")
                        .HasColumnType("real");

                    b.Property<float?>("longitude")
                        .HasColumnType("real");

                    b.Property<float?>("magnetic_declination")
                        .HasColumnType("real");

                    b.Property<byte?>("manuever_indicator")
                        .HasColumnType("smallint");

                    b.Property<bool?>("message_22_flag")
                        .HasColumnType("boolean");

                    b.Property<byte>("message_type")
                        .HasColumnType("smallint");

                    b.Property<long>("mmsi")
                        .HasColumnType("bigint");

                    b.Property<long?>("mothership_mmsi")
                        .HasColumnType("bigint");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<byte?>("navigation_status")
                        .HasColumnType("smallint");

                    b.Property<bool?>("off_position")
                        .HasColumnType("boolean");

                    b.Property<bool?>("position_accuracy")
                        .HasColumnType("boolean");

                    b.Property<byte?>("position_fix_type")
                        .HasColumnType("smallint");

                    b.Property<bool?>("raim_flag")
                        .HasColumnType("boolean");

                    b.Property<float>("rate_of_turn")
                        .HasColumnType("real");

                    b.Property<byte>("repeat_indicator")
                        .HasColumnType("smallint");

                    b.Property<byte?>("ship_type")
                        .HasColumnType("smallint");

                    b.Property<string>("source_id")
                        .HasColumnType("text");

                    b.Property<string>("source_ip_address")
                        .HasColumnType("text");

                    b.Property<float?>("speed_over_ground")
                        .HasColumnType("real");

                    b.Property<string>("station_name")
                        .HasColumnType("text");

                    b.Property<string>("station_operator_name")
                        .HasColumnType("text");

                    b.Property<byte?>("timestamp")
                        .HasColumnType("smallint");

                    b.Property<int?>("true_heading")
                        .HasColumnType("integer");

                    b.Property<DateTime>("updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte?>("utc_day")
                        .HasColumnType("smallint");

                    b.Property<byte?>("utc_hour")
                        .HasColumnType("smallint");

                    b.Property<byte?>("utc_minute")
                        .HasColumnType("smallint");

                    b.Property<byte?>("utc_month")
                        .HasColumnType("smallint");

                    b.Property<byte?>("utc_second")
                        .HasColumnType("smallint");

                    b.Property<int?>("utc_year")
                        .HasColumnType("integer");

                    b.Property<string>("vendor_id")
                        .HasColumnType("text");

                    b.Property<bool?>("virtual_aid_flag")
                        .HasColumnType("boolean");

                    b.HasKey("id");

                    b.HasIndex("StationId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Database.Lib.ObjectData", b =>
                {
                    b.Property<long>("mmsi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("mmsi"));

                    b.Property<int?>("StationId")
                        .HasColumnType("integer");

                    b.Property<byte?>("aid_type")
                        .HasColumnType("smallint");

                    b.Property<byte?>("ais_version")
                        .HasColumnType("smallint");

                    b.Property<bool?>("assigned")
                        .HasColumnType("boolean");

                    b.Property<bool?>("band_flag")
                        .HasColumnType("boolean");

                    b.Property<string>("call_sign")
                        .HasColumnType("text");

                    b.Property<int?>("country_code")
                        .HasColumnType("integer");

                    b.Property<float?>("course_over_ground")
                        .HasColumnType("real");

                    b.Property<bool?>("cs_unit")
                        .HasColumnType("boolean");

                    b.Property<string>("destination")
                        .HasColumnType("text");

                    b.Property<int?>("dimension_to_bow")
                        .HasColumnType("integer");

                    b.Property<byte?>("dimension_to_port")
                        .HasColumnType("smallint");

                    b.Property<byte?>("dimension_to_starboard")
                        .HasColumnType("smallint");

                    b.Property<int?>("dimension_to_stern")
                        .HasColumnType("integer");

                    b.Property<bool?>("display_flag")
                        .HasColumnType("boolean");

                    b.Property<float?>("draught")
                        .HasColumnType("real");

                    b.Property<bool?>("dsc_flag")
                        .HasColumnType("boolean");

                    b.Property<bool?>("dte")
                        .HasColumnType("boolean");

                    b.Property<byte?>("eta_day")
                        .HasColumnType("smallint");

                    b.Property<byte?>("eta_hour")
                        .HasColumnType("smallint");

                    b.Property<byte?>("eta_minute")
                        .HasColumnType("smallint");

                    b.Property<byte?>("eta_month")
                        .HasColumnType("smallint");

                    b.Property<bool?>("gnss_position_status")
                        .HasColumnType("boolean");

                    b.Property<long?>("imo_number")
                        .HasColumnType("bigint");

                    b.Property<float?>("latitude")
                        .HasColumnType("real");

                    b.Property<float?>("longitude")
                        .HasColumnType("real");

                    b.Property<float?>("magnetic_declination")
                        .HasColumnType("real");

                    b.Property<byte?>("manuever_indicator")
                        .HasColumnType("smallint");

                    b.Property<bool?>("message_22_flag")
                        .HasColumnType("boolean");

                    b.Property<long?>("mothership_mmsi")
                        .HasColumnType("bigint");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<byte?>("navigation_status")
                        .HasColumnType("smallint");

                    b.Property<int?>("object_type")
                        .HasColumnType("integer");

                    b.Property<bool?>("off_position")
                        .HasColumnType("boolean");

                    b.Property<bool?>("position_accuracy")
                        .HasColumnType("boolean");

                    b.Property<byte?>("position_fix_type")
                        .HasColumnType("smallint");

                    b.Property<bool?>("raim_flag")
                        .HasColumnType("boolean");

                    b.Property<float>("rate_of_turn")
                        .HasColumnType("real");

                    b.Property<byte?>("ship_type")
                        .HasColumnType("smallint");

                    b.Property<string>("source_id")
                        .HasColumnType("text");

                    b.Property<string>("source_ip_address")
                        .HasColumnType("text");

                    b.Property<float?>("speed_over_ground")
                        .HasColumnType("real");

                    b.Property<string>("station_name")
                        .HasColumnType("text");

                    b.Property<string>("station_operator_name")
                        .HasColumnType("text");

                    b.Property<byte?>("timestamp")
                        .HasColumnType("smallint");

                    b.Property<int?>("true_heading")
                        .HasColumnType("integer");

                    b.Property<DateTime>("updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte?>("utc_day")
                        .HasColumnType("smallint");

                    b.Property<byte?>("utc_hour")
                        .HasColumnType("smallint");

                    b.Property<byte?>("utc_minute")
                        .HasColumnType("smallint");

                    b.Property<byte?>("utc_month")
                        .HasColumnType("smallint");

                    b.Property<byte?>("utc_second")
                        .HasColumnType("smallint");

                    b.Property<int?>("utc_year")
                        .HasColumnType("integer");

                    b.Property<string>("vendor_id")
                        .HasColumnType("text");

                    b.Property<bool?>("virtual_aid_flag")
                        .HasColumnType("boolean");

                    b.HasKey("mmsi");

                    b.HasIndex("StationId");

                    b.HasIndex("object_type");

                    b.ToTable("Objects");
                });

            modelBuilder.Entity("Database.Lib.Photo", b =>
                {
                    b.Property<long>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("PhotoId"));

                    b.Property<string>("Author")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Filename")
                        .HasColumnType("text");

                    b.Property<string>("FilenameThumbnail")
                        .HasColumnType("text");

                    b.Property<int?>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("Homepage")
                        .HasColumnType("text");

                    b.Property<int?>("StationId")
                        .HasColumnType("integer");

                    b.Property<int?>("Width")
                        .HasColumnType("integer");

                    b.Property<long?>("mmsi")
                        .HasColumnType("bigint");

                    b.HasKey("PhotoId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Database.Lib.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StationId"));

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EquipmentDescription")
                        .HasColumnType("text");

                    b.Property<string>("Homepage")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastMessageUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float?>("Latitude")
                        .HasColumnType("real");

                    b.Property<float?>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SourceId")
                        .HasColumnType("text");

                    b.Property<int>("StationOperatorId")
                        .HasColumnType("integer");

                    b.HasKey("StationId");

                    b.HasIndex("StationOperatorId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("Database.Lib.StationAddress", b =>
                {
                    b.Property<int>("StationAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StationAddressId"));

                    b.Property<string>("SourceIpAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StationId")
                        .HasColumnType("integer");

                    b.HasKey("StationAddressId");

                    b.HasIndex("StationId");

                    b.ToTable("StationAddresses");
                });

            modelBuilder.Entity("Database.Lib.StationOperator", b =>
                {
                    b.Property<int>("StationOperatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StationOperatorId"));

                    b.Property<string>("Homepage")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("StationOperatorId");

                    b.ToTable("StationOperators");
                });

            modelBuilder.Entity("Database.Lib.Message", b =>
                {
                    b.HasOne("Database.Lib.Station", "Station")
                        .WithMany()
                        .HasForeignKey("StationId");

                    b.Navigation("Station");
                });

            modelBuilder.Entity("Database.Lib.ObjectData", b =>
                {
                    b.HasOne("Database.Lib.Station", "Station")
                        .WithMany()
                        .HasForeignKey("StationId");

                    b.Navigation("Station");
                });

            modelBuilder.Entity("Database.Lib.Station", b =>
                {
                    b.HasOne("Database.Lib.StationOperator", "StationOperator")
                        .WithMany("Stations")
                        .HasForeignKey("StationOperatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StationOperator");
                });

            modelBuilder.Entity("Database.Lib.StationAddress", b =>
                {
                    b.HasOne("Database.Lib.Station", "Station")
                        .WithMany("StationAddresses")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");
                });

            modelBuilder.Entity("Database.Lib.Station", b =>
                {
                    b.Navigation("StationAddresses");
                });

            modelBuilder.Entity("Database.Lib.StationOperator", b =>
                {
                    b.Navigation("Stations");
                });
#pragma warning restore 612, 618
        }
    }
}
