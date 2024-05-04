using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Data.Features
{
    public class ProdutoEntityConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(produto => produto.Id);

            builder.Property(funcionario => funcionario.Codigo).HasColumnType("int").IsRequired();
            builder.Property(funcionario => funcionario.Preco).HasColumnType("float").IsRequired();
            builder.Property(funcionario => funcionario.Nome).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            
        }
    }
}

