using Action = UserCard.Common.Enums.Action;

namespace UserCard.Common
{
	public record ActionCardDetails(CardDetails CardDetails, List<Action> CardActions);
}
