using System;
using System.Collections.Generic;
using System.Text;
using Sharing.DataAccessCore.Core;
using Sharing.Domain.DataTransfer;

namespace Sharing.Domain.Mappers
{
    public class MachineMappers : IMapper<Machine, MachineServerDto>
    {
        public MachineServerDto AutoMap(Machine item)
        {
            throw new NotImplementedException();
        }

        public Machine ReAutoMap(MachineServerDto item, Machine initialItem)
        {
            throw new NotImplementedException();
        }
    }
}
