using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlinePizzaWebApplication.ViewModels
{
    public class RegisterViewModel
    {
		[Required(ErrorMessage = "Pole Adres e-mail nie może być puste")]
		[DisplayName("Adres e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

		[Required(ErrorMessage = "Pole Hasło nie może być puste")]
		[DisplayName("Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<string> Errors { get; set; }

    }
}
