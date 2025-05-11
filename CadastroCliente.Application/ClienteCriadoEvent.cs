using MediatR;

namespace CadastroCliente.Application
{
    public record ClienteCriadoEvent(Guid ClienteId, string NomeRazaoSocial) : INotification;

}
