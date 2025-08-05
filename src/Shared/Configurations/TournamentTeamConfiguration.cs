using GESTOR_TORNEOS.src.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GESTOR_TORNEOS.src.Shared.Configurations;

public class TournamentTeamConfiguration : IEntityTypeConfiguration<TournamentTeam>
{
    public void Configure(EntityTypeBuilder<TournamentTeam> builder)
    {
        // Tabla
        builder.ToTable("TournamentTeams");
        
        // Clave primaria compuesta
        builder.HasKey(tt => new { tt.TournamentId, tt.TeamId });
        
        // Propiedades
        builder.Property(tt => tt.TournamentId)
            .HasColumnName("tournament_id");
            
        builder.Property(tt => tt.TeamId)
            .HasColumnName("team_id");
        
        // Relación con Tournament
        builder.HasOne(tt => tt.Tournament)
            .WithMany(t => t.TournamentTeams)
            .HasForeignKey(tt => tt.TournamentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Relación con Team
        builder.HasOne(tt => tt.Team)
            .WithMany(team => team.TournamentTeams)
            .HasForeignKey(tt => tt.TeamId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 