using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Dtos.UserAccount.Response
{
    public class DeleteUserAccountResponse
    {
        public string FullName { get; set; } = null!;
        public string? message => getMessageFullName();

        private string getMessageFullName()
        {
            return $"El perfil del usuario {FullName}, cambio a estado inactivo...";
        }
    }
}
