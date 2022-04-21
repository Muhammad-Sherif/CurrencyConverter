using AutoMapper;
using Core.Models;
using Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Dtos;

namespace Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CurrenciesController : ControllerBase
	{
		private readonly IUnitOfWork _context;
		private readonly IMapper _mapper;

		public CurrenciesController(IMapper mapper, IUnitOfWork context = null)
		{
			_mapper = mapper;
			_context = context;
		}


		[HttpGet]
		public async Task<ActionResult<IEnumerable<CurrencyDto>>> GetCurrencies()
		{
			var currencies = await _context.Currencies.FindByCriteriaAsync(c=>c.IsActive);
			var currenciesDtos = _mapper.Map<IEnumerable<CurrencyDto>>(currencies);

			return Ok(currenciesDtos);
		}
		[HttpGet("Id/{currencyId}" , Name = nameof(GetCurrencyById))]
		public async Task<IActionResult> GetCurrencyById(int currencyId)
		{
			var currency = await _context.Currencies.FirstOrDefaultAsync(c=>c.Id == currencyId && c.IsActive);
			if (currency is null)
				return NotFound();

			var currencyDto = _mapper.Map<CurrencyDto>(currency);
			return Ok(currencyDto);
		}
		[HttpGet("Name/{currencyName}")]
		public async Task<IActionResult> GetCurrencyByName(string currencyName)
		{
			var currency = await _context.Currencies.FirstOrDefaultAsync(c => c.Name== currencyName && c.IsActive);
			if (currency is null)
				return NotFound();

			var currencyDto = _mapper.Map<CurrencyDto>(currency);
			return Ok(currencyDto);
		}
		[HttpPost]
		public async Task<ActionResult<CurrencyDto>> CreateCurrency(CreateCurrencyDto createCurrencyDto)
		{
			var currency = _mapper.Map<Currency>(createCurrencyDto);
			await _context.Currencies.AddAsync(currency);
			_context.SaveChanges();

			var currencyDto = _mapper.Map<CurrencyDto>(currency);
			return CreatedAtRoute(nameof(GetCurrencyById), new { currencyId =  currencyDto.Id }, currencyDto);

		}
		[HttpPut]
		public async Task<ActionResult> UpdateCurrency(int currencyId , UpdateCurrencyDto updateCurrencyDto)
		{
			var currency = await _context.Currencies.FirstOrDefaultAsync(c => c.Id == currencyId && c.IsActive);
			if(currency is null)
			{
				return NotFound();
			}
			_mapper.Map(updateCurrencyDto, currency);
			_context.SaveChanges();
			return NoContent();

		}
		[HttpDelete]
		public async Task<ActionResult> DeleteCurrency(int currencyId)
		{
			var currency = await _context.Currencies.FirstOrDefaultAsync(c => c.Id == currencyId && c.IsActive);
			if (currency is null)
				return NotFound();

			currency.IsActive = false;
			_context.SaveChanges();
			return NoContent();

		}
	}
}
