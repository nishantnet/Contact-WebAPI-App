using Evolent.Contacts.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Contacts.Entities.Configuration
{
	public class ContactConfiguration : IEntityTypeConfiguration<Contact>
	{
		public void Configure(EntityTypeBuilder<Contact> builder)
		{
			builder.HasData
			(
				new Contact
				{
					Id = 1,
					FirstName = "James",
					LastName = "Smith",
					Email = "James.Smith@test.com",
					PhoneNumber = "486-9852-452",
					Status = 1
				},
				new Contact
				{
					Id = 2,
					FirstName = "John",
					LastName = "Johnson",
					Email = "John.Johnson@test.com",
					PhoneNumber = "561-7852-632",
					Status = 0
				},
				new Contact
				{
					Id = 3,
					FirstName = "Robert",
					LastName = "Williams",
					Email = "Robert.Williams@test.com",
					PhoneNumber = "865-7521-632",
					Status = 1
				},
				new Contact
				{
					Id = 4,
					FirstName = "Michael",
					LastName = "Brown",
					Email = "Michael.Brown@test.com",
					PhoneNumber = "965-7852-632",
					Status = 1
				},
				new Contact
				{
					Id = 5,
					FirstName = "William",
					LastName = "Jones",
					Email = "William.Jones@test.com",
					PhoneNumber = "632-8956-412",
					Status = 0
				},
				new Contact
				{
					Id = 6,
					FirstName = "David",
					LastName = "Miller",
					Email = "David.Miller@test.com",
					PhoneNumber = "632-8965-412",
					Status = 1
				},
				new Contact
				{
					Id = 7,
					FirstName = "Mary",
					LastName = "Davis",
					Email = "Mary.Davis@test.com",
					PhoneNumber = "695-9632-541",
					Status = 1
				},
				new Contact
				{
					Id = 8,
					FirstName = "Patricia",
					LastName = "Garcia",
					Email = "Patricia.Garcia@test.com",
					PhoneNumber = "632-8512-453",
					Status = 1
				},
				new Contact
				{
					Id = 9,
					FirstName = "Jennifer",
					LastName = "Anderson",
					Email = "Jennifer.Anderson@test.com",
					PhoneNumber = "632-1563-167",
					Status = 1
				},
				new Contact
				{
					Id = 10,
					FirstName = "Barbara",
					LastName = "Martinez",
					Email = "Barbara.Martinez@test.com",
					PhoneNumber = "852-7415-951",
					Status = 1
				}
			);
		}
	}
}
