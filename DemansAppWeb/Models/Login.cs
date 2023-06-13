using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace DemansAppWeb.Models
{
    public class Login
    {
            public string UserName { get; set; }
            public string Password { get; set; }

    }
}
