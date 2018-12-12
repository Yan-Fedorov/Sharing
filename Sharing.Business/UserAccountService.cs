using System;
using System.Collections.Generic;
using System.Text;
using Sharing.Business.Interfaces;
using Sharing.DataAccessCore.Core;
using Sharing.DataAccessCore.Interfaces;

namespace Sharing.Business
{
    public class UserAccountService: IUserAccountService
    {
        private readonly IRepository<Lessor> _lessorRepository;
        private readonly IRepository<Renter> _renterRepository;
        public UserAccountService(IRepository<Lessor> lessorRepository, IRepository<Renter> renterRepository)
        {
            _lessorRepository = lessorRepository;
            _renterRepository = renterRepository;

        }
        public bool ChangeLessorAccount(Lessor user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "user is null");
            }

            var result = _lessorRepository.Update(user);

            if (result <= 0)
            {
                return false;
            }

            return true;
        }

        public Lessor GetLessorAccount(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id is less then 1", nameof(id));
            }

            var result = _lessorRepository.GetItem(id);

            return result;
        }

        public Renter GetRenterAccount(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id is less then 1", nameof(id));
            }

            var result = _renterRepository.GetItem(id);

            return result;
        }

        public bool ChangeRenterAccount(Renter user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "user is null");
            }

            var result = _renterRepository.Update(user);

            if (result <= 0)
            {
                return false;
            }

            return true;
        }

        public bool DeleteRenterAccount(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id is less then 1", nameof(id));
            }

            var result = _renterRepository.Delete(id);

            return result == 1;
        }

        public bool DeleteLessorAccount(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id is less then 1", nameof(id));
            }

            var result = _lessorRepository.Delete(id);

            return result == 1;
        }
    }
}
