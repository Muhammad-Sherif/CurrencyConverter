﻿using AutoMapper;
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
			CreateMap<CreateExchangeRateDto, ExchangeRate>()
				.ForMember(
				src=>src.ExchangeDate , 
				options=>options.MapFrom(src=>DateTime.Now));
			CreateMap<ExchangeRate, ExchangeRateDto>();

		}
	}
}
