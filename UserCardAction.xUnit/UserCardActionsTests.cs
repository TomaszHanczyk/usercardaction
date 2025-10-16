using UserCard.BL;
using UserCard.Common;
using UserCard.Common.PublicInterfaces;
using UserCard.DAL;
using UserCard.DAL.Services;
using Action = UserCard.Common.Enums.Action;

namespace UserCardAction.xUnit
{
	public class UserCardActionsTests
	{
		private readonly IUserCardActionsBL _userCardActionsBl;

		// Setup
		public UserCardActionsTests()
		{
			ICardActionsService cardActionsService = new CardActionsService();
			ICardActionsDao cardActionsDao = new CardActionsDao(cardActionsService);
			ICardActionsBL cardActionsBl = new CardActionsBL(cardActionsDao);

			ICardService cardService = new CardService();
			IUserCardDao userCardDao = new UserCardDao(cardService);
			IUserCardBL userCardBl = new UserCardBL(userCardDao);

			_userCardActionsBl = new UserCardActionsBL(cardActionsBl, userCardBl);
		}

		[Fact]
		public async Task GetUserCardActionsAsync_ValueOfExistingUser_ReturnsCorrectCardActions()
		{
			// Arrange
			const string userId = "User1";
			const string cardNumber = "Card118";
			var expectedActions = new List<Action> { Action.ACTION3, Action.ACTION4, Action.ACTION5, Action.ACTION9 };

			// Act
			UserCardActionsDetails? userCardActionsDetails = await _userCardActionsBl.GetUserCardActionsAsync(userId, cardNumber);

			// Assert
			Assert.NotNull(userCardActionsDetails);
			Assert.Equal(userCardActionsDetails.CardDetails.CardNumber, cardNumber);
			Assert.True(userCardActionsDetails.CardActions.OrderBy(t => t).SequenceEqual(expectedActions.OrderBy(t => t)));
		}

		[Fact]
		public async Task GetUserCardActionsAsync_ValueOfNonExistingUser_ReturnsNull()
		{
			// Arrange
			const string userId = "User7";
			const string cardNumber = "Card118";

			// Act
			UserCardActionsDetails? userCardActionsDetails = await _userCardActionsBl.GetUserCardActionsAsync(userId, cardNumber);

			// Assert
			Assert.Null(userCardActionsDetails);
		}
	}
}
