﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BAMTriviaProject2.DAL
{
    public partial class BAMTriviaProject2Context : DbContext
    {
        public BAMTriviaProject2Context()
        {
        }

        public BAMTriviaProject2Context(DbContextOptions<BAMTriviaProject2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<QuizResults> QuizResults { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Tusers> Tusers { get; set; }
        public virtual DbSet<UserQuizzes> UserQuizzes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK__Answers__C69006283982B839");

                entity.ToTable("Answers", "TP2");

                entity.Property(e => e.Aid).HasColumnName("AId");

                entity.Property(e => e.Aanswer)
                    .IsRequired()
                    .HasColumnName("AAnswer")
                    .HasMaxLength(500);

                entity.Property(e => e.Qid).HasColumnName("QId");

                entity.HasOne(d => d.Q)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.Qid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.Qid)
                    .HasName("PK__Question__CAB1462B843E6F07");

                entity.ToTable("Questions", "TP2");

                entity.Property(e => e.Qid).HasColumnName("QId");

                entity.Property(e => e.QaverageReview)
                    .HasColumnName("QAverageReview")
                    .HasColumnType("decimal(6, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Qcategory)
                    .IsRequired()
                    .HasColumnName("QCategory")
                    .HasMaxLength(100);

                entity.Property(e => e.Qrating)
                    .HasColumnName("QRating")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Qtype)
                    .IsRequired()
                    .HasColumnName("QType")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('Multiple')");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quiz", "TP2");

                entity.Property(e => e.QuizDifficulty).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<QuizResults>(entity =>
            {
                entity.HasKey(e => new { e.QuizId, e.Qid })
                    .HasName("PK__QuizResu__27E9BAEC94B58AD8");

                entity.ToTable("QuizResults", "TP2");

                entity.Property(e => e.Qid).HasColumnName("QId");

                entity.HasOne(d => d.Q)
                    .WithMany(p => p.QuizResults)
                    .HasForeignKey(d => d.Qid)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.QuizResults)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasKey(e => e.Rid)
                    .HasName("PK__Reviews__CAFF40D28C60442B");

                entity.ToTable("Reviews", "TP2");

                entity.Property(e => e.Rid).HasColumnName("RId");

                entity.Property(e => e.Qid).HasColumnName("QId");

                entity.Property(e => e.Rratings).HasColumnName("RRatings");

                entity.HasOne(d => d.Q)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Qid)
                    .HasConstraintName("FK_Reviews_Question_QId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reviews_User_UserId");
            });

            modelBuilder.Entity<Tusers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__TUsers__1788CC4C2EA47E62");

                entity.ToTable("TUsers", "TP2");

                entity.HasIndex(e => e.CreditCardNumber)
                    .HasName("UQ__TUsers__315DB925875D2224")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__TUsers__536C85E4CCDCF406")
                    .IsUnique();

                entity.Property(e => e.AccountType).HasDefaultValueSql("((0))");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Pw)
                    .IsRequired()
                    .HasColumnName("PW")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<UserQuizzes>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.QuizId })
                    .HasName("PK__UserQuiz__EF3CE6A49413D32A");

                entity.ToTable("UserQuizzes", "TP2");

                entity.Property(e => e.QuizDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserQuizzes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserQuizes_User_UserId");
            });
        }
    }
}