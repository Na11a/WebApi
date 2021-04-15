﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApi.TaskItem;

namespace WebApi.Migrations
{
    [DbContext(typeof(TasktoDoContext))]
    [Migration("20210414124757_deleteTasktoDo_ListId")]
    partial class deleteTasktoDo_ListId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("WebApi.Models.TaskList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_task_list");

                    b.ToTable("task_list");
                });

            modelBuilder.Entity("WebApi.Models.TasktoDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Desc")
                        .HasColumnType("text")
                        .HasColumnName("desc");

                    b.Property<bool>("Done")
                        .HasColumnType("boolean")
                        .HasColumnName("done");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("due_date");

                    b.Property<int?>("TaskListId")
                        .HasColumnType("integer")
                        .HasColumnName("task_list_id");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_taskto_dos");

                    b.HasIndex("TaskListId")
                        .HasDatabaseName("ix_taskto_dos_task_list_id");

                    b.ToTable("taskto_dos");
                });

            modelBuilder.Entity("WebApi.Models.TasktoDo", b =>
                {
                    b.HasOne("WebApi.Models.TaskList", "TaskList")
                        .WithMany("TasktoDo")
                        .HasForeignKey("TaskListId")
                        .HasConstraintName("fk_taskto_dos_task_list_task_list_id");

                    b.Navigation("TaskList");
                });

            modelBuilder.Entity("WebApi.Models.TaskList", b =>
                {
                    b.Navigation("TasktoDo");
                });
#pragma warning restore 612, 618
        }
    }
}
