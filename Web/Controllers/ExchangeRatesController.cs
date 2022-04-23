﻿using AutoMapper;
using Core.Models;
using Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Dtos;

namespace Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExchangeRatesController : ControllerBase
	{
		private readonly IUnitOfWork _context;
		private readonly IMapper _mapper;

		public ExchangeRatesController(IMapper mapper, IUnitOfWork context = null)
		{
			_mapper = mapper;
			_context = context;
		}
		[HttpGet(Name = nameof(GetExchangeRate))]

		public async Task<ActionResult<ExchangeRateDto>> GetExchangeRate(int exchangeRateId)
		{
			var exchangeRate = await _context.ExchangeRatesHistory.FindByKeyAsync(exchangeRateId);
			if (exchangeRate is null)
				return NotFound();

			var exchangeRateDto = _mapper.Map<ExchangeRateDto>(exchangeRate);
			return Ok(exchangeRateDto);
		}

		[HttpPost]
		public async Task<ActionResult<ExchangeRate>> AddExchangeRate(CreateExchangeRateDto createExchangeRateDto)
		{
			var currency =
				await _context.Currencies.FirstOrDefaultAsync
				(c => c.Id == createExchangeRateDto.CurrencyId && c.IsActive);
			if (currency == null)
				return NotFound();

			var newExchangeRate = _mapper.Map<ExchangeRate>(createExchangeRateDto);
			await _context.ExchangeRatesHistory.AddAsync(newExchangeRate);
			_context.SaveChanges();

			var exchangeRateDto = _mapper.Map<ExchangeRateDto>(newExchangeRate);

			return CreatedAtRoute(nameof(GetExchangeRate), new { exchangeRateId = exchangeRateDto.Id }, exchangeRateDto);

		}
		
		[HttpGet("ConvertAmount/{Amount}/{fromCurrencyId}/{toCurrencyId}")]
		public async Task<ActionResult<double>> ConvertAmount(double amount, int fromCurrencyId, int toCurrencyId)
		{
			var fromCurrency = await _context.Currencies.FirstOrDefaultAsync(c => c.Id == fromCurrencyId && c.IsActive);
			var toCurrecny = await _context.Currencies.FirstOrDefaultAsync(c => c.Id == toCurrencyId  && c.IsActive);
			if (fromCurrency == null || toCurrecny == null)
				return NotFound();

			var fromCurrencyRate = _context.ExchangeRatesHistory.GetLastDatedCurrencyRate(fromCurrencyId);
			var toCurrencyRate = _context.ExchangeRatesHistory.GetLastDatedCurrencyRate(toCurrencyId);

			if (fromCurrencyRate == null || toCurrencyRate == null)
				return NotFound();

			var convertedAmount = fromCurrencyRate.Rate * amount / toCurrencyRate.Rate;

			return Ok(convertedAmount);
		}

	}
}
