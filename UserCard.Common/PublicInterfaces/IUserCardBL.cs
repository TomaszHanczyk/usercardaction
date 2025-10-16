namespace UserCard.Common.PublicInterfaces
{
	public interface IUserCardBL
	{
		Task<CardDetails?> GetCardDetailsAsync(string userId, string cardNumber);
	}
}