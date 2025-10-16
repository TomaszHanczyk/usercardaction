using UserCard.Common.Enums;

namespace UserCard.Common.PublicInterfaces
{
	public interface ICardActionsService
	{
		Task<List<CardActions>> GetAsync(CardType cardType, CardStatus cardStatus, bool isPinSet);
	}
}
