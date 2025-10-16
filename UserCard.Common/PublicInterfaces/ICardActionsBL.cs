using UserCard.Common.Enums;
using Action = UserCard.Common.Enums.Action;

namespace UserCard.Common.PublicInterfaces
{
	public interface ICardActionsBL
	{
		Task<List<Action>> GetCardActionsAsync(CardType cardType, CardStatus cardStatus, bool isPinSet);
	}
}
