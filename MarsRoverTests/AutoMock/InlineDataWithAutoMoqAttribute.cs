using AutoFixture.Xunit2;

namespace MarsRover.Tests
{

    public class InlineDataWithAutoMoqAttribute : InlineAutoDataAttribute
    {
        public InlineDataWithAutoMoqAttribute(params object[] objects) : base(new AutoMockAttribute(), objects) { }
    }
}
