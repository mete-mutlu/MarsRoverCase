using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Tests
{

    public class InlineDataWithAutoMoqAttribute : InlineAutoDataAttribute
    {
        public InlineDataWithAutoMoqAttribute(params object[] objects) : base(new AutoMockAttribute(), objects) { }
    }
}
