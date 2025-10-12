using UserCard.Common;
using UserCard.Common.PublicInterfaces;
using UserCard.DAL.Services;

namespace UserCard.DAL
{
	public class ActionsCardDao : IActionsCardDao
	{
		public async Task<List<ActionsCard>> GetActionsCard(CardDetails card)
		{
			var actionsCardService = new ActionsCardService();
			return await actionsCardService.Get(card);
		}
	}
}
