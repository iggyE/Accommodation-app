using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Service
{
    public class UserService
    {
        private readonly UserRepository UserRepository;

        public UserService()
        {

        }

        public UserService(UserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public User Login(string username, string password)
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.Login(username, password);
        }

        public User GetByUsername(string username)
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.GetByUsername(username);
        }
    }
}
