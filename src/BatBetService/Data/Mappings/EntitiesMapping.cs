using BatBetService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BatBetService.Data.Mappings
{
    public class EntitiesMapping
    {
        public class UserMap : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.ToTable("User");

                builder.Property(p => p.Name)
                        .HasColumnType("text")
                        .HasMaxLength(50)
                        .IsRequired();

                builder.Property(p => p.LastName)
                        .HasMaxLength(50)
                        .IsRequired();

                builder.Property(p => p.Email)
                        .HasColumnType("text")
                        .HasMaxLength(100)
                        .IsRequired();

                builder.Property(p => p.Password)
                        .HasColumnType("text")
                        .HasMaxLength(70)
                        .IsRequired();

                builder.Property(p => p.Country)
                        .HasColumnType("text")
                        .HasMaxLength(80)
                        .IsRequired();

                builder.Property(p => p.Address)
                        .HasColumnType("text")
                        .HasMaxLength(50)
                        .IsRequired();

                builder.Property(p => p.State)
                        .HasColumnType("text")
                        .HasMaxLength(30)
                        .IsRequired();

                builder.Property(p => p.StateAcronym)
                        .HasColumnType("text")
                        .HasMaxLength(2);

                builder.Property(p => p.Complement)
                        .HasColumnType("text")
                        .HasMaxLength(20)
                        .IsRequired();

                builder.Property(p => p.Age)
                        .HasColumnType("integer")
                        .HasMaxLength(3)
                        .IsRequired();

                builder.Property(p => p.DocumentNumber)
                        .HasColumnType("text")
                        .HasMaxLength(50)
                        .IsRequired();

                builder.Property(p => p.Balance)
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.0);

                builder.Property(p => p.CreatedAt)
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(DateTime.UtcNow);

                builder.Property(p => p.UpdatedAt)
                        .HasColumnType("timestamp with time zone");

                builder.Property(p => p.IsBlocked)
                        .HasColumnType("boolean")
                        .IsRequired();

                builder.Property(p => p.BlockReason)
                        .HasColumnType("text")
                        .HasMaxLength(80);
            }
        }

        public class BetMap : IEntityTypeConfiguration<Bet>
        {
            public void Configure(EntityTypeBuilder<Bet> builder)
            {
                builder.ToTable("Bet");

                builder.Property(p => p.Amount)
                        .HasColumnType("double precision")
                        .HasMaxLength(999999999)
                        .IsRequired();

                builder.Property(p => p.Status);

                builder.Property(p => p.PlatformFee)
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.00);

                builder.Property(p => p.CreatedAt)
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(DateTime.UtcNow);

                builder.Property(p => p.UpdatedAt)
                        .HasColumnType("timestamp with time zone");

                builder.Property(p => p.DueDate)
                        .HasColumnType("timestamp with time zone");
            }
        }

        public class GameMap : IEntityTypeConfiguration<Game>
        {
            public void Configure(EntityTypeBuilder<Game> builder)
            {
                builder.ToTable("Game");

                builder.Property(p => p.Name)
                        .HasColumnType("text")
                        .HasMaxLength(30)
                        .IsRequired();

                builder.Property(p => p.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValue(DateTime.UtcNow);

                builder.Property(p => p.IsActive)
                        .HasColumnType("boolean");
            }
        }

        public class CategoryMap : IEntityTypeConfiguration<Category>
        {
            public void Configure(EntityTypeBuilder<Category> builder)
            {
                builder.ToTable("Category");

                builder.Property(p => p.Name)
                        .HasColumnType("text")
                        .HasMaxLength(15)
                        .IsRequired();

                builder.Property(p => p.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValue(DateTime.UtcNow);

                builder.Property(p => p.UpdatedAt)
                        .HasColumnType("timestamp with time zone");

                builder.Property(p => p.ImageUrl)
                        .HasColumnType("text")
                        .IsRequired(false);
            }
        }

        public class AvailableBetMap : IEntityTypeConfiguration<AvailableBet>
        {
            public void Configure(EntityTypeBuilder<AvailableBet> builder)
            {
                builder.ToTable("AvailableBet");

                builder.Property(p => p.Name)
                        .HasColumnType("text")
                        .HasMaxLength(50)
                        .IsRequired();

                builder.Property(p => p.MinValue)
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.01)
                        .IsRequired();

                builder.Property(p => p.MaxValue)
                        .HasColumnType("double precision")
                        .HasMaxLength(999999999)
                        .IsRequired();

                builder.Property(p => p.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValue(DateTime.UtcNow);

                builder.Property(p => p.LimitDate)
                        .HasColumnType("timestamp with time zone");
            }
        }
    }
}
