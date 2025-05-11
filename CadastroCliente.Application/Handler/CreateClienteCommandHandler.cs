using MediatR;
using CadastroCliente.Domain.Entities;
using CadastroCliente.Application.Interface;
using CadastroCliente.Application.Comands;

namespace CadastroCliente.Application.Handler
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Guid>
    {
        private readonly IClienteRepository _clienteRepository;

        public CreateClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Guid> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            // Criar o objeto de Endereço
            var endereco = new Endereco(
                request.Cep,
                request.Rua,
                request.Numero,
                request.Bairro,
                request.Cidade,
                request.Estado
            );

            // Criar o cliente
            var cliente = new Cliente(
                request.NomeRazaoSocial,
                request.Documento,
                request.DataNascimento,
                request.Telefone,
                request.Email,
                endereco,
                request.InscricaoEstadual,
                request.IsentoIE
            );

            await _clienteRepository.AdicionarAsync(cliente);
            return cliente.Id;
        }
    }
}
