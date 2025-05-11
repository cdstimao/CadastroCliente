using CadastroCliente.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Infrastructure.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeRazaoSocial)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Documento)
                .IsRequired()
                .HasMaxLength(14); // CPF ou CNPJ

            builder.Property(c => c.DataNascimento);

            builder.Property(c => c.Telefone)
                .HasMaxLength(20);

            builder.Property(c => c.Email)
                .HasMaxLength(100);

            builder.Property(c => c.InscricaoEstadual)
                .HasMaxLength(30);

            builder.Property(c => c.IsentoIE);

            // Mapeamento de Endereço (Value Object)
            builder.OwnsOne(c => c.Endereco, endereco =>
            {
                endereco.Property(e => e.Cep)
                    .HasColumnName("Cep")
                    .HasMaxLength(10);

                endereco.Property(e => e.Rua)
                    .HasColumnName("Rua")
                    .HasMaxLength(100);

                endereco.Property(e => e.Numero)
                    .HasColumnName("Numero")
                    .HasMaxLength(10);

                endereco.Property(e => e.Bairro)
                    .HasColumnName("Bairro")
                    .HasMaxLength(50);

                endereco.Property(e => e.Cidade)
                    .HasColumnName("Cidade")
                    .HasMaxLength(50);

                endereco.Property(e => e.Estado)
                    .HasColumnName("Estado")
                    .HasMaxLength(2);
            });
        }
    }
}