namespace RecordShop.Backend.Utils
{
    public enum OperationResult
    {
        Success,
        Failure
    }

    public enum OrderStatus
    {
        Draft,
        AwaitingPayment,
        Processing,
        Purchased,
        Shipped,
        Delivered,
        Cancelled,
        OnHold,
        Failed,
        Refunded,
        PartiallyRefunded,
        Returned
    }

    public class OperationStatus
    {
        public OperationResult Status { get; set; }
    }
}
