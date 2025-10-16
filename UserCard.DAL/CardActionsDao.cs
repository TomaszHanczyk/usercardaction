using UserCard.Common;
using UserCard.Common.Enums;
using UserCard.Common.PublicInterfaces;

namespace UserCard.DAL
{
	public class CardActionsDao(ICardActionsService cardActionsService) : ICardActionsDao
	{
		public async Task<List<CardActions>> GetCardActionsAsync(CardType cardType, CardStatus cardStatus, bool isPinSet)
		{
			return await cardActionsService.GetAsync(cardType, cardStatus, isPinSet);
		}
	}
}
