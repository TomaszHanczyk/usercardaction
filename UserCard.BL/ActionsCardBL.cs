using UserCard.Common;
using UserCard.Common.PublicInterfaces;
using Action = UserCard.Common.Enums.Action;

namespace UserCard.BL
{
	public class ActionsCardBL(IActionsCardDao actionsCardDao, IUserCardBL userCardBl) : IActionsCardBL
	{
		public ActionCardDetails? GetCardActions(string userId, string cardNumber)
		{
			var cardDetails = GetCardDetails(userId, cardNumber);

			if (cardDetails.Result == null)
				return new ActionCardDetails(null, []);

			var actionsCard = GetActionsCard(cardDetails.Result);

			return new ActionCardDetails(cardDetails.Result,
				actionsCard.Result == null
					? []
					: actionsCard.Result.Select(a => a.Action).Distinct().ToList());
		}

		private async Task<CardDetails?> GetCardDetails(string userId, string cardNumber)
		{
			var cardDetails = userCardBl.GetCardDetails(userId, cardNumber);

			await cardDetails;

			return cardDetails.Result;
		}

		private async Task<List<ActionsCard>?> GetActionsCard(CardDetails? card)
		{
			if (card == null)
				return null;

			var actionsCard = actionsCardDao.GetActionsCard(card);

			await actionsCard;

			return actionsCard.Result;
		}
	}
}