using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Contacts.Contracts
{
	public interface IRepositoryWrapper
	{
		IContactsRepository Contact { get; }
		void Save();
	}
}
