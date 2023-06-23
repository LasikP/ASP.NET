using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlinePizzaWebApplication.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        public List<OrderDetail> OrderLines { get; set; }

        [Required(ErrorMessage = "Proszę o podanie imienia")]
        [Display(Name = "Imię")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Proszę o podanie nazwiska")]
        [Display(Name = "Nazwisko")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Proszę o podanie ulicy")]
        [StringLength(100)]
        [Display(Name = "Ulica")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Numer mieszkania")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Proszę o podanie kodu pocztowego")]
        [Display(Name = "Kod pocztowy")]
        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Proszę o podanie miasta")]
        [StringLength(50)]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [StringLength(10)]
        [DisplayName("Kraj")]
        public string State { get; set; }

        //[Required(ErrorMessage = "Please enter your country")]
        //[StringLength(50)]
        //public string Country { get; set; }

        [Required(ErrorMessage = "Proszę o podanie numeru telefonu")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Proszę o podanie adresu e-mail")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])")]
           
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [DisplayName("Podsumowanie zamówienia")]
        [Precision(18, 2)]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [DisplayName("Data zamówienia")]
        public DateTime OrderPlaced { get; set; }

        //[BindNever]
        //[ScaffoldColumn(false)]
        //public string OrderStatus { get; set; }
        [DisplayName("Użytkownik")]
        public string UserId { get; set; }
		[DisplayName("Użytkownik")]
		public IdentityUser User { get; set; }
        
    }
}
