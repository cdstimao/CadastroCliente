using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Application.Comands
{
    public class DeleteClienteCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteClienteCommand(Guid id)
        {
            Id = id;
        }
    }
}
