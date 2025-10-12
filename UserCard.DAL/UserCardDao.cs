using UserCard.Common;
using UserCard.Common.PublicInterfaces;
using UserCard.DAL.Services;

namespace UserCard.DAL
{
	public class UserCardDao : IUserCardDao
	{
		public async Task<CardDetails?> GetCardDetails(string userId, string cardNumber)
		{
			var cardService = new CardService();
			return await cardService.GetCardDetails(userId, cardNumber);
		}
	}
}