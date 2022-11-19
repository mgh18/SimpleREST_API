using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SimpleREST_API.Data
{
    public class UsersTbl
    {
        [Key]
        public int Id { get; set; }
        
        public String Username { get; set; } = null!;
       
        public String Fullname { get; set; } = null!;

        public String City { get; set; } = null!;

        public String Country { get; set; } = null!;
    }
}
