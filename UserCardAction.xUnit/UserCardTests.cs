using UserCard.BL;
using UserCard.Common;
using UserCard.Common.PublicInterfaces;
using UserCard.DAL;
using UserCard.DAL.Services;

namespace UserCardAction.xUnit
{
	public class UserCardTests
	{
		private readonly IUserCardBL _userCardBl;

		// Setup
		public UserCardTests()
		{
			ICardService cardService = new CardService();
			IUserCardDao userCardDao = new UserCardDao(cardService);
			_userCardBl = new UserCardBL(userCardDao);
		}

		[Fact]
		public async Task GetCardDetailsAsync_ValueOfExistingUser_ReturnsUserCardDetails()
		{
			// Arrange
			const string userId = "User1";
			const string cardNumber = "Card118";

			// Act
			CardDetails? cardDetails = await _userCardBl.GetCardDetailsAsync(userId, cardNumber);

			// Assert
			Assert.NotNull(cardDetails);
			Assert.Equal(cardNumber, cardDetails.CardNumber);
		}

		[Fact]
		public async Task GetCardDetailsAsync_ValueOfNonExistingUser_ReturnsNull()
		{
			// Arrange
			const string userId = "User5";
			const string cardNumber = "Card118";

			// Act
			CardDetails? cardDetails = await _userCardBl.GetCardDetailsAsync(userId, cardNumber);

			// Assert
			Assert.Null(cardDetails);
		}
	}
}