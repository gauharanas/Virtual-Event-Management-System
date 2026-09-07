using EMS.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Services.Interfaces
{

    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}
