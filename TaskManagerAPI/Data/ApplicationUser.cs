using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerAPI.Data
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public string? PersonName { get; set; }
    }
}
