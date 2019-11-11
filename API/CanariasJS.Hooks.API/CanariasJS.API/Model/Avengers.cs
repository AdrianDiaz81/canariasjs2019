using System.ComponentModel.DataAnnotations.Schema;

namespace CanariasJS.Hooks.API.Model
{
    [Table("Avenger")]
    public class Avengers:Base
    {        
        public string Name { get; set; }
        public string UrlPhoto { get; set; }
        public string Description { get; set; }
    }
}
