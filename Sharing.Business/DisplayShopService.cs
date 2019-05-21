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
        private readonly IRepository<Customer> _renterRepository;
        private readonly IRepository<CloudResource> _machineRepository;
        private readonly IRepository<RenteredResource> _renteredMachineRepository;
        private readonly IRepository<Lessor> _lessorRepository;
        private readonly IMapper<CloudResource, MachineServerDto> _mapMachine;

        public DisplayShopService(IRepository<Customer> renterRepository, IRepository<CloudResource> machineRepository, IRepository<RenteredResource> renteredMachineRepository, IRepository<Lessor> lessorRepository, IMapper<CloudResource, MachineServerDto> mapMachine)
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

        private List<CloudResource> GetAvailableForRenterMachines(int renterId)
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
            var availableForRenterMachinesList = new List<CloudResource>();

            if (renter.RenteredMachine == null)
            {
                return machines.ToList();
            }

            foreach (var machine in machines)
            {
                if (!renter.RenteredMachine.Any(x => x.CloudResource.Id == machine.Id))
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
