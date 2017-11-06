using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Shouldly;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Commands;
using StackMechanics.StackCafe.Domain.Infrastructure;
using StackMechanics.StackCafe.Infrastructure;

namespace StackMechanics.StackCafe.Tests.Unit.Conventions
{
    public class EachCommandType
    {
        private static readonly Assembly _assembly = typeof(SignUpCustomerCommand).Assembly;

        private static readonly IEnumerable<TypeInfo> _commandTypes = _assembly
            .DefinedTypes
            .Where(t => !t.IsInterface)
            .Where(t => !t.IsAbstract)
            .Where(t => typeof(ICommand).IsAssignableFrom(t))
            .ToArray();

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void HasExactlyOneHandlerWithACorrespondingName(Type commandType)
        {
            var handlerInterface = typeof(IHandleCommand<>).MakeGenericType(commandType);
            var handlerTypes = _assembly
                .DefinedTypes
                .Where(t => handlerInterface.IsAssignableFrom(t))
                .ToArray();

            handlerTypes.ShouldHaveSingleItem();

            var handlerType = handlerTypes.Single();
            var expectedHandlerName = $"{commandType.Name}Handler";
            handlerType.Name.ShouldBe(expectedHandlerName);
        }

        private static IEnumerable<TestCaseData> TestCases()
        {
            return _commandTypes
                .Select(t => new TestCaseData(t)
                    .SetName(t.FullName));
        }
    }
}
