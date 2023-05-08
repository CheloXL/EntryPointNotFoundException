using System.Threading.Tasks;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Blinkay.Control.Controllers
{
	[Route("api/installations")]
	public sealed class InstallationsController : ApiController
	{
		/// <inheritdoc />
		public InstallationsController(ISender mediator) : base(mediator) { }

		[HttpGet("{id}")]
		public Task<IActionResult> Get(long id)
		{
			return RunCommand(new UpdateInstallation(id));
		}
	}
}
