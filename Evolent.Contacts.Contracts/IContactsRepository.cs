using Evolent.Contacts.Entities;
using Evolent.Contacts.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Contacts.Contracts
{
	public interface IContactsRepository : IRepositoryBase<Contact>
	{
		IEnumerable<Contact> GetAllContacts(ContactParameters contactParameter);
		Contact GetContactById(int contactId);
		bool CheckContactExists(string email);
		void CreateContact(Contact contact);
		bool UpdateContact(Contact contact);
		void DeleteContact(Contact contact);


	}
}
