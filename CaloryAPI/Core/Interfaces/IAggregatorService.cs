namespace Core.Interfaces
{
    public interface IAggregatorService
    {
        public bool IsValidFieldName(string fieldName);
        public bool IsValidFilter(string filter);
        public int AggregateValues(string fieldName, string filter = null);
    }
}
