﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Insert(brand);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandService.Update(brand);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.Delete(brand);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
