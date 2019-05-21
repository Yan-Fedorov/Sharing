using Sharing.DataAccessCore.Core;
using Sharing.Domain.DataTransfer;
using System;

namespace Sharing.Domain.Mappers
{
    public class MachineMappers : IMapper<CloudResource, MachineServerDto>
    {
        public MachineServerDto AutoMap(CloudResource item)
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

        public CloudResource ReAutoMap(MachineServerDto item, CloudResource initialItem)
        {
            throw new NotImplementedException();
        }
    }
}
