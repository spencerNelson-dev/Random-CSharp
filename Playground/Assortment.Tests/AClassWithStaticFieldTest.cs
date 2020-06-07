using System;
using Xunit;

namespace Assortment.Tests
{
    public class AClassWithStaticFieldTest
    {
        private AClassWithStaticField _classWithStatic;

        [Fact]
        public void TheStaticFieldUpdatesWhenObjectCallsMethod()
        {
            _classWithStatic = new AClassWithStaticField();

            _classWithStatic.AddOneToCount();

            Assert.Equal(1, AClassWithStaticField.count);
        }
    }
}
