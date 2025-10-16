namespace UserCard.Common.PublicInterfaces
{
	public interface ICardService
	{
		Task<CardDetails?> GetCardDetailsAsync(string userId, string cardNumber);
	}
}
