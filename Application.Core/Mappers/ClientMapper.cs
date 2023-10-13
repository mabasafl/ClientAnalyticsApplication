using Application.Core.Dtos;
using Application.Core.Interfaces;
using Application.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Mappers
{
    public class ClientMapper : IMapper<Client, ClientDto>
    {
        public ClientDto Map(Client model)
        {
            return new ClientDto()
            {
                RecordId = Guid.NewGuid(),
                ClientName = model.ClientName,
                DateRegisterd = model.DateRegisterd,
                Location = model.Location,
                NumberOfSystemUsers = model.NumberOfSystemUsers
            };
        }

        public Client Map(ClientDto dto)
        {
            return new Client()
            {
                RecordId = dto.RecordId,
                ClientName = dto.ClientName,
                DateRegisterd = dto.DateRegisterd,
                Location = dto.Location,
                NumberOfSystemUsers = dto.NumberOfSystemUsers
            };
        }

    }
}
