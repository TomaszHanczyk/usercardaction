using UserCard.Common.Enums;
using Action = UserCard.Common.Enums.Action;

namespace UserCard.Common
{
	public class ActionsCard
	{
		public Action Action;
		public List<CardType> CardType;
		public Dictionary<CardStatus, bool?> CardStatusWithPinRequirement;
	}
}