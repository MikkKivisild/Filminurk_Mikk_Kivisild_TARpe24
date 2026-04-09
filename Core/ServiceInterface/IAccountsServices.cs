using Core.Domain;
using Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServiceInterface
{
	public interface IAccountsServices
	{
       Task<ApplicationUser> Register(ApplicationUserDTO userDTO);
        Task<ApplicationUser> Login(LoginDTO userDTO);
    }
}
