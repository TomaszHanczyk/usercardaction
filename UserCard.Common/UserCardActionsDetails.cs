using Action = UserCard.Common.Enums.Action;

namespace UserCard.Common
{
	public record UserCardActionsDetails(CardDetails CardDetails, List<Action> CardActions);
}
