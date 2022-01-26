using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CollectionWebApp.ViewModels
{
    public class CollectionModel
    {
        [Required(ErrorMessage = "Название - обязательное поле")]
        public string Name { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
