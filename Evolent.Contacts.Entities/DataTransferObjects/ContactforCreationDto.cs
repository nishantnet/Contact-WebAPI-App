using System.ComponentModel.DataAnnotations;

namespace Evolent.Contacts.Entities.DataTransferObjects
{
	public class ContactforCUDto
	{
		[Required(ErrorMessage = "First Name is required")]
		[StringLength(60, ErrorMessage = "First Name can't be longer than 60 characters")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last Name is required")]
		[StringLength(60, ErrorMessage = "Last Name can't be longer than 60 characters")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Email Address is required")]
		[EmailAddress(ErrorMessage = "Email Address is invalid")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Phone Number is required")]
		[Phone(ErrorMessage = "Phone number is not valid")]
		public string PhoneNumber { get; set; }
		public int Status { get; set; }

	}
}
