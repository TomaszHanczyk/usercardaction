using Microsoft.AspNetCore.Mvc;
using System.Net;
using UserCard.Common.PublicInterfaces;

namespace UserCardAction.Controllers
{
	[ApiController]
	public class UserCardController(IActionsCardBL actionCardBl) : ControllerBase
	{
		[HttpGet]
		[Route("api/[controller]/actionscard")]
		public IActionResult GetAsync(string userId, string cardNumber)
		{
			var cardActions = actionCardBl.GetCardActions(userId, cardNumber);

			if (cardActions == null)
			{
				return new ContentResult
				{
					StatusCode = (int)HttpStatusCode.InternalServerError,
					Content = "An error occurred while processing the request.",
					ContentType = "text/plain"
				};
			}

			if (cardActions.CardDetails == null)
			{
				return NotFound("User card not found.");
			}

			return Ok(cardActions);
		}
	}
}