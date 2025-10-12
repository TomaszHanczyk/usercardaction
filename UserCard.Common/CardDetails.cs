using UserCard.Common.Enums;

namespace UserCard.Common
{
	public record CardDetails(string CardNumber, CardType CardType, CardStatus CardStatus, bool IsPinSet);
}
