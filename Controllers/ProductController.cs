﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrySimpleApi.Domain.Product.Entities;
using TrySimpleApi.Helpers;
using TrySimpleApi.Application.Product;

namespace TrySimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IResponseBuilder _helpers;
        private readonly IProductService _service;

        public ProductController(IResponseBuilder helper , IProductService service)
        {
            _helpers = helper;
            _service = service;
        }

        [HttpGet]
        public ActionResult<object> Index()
        {
            return Ok();
        }

        [HttpGet("error")]
        public ActionResult<object> Error()
        {
            return StatusCode(500 , _helpers.ErrorResponse("Error To create", new string[] { "error 1", "error 2" }));
        }

        [HttpPost]
        public async Task<ActionResult<object>> Store(ProductModel product)
        {
            dynamic creating = await _service.Create(product);

            if (creating.status == true)
            {
                return Ok(_helpers.SuccessResponse(creating.message, new string[] { "success" }));
            }
            else
            {
                return StatusCode(500, _helpers.ErrorResponse("Error To create", new string[] { creating.message }));
            }
        }

    }
}