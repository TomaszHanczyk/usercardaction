using Microsoft.AspNetCore.Mvc;
using UserCard.Common;
using UserCard.Common.PublicInterfaces;

namespace UserCardAction.Controllers
{
	[ApiController]
	public class UserCardController(IUserCardActionsBL userCardActionsBl) : ControllerBase
	{
		[HttpGet]
		[Route("api/[controller]/usercardactions")]
		public async Task<IActionResult> GetUserCardActionsAsync(string userId, string cardNumber)
		{
			UserCardActionsDetails? userCardActionsDetails = await userCardActionsBl.GetUserCardActionsAsync(userId, cardNumber);

			if (userCardActionsDetails == null)
			{
				return NotFound("User card not found.");
			}

			return Ok(userCardActionsDetails);
		}
	}
}