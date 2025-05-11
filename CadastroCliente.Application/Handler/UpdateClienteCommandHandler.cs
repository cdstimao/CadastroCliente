using CadastroCliente.Application.Comands;
using CadastroCliente.Application.Interface;
using CadastroCliente.Domain.Entities;
using MediatR;

namespace CadastroCliente.Application.Handler
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Unit>
    {
        private readonly IClienteRepository _clienteRepository;

        public UpdateClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Unit> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.ObterPorIdAsync(request.Id);
            if (cliente == null)
                throw new Exception("Cliente não encontrado.");

            cliente.AtualizarDados(
                request.NomeRazaoSocial,
                request.Telefone,
                request.Email,
                request.InscricaoEstadual,
                request.IsentoIE,
                new Endereco(
                    request.Cep,
                    request.Rua,
                    request.Numero,
                    request.Bairro,
                    request.Cidade,
                    request.Estado
                )
            );

            await _clienteRepository.AtualizarAsync(cliente);
            return Unit.Value;
        }
    }
}
