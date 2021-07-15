using AutoMapper;
using Evolent.Contacts.Contracts;
using Evolent.Contacts.Entities;
using Evolent.Contacts.Entities.DataTransferObjects;
using Evolent.Contacts.Entities.Models;
using Evolent.Contacts.LoggerService;
using Evolent.Contacts.WebAPI;
using Evolent.Contacts.WebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace Evolent.Contacts.UnitTest
{
	public class ContactControllerTest
	{
		public Mock<IContactsRepository> mock = new Mock<IContactsRepository>();
		public Mock<LoggerManager> mockLogger = new Mock<LoggerManager>();
		public Mock<IRepositoryWrapper> mockRepoWrapper = new Mock<IRepositoryWrapper>();
		public Mock<IMapper> mockMapper = new Mock<IMapper>(); 
		public Contact contact = new();
		public Mock<ContactParameters> mockParameters = new Mock<ContactParameters>();
		dynamic mapperObj = null;

		public ContactControllerTest()
		{
			// Create actual object of mapper
			mapperObj = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new MappingProfile());
			});
		}

		[Fact]
		public void Test_GetContactById()
		{
			var contactobj = ContactList().Find(c => c.Id.Equals(12));
			mock.Setup(c => c.GetContactById(12)).Returns(contactobj);
			mockRepoWrapper.Setup(o => o.Contact).Returns(mock.Object);

			ContactController conController = new ContactController(mockLogger.Object, mockRepoWrapper.Object, mockMapper.Object);
			var result = conController.GetContactById(12);
			
			var okObjectResult = result as OkObjectResult;

			var presentations = okObjectResult.Value as GetContactDto;
			Assert.IsType<OkObjectResult>(result);
			Assert.Equal(200, StatusCodes.Status200OK);
		}

		[Fact]
		public void Test_GetContactList()
		{
			mock.Setup(c => c.GetAllContacts(mockParameters.Object)).Returns(ContactList());
			mockRepoWrapper.Setup(o => o.Contact).Returns(mock.Object);

			ContactController conController = new ContactController(mockLogger.Object, mockRepoWrapper.Object, mockMapper.Object);
			var result = conController.GetAllContacts(mockParameters.Object);

			var okObjectResult = result as OkObjectResult;
			Assert.IsType<OkObjectResult>(result);
			Assert.Equal(200, StatusCodes.Status200OK);
		}

		[Fact]
		public void Test_CreateNewContact()
		{
			mock.Setup(m => m.CreateContact(new Contact()));
			mockRepoWrapper.Setup(o => o.Contact).Returns(mock.Object);

			var mapperobj = mapperObj.CreateMapper();

			ContactController conController = new ContactController(mockLogger.Object, mockRepoWrapper.Object, mapper: mapperobj);

			var result = conController.CreateContact(new ContactforCUDto {
				Email = "test234@test.com",
				FirstName = "Robert",
				LastName = "Smith",
				PhoneNumber = "256-8652-758",
				Status = 1
			});

			var crResult = result as CreatedAtRouteResult;
			
			Assert.Equal(201, crResult.StatusCode);
		}

		[Fact]
		public void Test_UpdateContact()
		{
			var mapperobj = mapperObj.CreateMapper();

			var contactobj = ContactList().Find(c => c.Id.Equals(12));
			mock.Setup(c => c.GetContactById(12)).Returns(contactobj);
			mockRepoWrapper.Setup(o => o.Contact).Returns(mock.Object);

			var updatecontactobj = new UpdateContactDto
			{
				FirstName = "Alfred",
			};

			mock.Setup(c => c.UpdateContact(It.IsAny<Contact>())).Returns(true);
			mockRepoWrapper.Setup(o => o.Contact).Returns(mock.Object);

			ContactController conController = new ContactController(mockLogger.Object, mockRepoWrapper.Object, mapper: mapperobj);

			var result = conController.UpdateContact(12, updatecontactobj);
			
			var okObjectResult = result as BadRequestObjectResult;

			Assert.IsType<OkObjectResult>(result);
			Assert.Equal(200, StatusCodes.Status200OK);
		}

		[Fact]
		public void Test_DeleteContact()
		{
			var contactobj = ContactList().Find(c => c.Id.Equals(12));
			mock.Setup(c => c.GetContactById(12)).Returns(contactobj);
			
			mockRepoWrapper.Setup(o => o.Contact).Returns(mock.Object);

			var mapperobj = mapperObj.CreateMapper();

			mock.Setup(c => c.DeleteContact(contactobj));

			ContactController conController = new ContactController(mockLogger.Object, mockRepoWrapper.Object, mapper: mapperobj);

			var result = conController.DeleteContact(12);

			var deResult = result as OkObjectResult;

			Assert.Equal(200, deResult.StatusCode);
		}

		private List<Contact> ContactList()
		{
			List<Contact> contactlist = new List<Contact>()
			{
			new Contact
				{
					Id = 12,
					FirstName = "Hector",
					LastName = "Pollard",
					PhoneNumber = "563-6524-895",
					Email = "Hector.Pollard@test.com",
					Status = 1,
				},
				new Contact
				{
					Id = 10,
					FirstName = "Mario",
					LastName = "Benjamin",
					PhoneNumber = "235-9652-456",
					Email = "Mario.Benjamin@test.com",
					Status = 0,
				}
			};

			return contactlist;
		}
	}
}
