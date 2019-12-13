
namespace UpperBoundLimitedCollections.Tests.Factory
{
    public static class UpperBoundLimitedListFactory
    {
        public static UpperBoundLimitedList<string> GenerateStandardUpperBoundLimitedList()
        {
            return new UpperBoundLimitedList<string>(3) { "1", "2", "3" };
        }
    }
}
