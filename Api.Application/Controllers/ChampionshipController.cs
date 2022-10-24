using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services.Championship;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionshipController : Controller
    {
        private IChampionshipService _service;
        private readonly IMapper _mapper;

        public ChampionshipController(IChampionshipService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Championship()
        {
            try
            {
               var Championship = await _service.CreateChampionship();

                var matches = Championship.matches;
                var matchesVideModel = _mapper.Map<List<MatchEntity>, List<MatchViewModel>>(matches);

                var result = new ChampionshipViewModel();
                result.matches = matchesVideModel;
                result.Championship = Championship.Championship.name;
                result.vice = Championship.Vice.name;
                result.Third = Championship.Third.name;

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
