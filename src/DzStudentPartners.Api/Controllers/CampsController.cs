using System;
using System.Collections.Generic;
using AutoMapper;
using DzStudentPartners.Api.Filters;
using DzStudentPartners.Api.Models;
using DzStudentPartners.Core;
using DzStudentPartners.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DzStudentPartners.Api
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class CampsController : Controller
    {
        private IMspRepository _repo;
        private ILogger<CampsController> _logger;

        private IMapper _mapper;

        public CampsController(IMspRepository repo, ILogger<CampsController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var camps = _repo.GetAllCamps();

            return Ok(_mapper.Map<IEnumerable<CampModel>>(camps));
        }

        [HttpGet("{tag}", Name = "CampGet")]
        public IActionResult GetCamp(string tag)
        {
            try
            {
                var camp = _repo.GetCampByTag(tag);

                if (camp == null) return NotFound($"Camp {tag} was not found");

                return Ok(_mapper.Map<CampModel>(camp));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when trying getting camp {e}");
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Post([FromBody]CampModel model)
        {
            try
            {
                var camp = _mapper.Map<MspCamp>(model);

                _repo.AddCamp(camp);

                var uri = Url.Link("CampGet", new { tag = camp.Tag });
                return Created(uri, model);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.ToString());
            }

            return BadRequest();
        }
    }
}