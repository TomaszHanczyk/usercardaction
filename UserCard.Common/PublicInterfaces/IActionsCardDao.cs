namespace UserCard.Common.PublicInterfaces
{
	public interface IActionsCardDao
	{
		Task<List<ActionsCard>> GetActionsCard(CardDetails card);
	}
}
