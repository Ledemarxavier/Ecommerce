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
    public class FuncionarioEntityConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionarios");

            builder.HasKey(funcionario => funcionario.Id);

            builder.Property(funcionario => funcionario.Email).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
            builder.Property(funcionario => funcionario.Cargo).HasColumnType("int").HasConversion<int>().IsRequired();
            builder.Property(funcionario => funcionario.Senha).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(funcionario => funcionario.Nome).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(funcionario => funcionario.Nivel).HasColumnType("int").HasConversion<int>().IsRequired();



        }
    }
}
