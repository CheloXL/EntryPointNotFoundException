using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Mediator;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OneOf;
using OneOf.Types;

namespace Blinkay.Control.Controllers
{
	public sealed record UpdateInstallation([property: JsonIgnore] [BindNever]long Id) : ICommand<UpdateInstallationResult>;

	[GenerateOneOf]
	public sealed partial class UpdateInstallationResult : OneOfBase<None, Exception> { }

	public sealed class UpdateInstallationHandler : ICommandHandler<UpdateInstallation, UpdateInstallationResult>
	{
		public async ValueTask<UpdateInstallationResult> Handle(UpdateInstallation command, CancellationToken cancellationToken)
		{
			await Task.Delay(1000, cancellationToken);
			return new None();
		}
	}
}
