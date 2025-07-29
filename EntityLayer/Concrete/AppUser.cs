using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string ImageUrl { get; set; } = "Belirtilmedi";
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; } = "Belirtilmedi";

        public List<Reservation> Reservations { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
