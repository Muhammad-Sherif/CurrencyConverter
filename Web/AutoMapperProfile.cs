using AutoMapper;
using Core.Models;
using Web.Dtos;

namespace Web
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Currency, CurrencyDto>();
			CreateMap<CreateCurrencyDto, Currency>();
			CreateMap<UpdateCurrencyDto, Currency>();

		}
	}
}
