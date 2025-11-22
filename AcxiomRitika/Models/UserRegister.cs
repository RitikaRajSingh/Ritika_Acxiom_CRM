using System.ComponentModel.DataAnnotations;

namespace AcxiomRitika.Models
{
    public class UserRegister
    {
      
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }


        }
    }

