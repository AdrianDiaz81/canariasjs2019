namespace CanariasJS.API.Model
{
    using CanariasJS.Hooks.API.Model;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Patxaran")]
    public class Patxaran:Base
    {
        public string Name { get; set; }
        public string UrlPhoto { get; set; }
        public string Description { get; set; }
    }
}
