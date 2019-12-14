
namespace UpperBoundLimitedCollections.Tests.Factories
{
    public static class DataFactory
    {
        public static UpperBoundLimitedList<string> GenerateStandardUpperBoundLimitedList()
        {
            return new UpperBoundLimitedList<string>(3) { "1", "2", "3" };
        }
    }
}
