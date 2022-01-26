using System.ComponentModel.DataAnnotations;

namespace CollectionWebApp.ViewModels
{
    public class ItemModel
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Name { get; set; } 
    }
}
