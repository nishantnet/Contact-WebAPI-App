using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Contacts.Entities.DataTransferObjects
{
	public class UpdateContactDto
	{
		[StringLength(60, ErrorMessage = "First Name can't be longer than 60 characters")]
		public string FirstName { get; set; }

		[StringLength(60, ErrorMessage = "Last Name can't be longer than 60 characters")]
		public string LastName { get; set; }

		[EmailAddress(ErrorMessage = "Email Address is invalid")]
		public string Email { get; set; }

		[Phone(ErrorMessage = "Phone number is not valid")]
		public string PhoneNumber { get; set; }
		public int Status { get; set; }
	}
}
