using Action = UserCard.Common.Enums.Action;

namespace UserCard.Common.PublicInterfaces
{
	public interface IActionsCardBL
	{
		ActionCardDetails? GetCardActions(string userId, string cardNumber);
	}
}
