﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ShuttleZone.Api.Controllers.BaseControllers
{
    public abstract class BaseApiController : ODataController
    {
        /// <summary>
        /// Handles the result of an HTTP action.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <returns>The result of the action.</returns>
        /// <remarks>
        /// If the model state is not valid, the method will return a bad request with the model state.
        /// If the action throws an exception, the method will return a status code of 500 with the exception message.
        /// </remarks>
        protected IActionResult HandleResult(Func<object> action)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = action();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Handles the result of an HTTP action asynchronously.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <returns>The result of the action.</returns>
        /// <remarks>
        /// If the model state is not valid, the method will return a bad request with the model state.
        /// If the action throws an exception, the method will return a status code of 500 with the exception message.
        /// </remarks>
        protected async Task<IActionResult> HandleResultAsync(Func<Task<object>> action)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await action();
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
