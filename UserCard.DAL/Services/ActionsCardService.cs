using UserCard.Common;
using UserCard.Common.Enums;
using Action = UserCard.Common.Enums.Action;

namespace UserCard.DAL.Services
{
	public class ActionsCardService
	{
		private readonly List<ActionsCard> _actionsCard = CreateSampleActionsCard();
		public async Task<List<ActionsCard>> Get(CardDetails card)
		{
			// At this point, we would typically make an HTTP call to an external service
			// to fetch the data. For this example we use generated sample data.
			await Task.Delay(1000);

			var actionsCard = _actionsCard.Where(ac =>
					ac.CardType.Contains(card.CardType) &&
					CardStatusMatched(ac.CardStatusWithPinRequirement, card.CardStatus, card.IsPinSet)).ToList();

			return actionsCard;
		}

		private static bool CardStatusMatched(Dictionary<CardStatus, bool?> cardStatusWithPinRequirement, CardStatus cardStatus, bool isPinSet)
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

		private static List<ActionsCard> CreateSampleActionsCard()
		{
			return
			[
				new ActionsCard
				{
					Action = Action.ACTION1,
					CardType = [CardType.Prepaid, CardType.Debit, CardType.Credit],
					CardStatusWithPinRequirement = new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Active, null },
					}
				},
				new ActionsCard
				{
					Action = Action.ACTION2,
					CardType = [CardType.Prepaid, CardType.Debit, CardType.Credit],
					CardStatusWithPinRequirement = new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Inactive, null },
					}
				},
				new ActionsCard
				{
					Action = Action.ACTION3,
					CardType = [CardType.Prepaid, CardType.Debit, CardType.Credit],
					CardStatusWithPinRequirement = new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, null },
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
						{ CardStatus.Restricted, null },
						{ CardStatus.Blocked, null },
						{ CardStatus.Expired, null },
						{ CardStatus.Closed, null },
					}
				},
				new ActionsCard
				{
					Action = Action.ACTION4,
					CardType = [CardType.Prepaid, CardType.Debit, CardType.Credit],
					CardStatusWithPinRequirement = new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, null },
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
						{ CardStatus.Restricted, null },
						{ CardStatus.Blocked, null },
						{ CardStatus.Expired, null },
						{ CardStatus.Closed, null },
					}
				},
				new ActionsCard
				{
					Action = Action.ACTION5,
					CardType = [CardType.Credit],
					CardStatusWithPinRequirement = new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, null },
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
						{ CardStatus.Restricted, null },
						{ CardStatus.Blocked, null },
						{ CardStatus.Expired, null },
						{ CardStatus.Closed, null },
					}
				},
				new ActionsCard
				{
					Action = Action.ACTION6,
					CardType = [CardType.Prepaid, CardType.Debit, CardType.Credit],
					CardStatusWithPinRequirement = new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, true },
						{ CardStatus.Inactive, true },
						{ CardStatus.Active, true },
						{ CardStatus.Blocked, true },
					}
				},
				new ActionsCard
				{
					Action = Action.ACTION7,
					CardType = [CardType.Prepaid, CardType.Debit, CardType.Credit],
					CardStatusWithPinRequirement = new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, false },
						{ CardStatus.Inactive, false },
						{ CardStatus.Active, false },
						{ CardStatus.Blocked, true },
					}
				},
				new ActionsCard
				{
					Action = Action.ACTION8,
					CardType = [CardType.Prepaid, CardType.Debit, CardType.Credit],
					CardStatusWithPinRequirement = new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, null },
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
						{ CardStatus.Blocked, null },
					}
				},
				new ActionsCard
				{
					Action = Action.ACTION9,
					CardType = [CardType.Prepaid, CardType.Debit, CardType.Credit],
					CardStatusWithPinRequirement = new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, null },
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
						{ CardStatus.Restricted, null },
						{ CardStatus.Blocked, null },
						{ CardStatus.Expired, null },
						{ CardStatus.Closed, null },
					}
				},
				new ActionsCard
				{
					Action = Action.ACTION10,
					CardType = [CardType.Prepaid, CardType.Debit, CardType.Credit],
					CardStatusWithPinRequirement = new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, null },
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
					}
				},
				new ActionsCard
				{
					Action = Action.ACTION11,
					CardType = [CardType.Prepaid, CardType.Debit, CardType.Credit],
					CardStatusWithPinRequirement = new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
					}
				},
				new ActionsCard
				{
					Action = Action.ACTION12,
					CardType = [CardType.Prepaid, CardType.Debit, CardType.Credit],
					CardStatusWithPinRequirement = new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, null },
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
					}
				},
				new ActionsCard
				{
					Action = Action.ACTION13,
					CardType = [CardType.Prepaid, CardType.Debit, CardType.Credit],
					CardStatusWithPinRequirement = new Dictionary<CardStatus, bool?>
					{
						{ CardStatus.Ordered, null },
						{ CardStatus.Inactive, null },
						{ CardStatus.Active, null },
					}
				},
			];
		}
	}
}
