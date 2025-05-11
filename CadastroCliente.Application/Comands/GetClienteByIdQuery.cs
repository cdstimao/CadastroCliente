using CadastroCliente.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Application.Comands
{
    public class GetClienteByIdQuery : IRequest<ClienteDto>
    {
        public Guid Id { get; set; }

        public GetClienteByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
