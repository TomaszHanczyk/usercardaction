using UserCard.BL;
using UserCard.Common.Enums;
using UserCard.Common.PublicInterfaces;
using UserCard.DAL;
using UserCard.DAL.Services;
using Action = UserCard.Common.Enums.Action;

namespace UserCardAction.xUnit
{
	public class CardActionsTests
	{
		private readonly ICardActionsBL _cardActionsBl;

		// Setup
		public CardActionsTests()
		{
			ICardActionsService cardActionsService = new CardActionsService();
			ICardActionsDao cardActionsDao = new CardActionsDao(cardActionsService);
			_cardActionsBl = new CardActionsBL(cardActionsDao);
		}

		[Fact]
		public async Task GetCardActionsAsync_WithPrepaidTypeAndClosedStatus_ReturnsCorrectActions()
		{
			// Arrange
			const CardType cardType = CardType.Prepaid;
			const CardStatus cardStatus = CardStatus.Closed;
			const bool isPinSet = false;
			var expectedActions = new List<Action> { Action.ACTION3, Action.ACTION4, Action.ACTION9 };

			// Act
			List<Action> actions = await _cardActionsBl.GetCardActionsAsync(cardType, cardStatus, isPinSet);

			// Assert
			Assert.True(actions.OrderBy(t => t).SequenceEqual(expectedActions.OrderBy(t => t)));
		}

		[Fact]
		public async Task GetCardActionsAsync_WithCreditTypeAndBlockedStatusAndSetPin_ReturnsCorrectActions()
		{
			// Arrange
			const CardType cardType = CardType.Credit;
			const CardStatus cardStatus = CardStatus.Blocked;
			const bool isPinSet = true;
			var expectedActions = new List<Action>
			{
				Action.ACTION3, Action.ACTION4, Action.ACTION5, Action.ACTION6, Action.ACTION7, Action.ACTION8,
				Action.ACTION9
			};

			// Act
			List<Action> actions = await _cardActionsBl.GetCardActionsAsync(cardType, cardStatus, isPinSet);

			// Assert
			Assert.True(actions.OrderBy(t => t).SequenceEqual(expectedActions.OrderBy(t => t)), "");
		}

		[Fact]
		public async Task GetCardActionsAsync_WithDebitTypeAndInactiveStatusAndNotSetPin_ReturnsCorrectActions()
		{
			// Arrange
			const CardType cardType = CardType.Debit;
			const CardStatus cardStatus = CardStatus.Inactive;
			const bool isPinSet = false;
			var expectedActions = new List<Action>
			{
				Action.ACTION2, Action.ACTION3, Action.ACTION4, Action.ACTION7, Action.ACTION8, 
				Action.ACTION9, Action.ACTION10, Action.ACTION11, Action.ACTION12, Action.ACTION13
			};

			// Act
			List<Action> actions = await _cardActionsBl.GetCardActionsAsync(cardType, cardStatus, isPinSet);

			// Assert
			Assert.True(actions.OrderBy(t => t).SequenceEqual(expectedActions.OrderBy(t => t)));
		}
	}
}
