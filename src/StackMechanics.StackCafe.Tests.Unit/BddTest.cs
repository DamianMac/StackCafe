using NUnit.Framework;

namespace StackMechanics.StackCafe.Tests.Unit
{
    public abstract class BddTest
    {
        [SetUp]
        public virtual void SetUp()
        {
            Given();
            When();
        }

        protected abstract void Given();
        protected abstract void When();
    }
}