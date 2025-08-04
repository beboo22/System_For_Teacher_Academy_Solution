using System.Runtime.Serialization;

namespace Domin.Enums
{
    public enum PaymentStatus
    {
        [EnumMember(Value = "Pending")]
        Pending = 0,
        [EnumMember(Value = "Completed")]
        Completed = 1,
        [EnumMember(Value = "Failed")]
        Failed = 2,
        [EnumMember(Value = "Refunded")]
        Refunded = 3,
        [EnumMember(Value = "Cancelled")]
        Cancelled = 4
    }
}