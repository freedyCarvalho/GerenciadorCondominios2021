using GerenciadorCondominios.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.DAL.Mapeamentos
{
    public class ServicoPredioMap : IEntityTypeConfiguration<ServicoPredio>
    {
        public void Configure(EntityTypeBuilder<ServicoPredio> builder)
        {
            builder.HasKey(s => s.ServicoId);
            builder.Property(s => s.DataExecucao).IsRequired();
            builder.Property(s => s.ServicoId).IsRequired();

            builder.HasOne(s => s.Servico).WithMany(s => s.ServicoPredios).HasForeignKey(s => s.ServicoId);

            builder.ToTable("ServicoPredios");
        }
    }
}
