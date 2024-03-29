﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using nlp.finance.vanguard.data;
using nlp.finance.vanguard.services;

namespace nlp.finance.vanguard.Controllers
{
    [Route("nlp/finance/vanguard")]
    [ApiController]
    public class VanguardController : ControllerBase
    {
        public readonly INlpRepository<VanguardModel> repo;

        public VanguardController(INlpRepository<VanguardModel> repo)
        {
            this.repo = repo;
        }

        [Route("model")]
        [HttpGet]
        public IActionResult GetModel()
        {
            return Ok(repo.model);
        }

        [Route("categorize")]
        [HttpPost]
        public IActionResult Categorize([FromBody]RequestContent req)
        {
            return Ok(repo.Categorize(req.content));
        }
    }
}
