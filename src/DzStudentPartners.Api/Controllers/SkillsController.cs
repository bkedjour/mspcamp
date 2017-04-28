using System;
using System.Collections.Generic;
using AutoMapper;
using DzStudentPartners.Api.Filters;
using DzStudentPartners.Api.Models;
using DzStudentPartners.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DzStudentPartners.Api
{
    [Route("api/camps/{tag}/msps/{mspId}/skills")]
    [ValidateModel]
    public class SkillsController : Controller
    {
        private readonly IMspRepository _repo;
        private readonly ILogger<SkillsController> _logger;

        private readonly IMapper _mapper;

        public SkillsController(IMspRepository repo, ILogger<SkillsController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllSkills(string tag, int mspId)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<SkillModel>>(_repo.GetSkills(mspId)));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when trying to retrieve skills: {e}");
            }

            return BadRequest();
        }
    }
}