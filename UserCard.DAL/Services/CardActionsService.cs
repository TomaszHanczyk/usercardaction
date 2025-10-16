using UserCard.Common;
using UserCard.Common.Enums;
using UserCard.Common.PublicInterfaces;
using Action = UserCard.Common.Enums.Action;

namespace UserCard.DAL.Services
{
	public class CardActionsService : ICardActionsService
	{
		private readonly List<CardActions> _cardActions = CreateSampleCardActions();
		public async Task<List<CardActions>> GetAsync(CardType cardType, CardStatus cardStatus, bool isPinSet)
		{
			// At this point, we would typically make an HTTP call to an external service
			// to fetch the data. For this example we use generated sample data.
			await Task.Delay(1000);

			var cardActions = _cardActions.Where(ac =>
					ac.CardType.Contains(cardType) &&
					CardStatusMatched(ac.CardStatusWithPinRequirement, cardStatus, isPinSet)).ToList();

			return cardActions;
		}

		private static bool CardStatusMatched(IReadOnlyDictionary<CardStatus, bool?> cardStatusWithPinRequirement, CardStatus cardStatus, bool isPinSet)
		{
			if (cardStatusWithPinRequirement.TryGetValue(cardStatus, out bool? isPinShouldBeSet))
			{
				if (isPinShouldBeSet.HasValue)
				{
					return isPinShouldBeSet == isPinSet;
				}

				return true;
			}

			return false;
		}

		private static List<CardActions> CreateSampleCardActions()
		{
			return
			[
				new CardActions(
					Action.ACTION1,
					[CardType.Prepaid, CardType.Debit, CardType.Credit],
					new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Active, null },
					}
				),
				new CardActions(
					Action.ACTION2,
					[CardType.Prepaid, CardType.Debit, CardType.Credit],
					new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Inactive, null },
					}
				),
				new CardActions
				(
					Action.ACTION3,
					[CardType.Prepaid, CardType.Debit, CardType.Credit],
					new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, null },
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
						{ CardStatus.Restricted, null },
						{ CardStatus.Blocked, null },
						{ CardStatus.Expired, null },
						{ CardStatus.Closed, null },
					}
				),
				new CardActions
				(
					Action.ACTION4,
					[CardType.Prepaid, CardType.Debit, CardType.Credit],
					new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, null },
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
						{ CardStatus.Restricted, null },
						{ CardStatus.Blocked, null },
						{ CardStatus.Expired, null },
						{ CardStatus.Closed, null },
					}
				),
				new CardActions
				(
					Action.ACTION5,
					[CardType.Credit],
					new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, null },
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
						{ CardStatus.Restricted, null },
						{ CardStatus.Blocked, null },
						{ CardStatus.Expired, null },
						{ CardStatus.Closed, null },
					}
				),
				new CardActions
				(
					Action.ACTION6,
					[CardType.Prepaid, CardType.Debit, CardType.Credit],
					new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, true },
						{ CardStatus.Inactive, true },
						{ CardStatus.Active, true },
						{ CardStatus.Blocked, true },
					}
				),
				new CardActions
				(
					Action.ACTION7,
					[CardType.Prepaid, CardType.Debit, CardType.Credit],
					new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, false },
						{ CardStatus.Inactive, false },
						{ CardStatus.Active, false },
						{ CardStatus.Blocked, true },
					}
				),
				new CardActions
				(
					Action.ACTION8,
					[CardType.Prepaid, CardType.Debit, CardType.Credit],
					new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, null },
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
						{ CardStatus.Blocked, null },
					}
				),
				new CardActions
				(
					Action.ACTION9,
					[CardType.Prepaid, CardType.Debit, CardType.Credit],
					new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, null },
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
						{ CardStatus.Restricted, null },
						{ CardStatus.Blocked, null },
						{ CardStatus.Expired, null },
						{ CardStatus.Closed, null },
					}
				),
				new CardActions
				(
					Action.ACTION10,
					[CardType.Prepaid, CardType.Debit, CardType.Credit],
					new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, null },
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
					}
				),
				new CardActions
				(
					Action.ACTION11,
					[CardType.Prepaid, CardType.Debit, CardType.Credit],
					new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
					}
				),
				new CardActions
				(
					Action.ACTION12,
					[CardType.Prepaid, CardType.Debit, CardType.Credit],
					new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, null },
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
					}
				),
				new CardActions
				(
					Action.ACTION13,
					[CardType.Prepaid, CardType.Debit, CardType.Credit],
					new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, null },
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
					}
				),
			];
		}
	}
}
