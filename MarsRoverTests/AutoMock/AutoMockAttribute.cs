using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace MarsRover.Tests
{
    public class AutoMockAttribute : AutoDataAttribute
    {
        public AutoMockAttribute()
            : base(() => new Fixture().Customize(new AutoMoqCustomization())) { }
    }
}
