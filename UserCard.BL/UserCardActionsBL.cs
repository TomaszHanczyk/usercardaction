using UserCard.Common;
using UserCard.Common.PublicInterfaces;
using Action = UserCard.Common.Enums.Action;

namespace UserCard.BL
{
	public class UserCardActionsBL(ICardActionsBL cardActionsBl, IUserCardBL userCardBl) : IUserCardActionsBL
	{
		public async Task<UserCardActionsDetails?> GetUserCardActionsAsync(string userId, string cardNumber)
		{
			CardDetails? cardDetails = await userCardBl.GetCardDetailsAsync(userId, cardNumber);

			if (cardDetails == null)
			{
				return null;
			}

			List<Action> cardActions = await cardActionsBl.GetCardActionsAsync(cardDetails.CardType, cardDetails.CardStatus, cardDetails.IsPinSet);

			return new UserCardActionsDetails(cardDetails, cardActions);
		}
	}
}
