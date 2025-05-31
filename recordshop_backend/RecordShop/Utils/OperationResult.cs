namespace RecordShop.Backend.Utils
{
    public enum OperationResult
    {
        Success,
        Failure
    }

    public class OperationStatus
    {
        public OperationResult Status { get; set; }
    }
}
