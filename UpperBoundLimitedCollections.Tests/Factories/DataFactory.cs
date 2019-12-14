
namespace UpperBoundLimitedCollections.Tests.Factories
{
    public static class DataFactory
    {
        public static StrictUpperBoundLimitedList<string> GenerateStandardUpperBoundLimitedList()
        {
            return new StrictUpperBoundLimitedList<string>(3) { "1", "2", "3" };
        }
    }
}
