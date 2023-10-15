using Application.Core.Dtos;
using Application.Core.Interfaces;
using Application.Core.Models;

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
                DateRegistered = model.DateRegistered,
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
                DateRegistered = dto.DateRegistered,
                Location = dto.Location,
                NumberOfSystemUsers = dto.NumberOfSystemUsers
            };
        }

    }
}
