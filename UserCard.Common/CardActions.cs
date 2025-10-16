using UserCard.Common.Enums;
using Action = UserCard.Common.Enums.Action;

namespace UserCard.Common
{
	public class CardActions(Action action, List<CardType> cardType, Dictionary<CardStatus, bool?> cardStatusWithPinRequirement)
	{
		public readonly Action Action = action;
		public readonly List<CardType> CardType = cardType;
		public readonly Dictionary<CardStatus, bool?> CardStatusWithPinRequirement = cardStatusWithPinRequirement;
	}
}