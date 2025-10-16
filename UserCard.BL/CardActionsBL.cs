using UserCard.Common;
using UserCard.Common.Enums;
using UserCard.Common.PublicInterfaces;
using Action = UserCard.Common.Enums.Action;

namespace UserCard.BL
{
	public class CardActionsBL(ICardActionsDao cardActionsDao) : ICardActionsBL
	{
		public async Task<List<Action>> GetCardActionsAsync(CardType cardType, CardStatus cardStatus, bool isPinSet)
		{
			List<CardActions> cardActions = await cardActionsDao.GetCardActionsAsync(cardType, cardStatus, isPinSet);

			return cardActions.Select(a => a.Action).Distinct().ToList();
		}
	}
}