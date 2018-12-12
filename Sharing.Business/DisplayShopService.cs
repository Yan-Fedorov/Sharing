using System;
using System.Collections.Generic;
using System.Linq;
using Sharing.Business.Interfaces;
using Sharing.DataAccessCore.Core;
using Sharing.DataAccessCore.Interfaces;
using Sharing.Domain.DataTransfer;
using Sharing.Domain.Mappers;

namespace Sharing.Business
{
    public class DisplayShopService: IDisplayShopService
    {
        private readonly IRepository<Renter> _renterRepository;
        private readonly IRepository<Machine> _machineRepository;
        private readonly IRepository<RenteredMachine> _renteredMachineRepository;
        private readonly IRepository<Lessor> _lessorRepository;
        private readonly IMapper<Machine, MachineServerDto> _mapMachine;

        public DisplayShopService(IRepository<Renter> renterRepository, IRepository<Machine> machineRepository, IRepository<RenteredMachine> renteredMachineRepository, IRepository<Lessor> lessorRepository, IMapper<Machine, MachineServerDto> mapMachine)
        {
            _renterRepository = renterRepository;
            _machineRepository = machineRepository;
            _renteredMachineRepository = renteredMachineRepository;
            _lessorRepository = lessorRepository;
            _mapMachine = mapMachine;
        }

        public IList<MachineServerDto> DisplayAllAvailableMachines(int renterId)
        {
            if (renterId <= 0)
            {
                throw new ArgumentException($"{nameof(renterId)} is less then 1 in musicStoreService DisplayAllAvailableSongs", nameof(renterId));
            }

            var machinesAvailableForBuyByUser = GetAvailableForRenterMachines(renterId);

            if (machinesAvailableForBuyByUser == null)
            {
                throw new Exception("not available for buying");
            }

            var machinesDtoAvailableForBuyByUser = machinesAvailableForBuyByUser.Select(_mapMachine.AutoMap).ToList();

            return machinesDtoAvailableForBuyByUser;
        }

        private List<Machine> GetAvailableForRenterMachines(int renterId)
        {
            if (renterId <= 0)
            {
                throw new ArgumentException($"{nameof(renterId)} is less then 1 in musicStoreService DisplayAllAvailableSongs", nameof(renterId));
            }

            var renter = _renterRepository.GetItem(renterId);

            if (renter == null)
            {
                throw new Exception($"{nameof(renter)} is null");
            }

            

            var machines = _machineRepository.GetItemList();
            var availableForRenterMachinesList = new List<Machine>();

            if (renter.RenteredMachine == null)
            {
                return machines.ToList();
            }

            foreach (var machine in machines)
            {
                if (!renter.RenteredMachine.Any(x => x.Machine.Id == machine.Id))
                {
                    availableForRenterMachinesList.Add(machine);
                }
            }

            return availableForRenterMachinesList;
        }

        public IList<MachineServerDto> DisplayAllMachines()
        {
            var domainMachineList = _machineRepository.GetItemList().Select(_mapMachine.AutoMap).ToList();
            return domainMachineList;
        }
    }
}
