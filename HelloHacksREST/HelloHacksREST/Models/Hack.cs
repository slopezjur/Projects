using HelloHacksREST.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace HelloHacksREST.Models
{
    public class Hack : IGenericType
    {
        public Hack()
        {
            Id = 0;
            Name = "Default";
            Description = "";
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}