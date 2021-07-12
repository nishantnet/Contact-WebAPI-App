using Evolent.Contacts.Contracts;
using Evolent.Contacts.Entities;
using Evolent.Contacts.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Contacts.Repository
{
	public class ContactsRepository : RepositoryBase<Contact>, IContactsRepository
	{
		public ContactsRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		public bool CheckContactExists(string email)
		{
			return FindByCondition(c => c.Email.Equals(email)).Any();
		}

		public void CreateContact(Contact contact)
		{
			Create(contact);
		}

		public void DeleteContact(Contact contact)
		{
			Delete(contact);
		}

		public IEnumerable<Contact> GetAllContacts(ContactParameters contactParameter)
		{
			return FindAll()
				.OrderBy(c => c.FirstName)
				.Skip((contactParameter.PageNumber - 1) * contactParameter.PageSize)
				.Take(contactParameter.PageSize)
				.ToList();
		}

		public Contact GetContactById(int contactId)
		{
			return FindByCondition(c => c.Id.Equals(contactId)).FirstOrDefault();
		}

		public bool UpdateContact(Contact contact)
		{
			bool isEmailExist = FindByCondition(c => c.Email.Equals(contact.Email) && c.Id != contact.Id).Any();

			if (isEmailExist)
			{
				return false;
			}
			else
			{
				Update(contact);
				return true;
			}
		}
	}
}
