using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDSample.Domain.Models;

namespace DDDSample.Infra.Data.Mappings
{
    public class AdvMap : IEntityTypeConfiguration<Adv>
    {
        public void Configure(EntityTypeBuilder<Adv> builder)
        {
            builder.Property(c => c.ID)
                .HasColumnName("ID").
                ValueGeneratedOnAdd();

            builder.Property(c => c.Marca)
                .HasColumnType("varchar(45)")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(c => c.Modelo)
                .HasColumnType("varchar(45)")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(c => c.Versao)
                .HasColumnType("varchar(45)")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(c => c.Ano)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Quilometragem)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Observacao)
                .HasColumnType("text")
                .HasMaxLength(450)
                .IsRequired();
                
        }
    }
}
