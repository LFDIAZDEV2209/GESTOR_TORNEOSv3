using GESTOR_TORNEOS.src.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GESTOR_TORNEOS.src.Shared.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        // Tabla
        builder.ToTable("Cities");
        
        // Clave primaria
        builder.HasKey(c => c.Id);
        
        // Propiedades
        builder.Property(c => c.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
            
        builder.Property(c => c.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();
        
        // Restricción UNIQUE en el nombre de la ciudad
        builder.HasIndex(c => c.Name).IsUnique();
        
        // Relación uno a muchos con Team
        builder.HasMany(c => c.Teams)
            .WithOne(t => t.City)
            .HasForeignKey(t => t.CityId)
            .OnDelete(DeleteBehavior.SetNull);
    }
} 