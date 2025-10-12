namespace UserCard.Common.PublicInterfaces
{
	public interface IUserCardBL
	{
		Task<CardDetails?> GetCardDetails(string userId, string cardNumber);
	}
}