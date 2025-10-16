namespace UserCard.Common.PublicInterfaces
{
	public interface IUserCardActionsBL
	{
		Task<UserCardActionsDetails?> GetUserCardActionsAsync(string userId, string cardNumber);
	}
}
