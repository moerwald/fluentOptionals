﻿using FluentAssertions;
using NUnit.Framework;

namespace FluentOptionals.Tests.Compositions
{
    [TestFixture]
    public class Optional4Tests
    {
        [Test]
        public void IfNone_WhenOneOptionalIsNone_ThenIfSomeHandleGetsCalled()
        {
            var noneHandleCalled = false;

            Optional.From(1)
                .Join(2)
                .Join(3)
                .Join(Optional.None<int>())
                .IfNone(() => noneHandleCalled = true);

            noneHandleCalled.Should().BeTrue();
        }

        [Test]
        public void IfSome_WhenAllOptionalsAreSome_ThenIfSomeHandleGetsCalled()
        {
            var someHandleCalled = false;

            Optional.From(1)
                .Join(2)
                .Join(3)
                .Join(4)
                .IfSome((p1, p2, p3, p4) => someHandleCalled = true);

            someHandleCalled.Should().BeTrue();
        }

        [Test]
        public void IsNone_WhenOneOptionalIsNone_ThenIsNoneIsTrue()
        {
            Optional.From(1)
                .Join(2)
                .Join(3)
                .Join(Optional.None<int>())
                .IsNone.Should().BeTrue();
        }

        [Test]
        public void IsSome_WhenAlOptionalsAreSome_ThenIsSomeIsTrue()
        {
            Optional.From(1)
                .Join(2)
                .Join(3)
                .Join(4)
                .IsSome.Should().BeTrue();
        }

        [Test]
        public void Match_WhenAllOptionalsAreSome_ThenHandleGetsRightParameters()
        {
            var someHandleCalled = false;
            var noneHandleCalled = false;

            Optional.From(1)
                .Join(2)
                .Join(3)
                .Join(4)
                .Match(
                    (p1, p2, p3, p4) =>
                    {
                        someHandleCalled = true;
                        p1.Should().Be(1);
                        p2.Should().Be(2);
                        p3.Should().Be(3);
                        p4.Should().Be(4);
                    },
                    () => noneHandleCalled = true
                );

            someHandleCalled.Should().BeTrue();
            noneHandleCalled.Should().BeFalse();
        }

        [Test]
        public void Match_WhenAllOptionalsAreSome_ThenMatchReturnsSomeValue()
        {
            var x =
                Optional.From(1)
                    .Join(2)
                    .Join(3)
                    .Join(4)
                    .Match(
                        (p1, p2, p3, p4) => "some",
                        () => "none"
                    );

            x.Should().Be("some");
        }

        [Test]
        public void Match_WhenAllOptionalsAreSome_ThenSomeHandleGetsCalled()
        {
            var someHandleCalled = false;
            var noneHandleCalled = false;

            Optional.From(1)
                .Join(2)
                .Join(3)
                .Join(4)
                .Match(
                    (p1, p2, p3, p4) => someHandleCalled = true,
                    () => noneHandleCalled = true
                );

            someHandleCalled.Should().BeTrue();
            noneHandleCalled.Should().BeFalse();
        }


        [Test]
        public void Match_WhenOneOptionalIsNone_ThenMatchReturnsNoneValue()
        {
            var x =
                Optional.From(1)
                    .Join(2)
                    .Join(3)
                    .Join(Optional.None<int>())
                    .Match(
                        (p1, p2, p3, p4) => "some",
                        () => "none"
                    );

            x.Should().Be("none");
        }

        [Test]
        public void Match_WhenOneOptionalsNone_ThenNoneHandleGetsCalled()
        {
            var someHandleCalled = false;
            var noneHandleCalled = false;

            Optional.From(1)
                .Join(2)
                .Join(3)
                .Join(Optional.None<string>())
                .Match(
                    (p1, p2, p3, p4) => someHandleCalled = true,
                    () => noneHandleCalled = true
                );

            noneHandleCalled.Should().BeTrue();
            someHandleCalled.Should().BeFalse();
        }
    }
}