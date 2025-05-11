using MediatR;

namespace CadastroCliente.Application.Comands
{


    public record CreateClienteCommand(
        string NomeRazaoSocial,
        string Documento,
        DateTime? DataNascimento,
        string Telefone,
        string Email,
        string Cep,
        string Rua,
        string Numero,
        string Bairro,
        string Cidade,
        string Estado,
        string? InscricaoEstadual,
        bool IsentoIE
    ) : IRequest<Guid>;

}
