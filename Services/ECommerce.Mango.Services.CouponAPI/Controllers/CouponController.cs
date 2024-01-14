﻿using ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Queries.GetCouponDetails;
using ECommerce.Mango.Services.CouponAPI.Core.Application.Features.Coupons.Queries.GetCouponList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        // GET: api/<Coupon>
        [HttpGet]
        public async Task<ActionResult<List<CouponDto>>> Get()
        {
            return Ok(await _mediator.Send(new GetCouponListQuery()));
        }

        // GET api/<Coupon>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CouponDetailsDto>> Get(int id)
        {
            return Ok(await _mediator.Send(new GetCouponDetailsQueryList(id)));
        }

        // POST api/<Coupon>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Post([FromBody] string value)
        {
        }

        //// PUT api/<Coupon>/5
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<Coupon>/5
        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public void Delete(int id)
        //{
        //}
    }
}
