using GerenciadorCondominios.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.DAL.Mapeamentos
{
    public class HistoricoRecursosMap : IEntityTypeConfiguration<HistoricoRecursos>
    {
        public void Configure(EntityTypeBuilder<HistoricoRecursos> builder)
        {
            builder.HasKey(h => h.HistoricoRecursosId);
            builder.Property(h => h.Valor).IsRequired();
            builder.Property(h => h.Tipo).IsRequired();
            builder.Property(h => h.Dia).IsRequired();
            builder.Property(h => h.MesId).IsRequired();
            builder.Property(h => h.Ano).IsRequired();


            builder.HasOne(h => h.Mes).WithMany(h => h.HistoricoRecursos).HasForeignKey(h => h.MesId);

            builder.ToTable("HistoricoRecursos");


        }
    }


}
