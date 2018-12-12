using Sharing.DataAccessCore.Core;
using Sharing.Domain.DataTransfer;
using System;

namespace Sharing.Domain.Mappers
{
    public class MachineMappers : IMapper<Machine, MachineServerDto>
    {
        public MachineServerDto AutoMap(Machine item)
        {
            return new MachineServerDto
            {
                Id = item.Id,
                Characteristic = item.Characteristic,
                Discount = item.Discount,
                IsAvailable = item.IsAvailable,
                Lessor = item.Lessor,
                MachineType = item.MachineType,
                Name = item.Name,
                Price = item.Price
            };
        }

        public Machine ReAutoMap(MachineServerDto item, Machine initialItem)
        {
            throw new NotImplementedException();
        }
    }
}
