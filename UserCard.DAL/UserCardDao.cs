using UserCard.Common;
using UserCard.Common.PublicInterfaces;

namespace UserCard.DAL
{
	public class UserCardDao(ICardService cardService) : IUserCardDao
	{
		public async Task<CardDetails?> GetCardDetailsAsync(string userId, string cardNumber)
		{
			return await cardService.GetCardDetailsAsync(userId, cardNumber);
		}
	}
}