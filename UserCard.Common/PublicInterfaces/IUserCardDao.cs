namespace UserCard.Common.PublicInterfaces
{
	public interface IUserCardDao
	{
		Task<CardDetails?> GetCardDetailsAsync(string userId, string cardNumber); 
	}
}