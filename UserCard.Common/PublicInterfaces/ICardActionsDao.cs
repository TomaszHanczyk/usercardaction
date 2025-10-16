using UserCard.Common.Enums;

namespace UserCard.Common.PublicInterfaces
{
	public interface ICardActionsDao
	{
		Task<List<CardActions>> GetCardActionsAsync(CardType cardType, CardStatus cardStatus, bool isPinSet);
	}
}
