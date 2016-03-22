namespace FoodBank.Core.Data.Enum
{
    public enum OrderItemStatus
    {
        NotSet = 0,
        Requested = 10,
        Confirmed = 20,
        Completed = 90,
        Cancelled = 100,
    }
}