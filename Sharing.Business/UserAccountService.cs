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
        private readonly IRepository<Customer> _renterRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IRepository<RenteredResource> _renterdMachineRepository;

        public UserAccountService(IRepository<Lessor> lessorRepository, IRepository<Customer> renterRepository, IAuthRepository authRepository, IRepository<RenteredResource> renterdMachineRepository)
        {
            _lessorRepository = lessorRepository;
            _renterRepository = renterRepository;
            _authRepository = authRepository;
            _renterdMachineRepository = renterdMachineRepository;

        }
        public bool ChangeLessorAccount(Lessor user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "user is null");
            }

            var dbLessor = _renterRepository.GetItem(user.Id);

            user.PasswordHash = dbLessor.PasswordHash;
            user.PasswordSalt = dbLessor.PasswordHash;

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

            result.PasswordHash = new byte[0];
            result.PasswordSalt = new byte[0];

            return result;
        }

        public Customer GetRenterAccount(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id is less then 1", nameof(id));
            }

            var result = _renterRepository.GetItem(id);

            result.PasswordHash = new byte[0];
            result.PasswordSalt = new byte[0];

            return result;
        }

        public bool ChangeRenterAccount(Customer user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "user is null");
            }

            var dbRenter = _renterRepository.GetItem(user.Id);

            dbRenter.LastName = user.LastName;
            dbRenter.FirstName = user.FirstName;
            dbRenter.UserName = user.UserName;

            var result = _renterRepository.Update(dbRenter);

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

        public RenteredResource GetRenteredMachineAccount(int id)
        {

            if (id < 1)
            {
                throw new ArgumentException("id is less then 1", nameof(id));
            }

            var result = _renterdMachineRepository.GetItem(id);
            return result;
        }
        public bool ActivateDron(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id is less then 1", nameof(id));
            }

            var result = _renterdMachineRepository.GetItem(id);

            result.isActive = true;


            return _renterdMachineRepository.Update(result) > 0;
        }
    }
}
