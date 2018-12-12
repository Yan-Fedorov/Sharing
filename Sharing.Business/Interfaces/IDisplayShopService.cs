using Sharing.Domain.DataTransfer;
using System.Collections.Generic;

namespace Sharing.Business.Interfaces
{
    public interface IDisplayShopService
    {
        IList<MachineServerDto> DisplayAllMachines();
        IList<MachineServerDto> DisplayAllAvailableMachines(int renterId);
    }
}
