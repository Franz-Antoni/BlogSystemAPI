using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Dtos.UserAccount.Response
{
    public class UpdateUserAccountResponse
    {
        public string FullName { get; set; } = null!;
        public string? message => GetMessageFullName();

        private string GetMessageFullName() 
        {
            return $"El perfil del usuario {FullName}, ha sido actualizado correctamente!";
        }
    }
}
