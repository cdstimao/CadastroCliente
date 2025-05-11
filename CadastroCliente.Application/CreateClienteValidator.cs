using CadastroCliente.Application.Comands;
using FluentValidation;

namespace CadastroCliente.Application
{
    public class CreateClienteValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteValidator()
        {
            RuleFor(c => c.NomeRazaoSocial).NotEmpty().WithMessage("Nome/Razão Social é obrigatório");
            RuleFor(c => c.Documento).NotEmpty().Length(11, 14).WithMessage("CPF/CNPJ inválido");
            RuleFor(c => c.Email).EmailAddress().When(c => !string.IsNullOrWhiteSpace(c.Email));
            RuleFor(c => c.Telefone).NotEmpty();
            RuleFor(c => c.Cep).NotEmpty();
            RuleFor(c => c.Estado).Length(2).WithMessage("Estado deve ter 2 caracteres");
            RuleFor(c => c.DataNascimento)
                .Must(BeAdult).When(c => c.Documento.Length == 11)
                .WithMessage("Cliente deve ter no mínimo 18 anos.");
            RuleFor(c => c.InscricaoEstadual)
                .NotEmpty().When(c => c.Documento.Length == 14 && !c.IsentoIE)
                .WithMessage("Informe a Inscrição Estadual ou marque como isento.");
        }

        private bool BeAdult(DateTime? dataNascimento)
        {
            if (dataNascimento == null) return false;
            var idade = DateTime.Today.Year - dataNascimento.Value.Year;
            if (dataNascimento.Value.Date > DateTime.Today.AddYears(-idade)) idade--;
            return idade >= 18;
        }
    }
}