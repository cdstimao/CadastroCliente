using CadastroCliente.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CadastroCliente.Domain.Entities;

namespace CadastroCliente.Tests
{
    public class UnitTest1
    {
        private readonly ApplicationDbContext _context;

        public UnitTest1()
        {
            // Configuração do banco de dados em memória
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();
        }
        [Fact]
        public async Task AdicionarCliente_ClienteValido_DeveSalvarNoBanco()
        {
            // Arrange
            var cliente = new Cliente("Cliente Teste", "12345678901", new DateTime(2010, 1, 1), "999999999", "teste@teste.com", new Endereco("Rua Teste", "123", "Bairro", "Cidade", "SP", "12345678"));

            // Act
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

            // Assert
            var clienteSalvo = await _context.Clientes.FirstOrDefaultAsync(c => c.Documento == "12345678901");
            Assert.NotNull(clienteSalvo);
            Assert.Equal("Cliente Teste", clienteSalvo.NomeRazaoSocial);
        }
    }
}