using AutoMapper;
using Evolent.Contacts.Entities.DataTransferObjects;
using Evolent.Contacts.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evolent.Contacts.WebAPI
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ContactforCUDto, Contact>();
			CreateMap<Contact, GetContactDto>()
				.ForMember(x => x.Status, opt => opt.MapFrom(o => o.Status == 1 ? "Active" : "Inactive"));
		}
	}
}
