using System.Text.Json.Serialization;

namespace UserCard.Common.Enums
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum CardStatus
	{
		Ordered,
		Inactive,
		Active,
		Restricted,
		Blocked,
		Expired,
		Closed
	}
}
