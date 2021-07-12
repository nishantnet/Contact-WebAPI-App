using AutoMapper;
using Evolent.Contacts.Contracts;
using Evolent.Contacts.Entities;
using Evolent.Contacts.Entities.DataTransferObjects;
using Evolent.Contacts.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evolent.Contacts.WebAPI.Controllers
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/contact")]
	public class ContactController : ControllerBase
	{
		private ILoggerManager _logger;
		private IRepositoryWrapper _repository;
		private IMapper _mapper;

		public ContactController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
		{
			_logger = logger;
			_repository = repository;
			_mapper = mapper;
		}

		/// <summary>
		/// https://localhost:xxxxx/api/1.0/contact
		/// https://localhost:xxxxx/api/1.0/contact?PageNumber=1&PageSize=2
		/// </summary>
		/// <param name="contactParameters"></param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult GetAllContacts([FromQuery] ContactParameters contactParameters)
		{
			try
			{
				var contacts = _repository.Contact.GetAllContacts(contactParameters);

				_logger.LogInfo($"Returned all contacts from database.");

				var contactlist = _mapper.Map<IEnumerable<Contact>, IEnumerable<GetContactDto>>(contacts);

				return Ok(contactlist);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllContacts action: {ex.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

		/// <summary>
		/// https://localhost:xxxxx/api/1.0/contact/id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}", Name = "ContactById")]
		public IActionResult GetContactById(int id)
		{
			try
			{
				var contact = _repository.Contact.GetContactById(id);

				if (contact == null)
				{
					_logger.LogError($"Contact with id: {id}, has not found in Database.");

					return NotFound();
				}
				else
				{
					_logger.LogInfo($"Returned contact with id: {id}");

					var getcontact = _mapper.Map<Contact, GetContactDto>(contact);
					
					return Ok(getcontact);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetContactById action: {ex.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

		/// <summary>
		/// https://localhost:xxxxx/api/1.0/contact/Create
		/// FromBody
		///	{
		///  "firstName": "TestFirst",
		///  "lastName": "TestLast",
		///  "email": "TestFirst.TestLast456@test.com",
		///  "phoneNumber": "xxx-xxxx-xxx",
		///  "status": 1
		///	}
		/// </summary>
		/// <param name="contact"></param>
		/// <returns></returns>
		[HttpPost("Create")]
		public IActionResult CreateContact([FromBody] ContactforCUDto contact)
		{
			try
			{
				if (contact == null)
				{
					_logger.LogError("Contact object sent from client is null.");
					return BadRequest("Contact object is null");
				}
				if (_repository.Contact.CheckContactExists(contact.Email))
				{
					_logger.LogError("Contact object sent from client is already exists.");
					return BadRequest("Contact object already exists");
				}

				var contactEntity = _mapper.Map<Contact>(contact);

				_repository.Contact.CreateContact(contactEntity);
				_repository.Save();

				return CreatedAtRoute("ContactById", new { id = contactEntity.Id }, contactEntity);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateContact action: {ex.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

		/// <summary>
		/// https://localhost:xxxxx/api/1.0/contact/UpdateContact/id
		/// FromBody
		///	{
		///  "firstName": "TestFirst",
		///  "lastName": "TestLast",
		///  "email": "TestFirst.TestLast456@test.com",
		///  "phoneNumber": "xxx-xxxx-xxx",
		///  "status": 0
		///	}
		/// </summary>
		/// <param name="id"></param>
		/// <param name="contact"></param>
		/// <returns></returns>
		[HttpPut("UpdateContact/{id}")]
		public IActionResult UpdateContact(int id, [FromBody] ContactforCUDto contact)
		{
			try
			{
				if (contact == null)
				{
					_logger.LogError("Contact object sent from client is null.");
					return BadRequest("Contact object is null");
				}

				var contactEntity = _repository.Contact.GetContactById(id);
				if (contactEntity == null)
				{
					_logger.LogError($"Contact with id: {id}, hasn't been found in db.");
					return NotFound();
				}

				_mapper.Map(contact, contactEntity);

				if (_repository.Contact.UpdateContact(contactEntity))
				{
					return Ok("Contact Information updated successfully");
				}
				else
				{
					_logger.LogError("Contact Email sent from client is already exists.");
					return BadRequest("Contact object already exists");
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateContact action: {ex.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

		/// <summary>
		/// https://localhost:xxxxx/api/1.0/contact/DeleteContact/id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("DeleteContact/{id}")]
		public IActionResult DeleteContact(int id)
		{
			try
			{
				var contact = _repository.Contact.GetContactById(id);

				if(contact == null)
				{
					_logger.LogError($"Contact with id: {id}, hasn't been found in db.");
					return NotFound();
				}

				_repository.Contact.DeleteContact(contact);
				_repository.Save();

				return Ok("Contact deleted successfully");
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside DeleteContact action: {ex.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

	}
}
