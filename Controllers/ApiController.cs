using System;
using System.Threading.Tasks;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using OneOf.Types;

namespace Blinkay.Control.Controllers
{
	/// <summary>
	///     Base controller with helper methods.
	/// </summary>
	[ApiController]
	[Produces("application/json")]
	[ResponseCache(NoStore = true, Location = ResponseCacheLocation.Client)]
	public abstract class ApiController : ControllerBase
	{
		private readonly ISender _mediator;

		/// <summary>
		///     Initializes a new instance of <see cref="ApiController" />.
		/// </summary>
		/// <param name="mediator"></param>
		protected ApiController(ISender mediator)
		{
			_mediator = mediator;
		}

		protected async Task<IActionResult> RunCommand<TCommand>(TCommand command) where TCommand : class, ICommand<OneOfBase<None, Exception>>
		{
			var result = await _mediator.Send(command, ControllerContext.HttpContext.RequestAborted);
			return result.Match<IActionResult>(_ => NoContent(), ex => BadRequest(ex.ToString()));
		}
	}
}
