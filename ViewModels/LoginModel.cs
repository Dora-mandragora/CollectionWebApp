using System.ComponentModel.DataAnnotations;

namespace CollectionWebApp.ViewModels
{
    public class LoginModel
    {

        //[Required(ErrorMessage = "Логин не указан")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        //[Required(ErrorMessage = "Пароль не указан")]
        public string Password { get; set; }

    }
}
