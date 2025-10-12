namespace UserCard.Common.PublicInterfaces
{
	public interface IUserCardDao
	{
		Task<CardDetails?> GetCardDetails(string userId, string cardNumber); 
	}
}