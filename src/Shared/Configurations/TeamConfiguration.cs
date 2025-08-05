using GESTOR_TORNEOS.src.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GESTOR_TORNEOS.src.Shared.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        // Tabla
        builder.ToTable("Teams");
        
        // Clave primaria
        builder.HasKey(t => t.Id);
        
        // Propiedades
        builder.Property(t => t.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
            
        builder.Property(t => t.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();
            
        builder.Property(t => t.CityId)
            .HasColumnName("city_id");
        
        // Relación con City (muchos a uno)
        builder.HasOne(t => t.City)
            .WithMany(c => c.Teams)
            .HasForeignKey(t => t.CityId)
            .OnDelete(DeleteBehavior.SetNull);
        
        // Relación uno a muchos con TournamentTeam
        builder.HasMany(t => t.TournamentTeams)
            .WithOne(tt => tt.Team)
            .HasForeignKey(tt => tt.TeamId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Relación uno a muchos con Player
        builder.HasMany(t => t.Players)
            .WithOne()
            .HasForeignKey("team_id")
            .OnDelete(DeleteBehavior.SetNull);
        
        // Relación uno a muchos con Staff
        builder.HasMany(t => t.Staff)
            .WithOne()
            .HasForeignKey("team_id")
            .OnDelete(DeleteBehavior.SetNull);
    }
} 