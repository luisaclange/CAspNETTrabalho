using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIDeslocamento.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace APIDeslocamento.Data.Mapping
{
    public class DeslocamentoConfiguration : IEntityTypeConfiguration<Deslocamento>
    {
        public void Configure(EntityTypeBuilder<Deslocamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Deslocamento");

            builder.Property(p => p.CarroId)
                .IsRequired()
                .HasColumnName("CarroId")
                .HasMaxLength(10);

            builder.Property(p => p.CondutorId)
                .IsRequired()
                .HasColumnName("CondutorId")
                .HasMaxLength(10);

            builder.Property(p => p.ClienteId)
                .IsRequired()
                .HasColumnName("ClienteId")
                .HasMaxLength(10);

            builder.Property(p => p.DataHoraInicio)
                .IsRequired()
                .HasColumnName("DataHoraInicio")
                .HasMaxLength(10);

            builder.Property(p => p.QuilometragemInicial)
                .IsRequired()
                .HasColumnName("QuilometragemInicial")
                .HasMaxLength(50);

            builder.Property(p => p.Observacao)
                .HasColumnName("Observacao")
                .HasMaxLength(500)
                .HasDefaultValue("sem observação");

            builder.Property(p => p.DataHoraFim)
                .HasColumnName("DataHoraFim")
                .HasMaxLength(10);

            builder.Property(p => p.QuilometragemFinal)
                .HasColumnName("QuilometragemFinal")
                .HasMaxLength(50);
        }

    }
}
