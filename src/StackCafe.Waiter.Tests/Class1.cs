using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;
using StackCafe.Waiter.Models;

namespace StackCafe.Waiter.Tests
{
    public class AllWriteablePropertiesOnModels
    {
        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void ShouldBeProtected(PropertyInfo property)
        {
            property.SetMethod.IsPublic.ShouldBeFalse();
            property.SetMethod.IsPrivate.ShouldBeFalse();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void ShouldBeVirtual(PropertyInfo property)
        {
            property.SetMethod.IsVirtual.ShouldBeTrue();
        }

        public static IEnumerable<TestCaseData> TestCases()
        {
            var modelTypes = typeof(Order)
                .Assembly
                .DefinedTypes
                .Where(t => t.Namespace.StartsWith(typeof(Order).Namespace))
                .ToArray();

            var properties = modelTypes
                .SelectMany(t => t.GetProperties())
                .Where(p => p.CanWrite)
                .ToArray();

            var testCases = properties
                .Select(p => new TestCaseData(p).SetName($"{p.DeclaringType.Name}.{p.Name}"))
                .ToArray();

            return testCases;
        }

    }
}
