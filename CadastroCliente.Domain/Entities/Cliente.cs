using System.Text.RegularExpressions;

namespace CadastroCliente.Domain.Entities
{
    public class Cliente : Entity
    {
        protected Cliente() { }

        public string NomeRazaoSocial { get; private set; }
        public string Documento { get; private set; } // CPF ou CNPJ
        public DateTime? DataNascimento { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public Endereco Endereco { get; private set; }
        public string? InscricaoEstadual { get; private set; }
        public bool IsentoIE { get; private set; }

        public bool IsPessoaFisica => Documento.Length == 11;

        public Cliente(string nomeRazaoSocial, string documento, DateTime? dataNascimento,
                       string telefone, string email, Endereco endereco,
                       string? inscricaoEstadual = null, bool isentoIE = false)
        {
            NomeRazaoSocial = nomeRazaoSocial;
            Documento = documento;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
            InscricaoEstadual = isentoIE ? null : inscricaoEstadual;
            IsentoIE = isentoIE;

            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(NomeRazaoSocial))
                throw new ArgumentException("Nome/Razão Social é obrigatório.");

            if (string.IsNullOrWhiteSpace(Documento))
                throw new ArgumentException("CPF ou CNPJ é obrigatório.");

            if (IsPessoaFisica && (!DataNascimento.HasValue || CalcularIdade(DataNascimento.Value) < 18))
                throw new ArgumentException("Pessoa física deve ter pelo menos 18 anos.");

            if (!IsPessoaFisica && !IsentoIE && string.IsNullOrWhiteSpace(InscricaoEstadual))
                throw new ArgumentException("Pessoa jurídica deve informar IE ou marcar como isento.");

            if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("E-mail inválido.");
        }

        private int CalcularIdade(DateTime dataNascimento)
        {
            var idade = DateTime.Today.Year - dataNascimento.Year;
            if (dataNascimento.Date > DateTime.Today.AddYears(-idade)) idade--;
            return idade;
        }

        public void AtualizarDados(
            string nomeRazaoSocial,
            string telefone,
            string email,
            string? inscricaoEstadual,
            bool isentoIE,
            Endereco endereco)
        {
            NomeRazaoSocial = nomeRazaoSocial;
            Telefone = telefone;
            Email = email;
            IsentoIE = isentoIE;
            InscricaoEstadual = isentoIE ? null : inscricaoEstadual;
            Endereco = endereco;

            Validar();
        }
    }
}