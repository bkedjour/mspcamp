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
    [Route("api/camps/{tag}/[controller]")]
    [ValidateModel]
    public class MspsController : Controller
    {
        private readonly IMspRepository _mspRepo;
        private readonly ILogger<MspsController> _logger;

        private readonly IMapper _mapper;

        public MspsController(IMspRepository mspRepo, ILogger<MspsController> logger, IMapper mapper)
        {
            _mspRepo = mspRepo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllMsps(string tag, bool includeSkills)
        {
            try
            {
                var partners = includeSkills ? _mspRepo.GetAllMspsWithSkills(tag) : _mspRepo.GetAllMsps(tag);

                return Ok(_mapper.Map<IEnumerable<MspModel>>(partners));
            }
            catch (Exception e)
            {
                _logger.LogError($"Somthing bad happend when trying to get the msp list: {e}");
            }

            return BadRequest();
        }

        [HttpGet("{id:int}", Name = "GetMsp")]
        public IActionResult GetMsp(string tag, int id, bool includeSkills)
        {
            try
            {
                var msp = includeSkills ? _mspRepo.GetMspWithSkillsById(id) : _mspRepo.GetMspById(id);

                if (msp == null) return NotFound();

                if (msp.Camp.Tag != tag)
                    return BadRequest("Tag does note match");

                return Ok(_mapper.Map<MspModel>(msp));
            }
            catch (Exception e)
            {
                _logger.LogError($"Somthing bad happend when trying to get the msp : {e}");
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddMsp(string tag,[FromBody] MspModel model)
        {
            try
            {
                var msp = _mapper.Map<Msp>(model);

                var camp = _mspRepo.GetCampByTag(tag);

                msp.Camp = camp;

                _mspRepo.AddMsp(msp);

                var url = Url.Link("GetMsp", new { tag = tag, id = msp.Id });

                return Created(url, model);

            }
            catch (Exception e)
            {
                _logger.LogError($"Somthing bad happend when trying to add an msp: {e}");
            }

            return BadRequest();
        }
    }
}