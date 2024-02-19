using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.API.Core.Identity
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public string? PersonName { get; set; }
    }
}
