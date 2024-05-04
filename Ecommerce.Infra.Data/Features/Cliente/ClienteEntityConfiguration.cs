using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infra.Data.Features
{
    public class ClienteEntityConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(cliente => cliente.Id);

            builder.Property(cliente => cliente.Email).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
            builder.Property(cliente => cliente.Senha).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(cliente => cliente.Nome).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();

            //Relacionamento
            builder.HasOne(c => c.Carrinho).WithMany().HasForeignKey(c => c.CarrinhoId).IsRequired();
            builder.HasMany(c => c.ComprasRealizadas).WithOne(cr => cr.Cliente);
        }
    }
}

