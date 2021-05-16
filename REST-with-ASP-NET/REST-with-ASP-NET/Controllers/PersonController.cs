﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using REST_with_ASP_NET.Model;
using REST_with_ASP_NET.Business;
using REST_with_ASP_NET.Data.VO;
using REST_with_ASP_NET.Hypermedia.Filters;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;

namespace REST_with_ASP_NET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")] 
    public class PersonController : ControllerBase
    {


        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((204), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((400), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((401), Type = typeof(List<PersonVO>))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((204), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((400), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((401), Type = typeof(List<PersonVO>))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }
        [HttpPatch("{id}")]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((204), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((400), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((401), Type = typeof(List<PersonVO>))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Patch(long id)
        {
            var person = _personBusiness.Disable(id);
            return Ok(person);
        }
        [HttpPost]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Update(person));
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
