using CadastroCliente.Application.Comands;
using CadastroCliente.Application.DTOs;
using CadastroCliente.Application.Interface;
using CadastroCliente.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Application.Handler
{
    public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, ClienteDto>
    {
        private readonly IClienteRepository _clienteRepository;

        public GetClienteByIdQueryHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteDto> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.ObterPorIdAsync(request.Id);

            if (cliente == null) return null;

            return new ClienteDto
            {
                Id = cliente.Id,
                NomeRazaoSocial = cliente.NomeRazaoSocial,
                Documento = cliente.Documento,
                DataNascimento = cliente.DataNascimento,
                Telefone = cliente.Telefone,
                Email = cliente.Email,
                InscricaoEstadual = cliente.InscricaoEstadual,
                IsentoIE = cliente.IsentoIE,
                Cep = cliente.Endereco?.Cep,
                Rua = cliente.Endereco?.Rua,
                Numero = cliente.Endereco?.Numero,
                Bairro = cliente.Endereco?.Bairro,
                Cidade = cliente.Endereco?.Cidade,
                Estado = cliente.Endereco?.Estado
            };
        }
    }
}
    
