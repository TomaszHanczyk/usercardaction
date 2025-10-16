using UserCard.Common;
using UserCard.Common.PublicInterfaces;

namespace UserCard.BL
{
	public class UserCardBL(IUserCardDao userCardDao) : IUserCardBL
	{
		public Task<CardDetails?> GetCardDetailsAsync(string userId, string cardNumber)
		{
			return userCardDao.GetCardDetailsAsync(userId, cardNumber);
		}
	}
}