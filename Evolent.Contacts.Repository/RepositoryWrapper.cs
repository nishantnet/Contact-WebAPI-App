using Evolent.Contacts.Contracts;
using Evolent.Contacts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Contacts.Repository
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private RepositoryContext _repoContext;
		private IContactsRepository _contact;
		public IContactsRepository Contact
		{
			get
			{
				if (_contact == null)
				{
					_contact = new ContactsRepository(_repoContext);
				}
				return _contact;
			}
		}

		public RepositoryWrapper(RepositoryContext repositoryContext)
		{
			_repoContext = repositoryContext;
		}
		public void Save()
		{
			_repoContext.SaveChanges();
		}
	}
}
