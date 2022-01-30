using System.ComponentModel.DataAnnotations;

namespace CollectionWebApp.ViewModels
{
    public class RegisterModel
    {        
        public string Email { get; set; }

        [Required(ErrorMessage = "Строка обязательна для заполнения")]
        public string Login { get; set; }

        [DataType(DataType.Password)]       
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
