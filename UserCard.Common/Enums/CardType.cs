using System.Text.Json.Serialization;

namespace UserCard.Common.Enums
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum CardType
	{
		Prepaid,
		Debit,
		Credit
	}
}
