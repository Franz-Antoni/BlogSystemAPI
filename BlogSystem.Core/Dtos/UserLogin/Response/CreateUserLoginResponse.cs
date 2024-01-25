using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Dtos.UserLogin.Response
{
    public class CreateUserLoginResponse
    {
        public string LoginName { get; set; } = null!;
        public string Message => GetMessageStatus();

        public string GetMessageStatus() 
        {
            return $"Gracias por registrarte, te damos la bienvenida {LoginName}.";
        }
    }
}
