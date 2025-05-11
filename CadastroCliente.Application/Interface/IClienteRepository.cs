using CadastroCliente.Domain.Entities;


namespace CadastroCliente.Application.Interface
{
    public interface IClienteRepository
    {
        Task AdicionarAsync(Cliente cliente);
        Task<Cliente?> ObterPorIdAsync(Guid id);
        Task AtualizarAsync(Cliente cliente);
        Task RemoverAsync(Guid id);
        Task<IEnumerable<Cliente>> ObterTodosAsync();

    }
}
