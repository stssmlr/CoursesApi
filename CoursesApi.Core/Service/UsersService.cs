using AutoMapper;
using CoursesApi.Core.Entities;
using CoursesApi.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Service
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<Users> _userRepository;

        public UsersService(IRepository<Users> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResponse> GetAll()
        {
            var date = (List<Users>)await _userRepository.GetAll();
            if (date != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "All IP Address successfully loaded",
                    Payload = date
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "There are no IP Address",
                    Payload = null
                };
            }
        }
        public async Task<ServiceResponse> Get(int id)
        {
            var date = (Users)await _userRepository.GetByID(id);
            if (date != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "IP Address successfully uploaded",
                    Payload = date
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "There are no IP Address",
                    Payload = null
                };
            }
        }
        public async Task Insert(Users ipAddress)
        {
            await _userRepository.Insert(ipAddress);
            await _userRepository.Save();
        }
        public async Task<ServiceResponse> Delete(int id)
        {
            List<Users> IpAddress = (List<Users>)await _userRepository.GetAll();
            foreach (Users ip in IpAddress)
            {
                if (ip.Id == id)
                {
                    await _userRepository.Delete(id);
                    await _userRepository.Save();
                    return new ServiceResponse
                    {
                        Success = true,
                        Message = "IP Was Deleted",
                        Payload = ip
                    };
                }
            }
            return new ServiceResponse
            {
                Success = false,
                Message = "Ip address does not exist",
                Payload = null

            };
        }
    }
}
