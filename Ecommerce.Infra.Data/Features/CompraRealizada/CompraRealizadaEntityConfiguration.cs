using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Data.Features
{
    public class CompraRealizadaEntityConfiguration : IEntityTypeConfiguration<CompraRealizada>
    {
        public void Configure(EntityTypeBuilder<CompraRealizada> builder)
        {
            builder.ToTable("CompraRealizadas");

            builder.HasKey(comprarealizada => comprarealizada.Id);

            builder.Property(comprarealizada => comprarealizada.Data).HasColumnType("datetime2").IsRequired();
            

            //Relacionamento
            builder.HasMany(cr => cr.Produtos).WithOne();
            builder.HasOne(cr => cr.Cliente).WithMany(c => c.ComprasRealizadas).HasForeignKey(cr => cr.ClienteId);
            

        }

    }

}
