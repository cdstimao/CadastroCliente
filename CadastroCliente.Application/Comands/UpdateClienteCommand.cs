using MediatR;
using System;

namespace CadastroCliente.Application.Comands
{
    public class UpdateClienteCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string Documento { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string InscricaoEstadual { get; set; }
        public bool IsentoIE { get; set; }

        // Endereço
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
