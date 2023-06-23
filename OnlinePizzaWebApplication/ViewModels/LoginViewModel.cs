using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlinePizzaWebApplication.ViewModels
{
    public class LoginViewModel
    {
		[Required(ErrorMessage = "Pole nazwa użytkownika nie może być puste")]
		[DisplayName("Nazwa użytkownika")]
        public string UserName { get; set; }

		[Required(ErrorMessage = "Pole hasło nie może być puste")]
		[DisplayName("Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [ScaffoldColumn(false)]
        public string ReturnUrl { get; set; }
    }
}
