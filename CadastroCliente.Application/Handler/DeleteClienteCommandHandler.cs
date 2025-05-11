using CadastroCliente.Application.Comands;
using CadastroCliente.Application.Interface;
using MediatR;

namespace CadastroCliente.Application.Handler
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Unit>
    {
        private readonly IClienteRepository _clienteRepository;

        public DeleteClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            await _clienteRepository.RemoverAsync(request.Id);
            return Unit.Value; 
        }
    }
}
