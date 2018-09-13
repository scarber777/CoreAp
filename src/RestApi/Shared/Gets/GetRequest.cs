namespace RestApi.Shared.Gets
{
    public class GetRequest
    {
        //set with defaults
        public int PageNumber { get; set; } = 1;
        public int NumberOfRecords { get; set; } = 50;
    }
}
