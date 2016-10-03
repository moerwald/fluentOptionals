﻿using FluentAssertions;
using NUnit.Framework;

namespace FluentOptionals.Tests
{
    [TestFixture]
    public class Optional3Tests
    {
        [Test]
        public void Match_WhenAllOptionalsAreSome_ThenSomeHandleGetsCalled()
        {
            var someHandleCalled = false;
            var noneHandleCalled = false;

            Optional.From(1)
                    .Join(2)
                    .Join(3)
                    .Match(
                        some: (p1, p2, p3) => someHandleCalled = true,
                        none: () => noneHandleCalled = true
                    );

            someHandleCalled.Should().BeTrue();
            noneHandleCalled.Should().BeFalse();
        }

        [Test]
        public void Match_WhenOneOptionalsNone_ThenNoneHandleGetsCalled()
        {
            var someHandleCalled = false;
            var noneHandleCalled = false;

            Optional.From(1)
                    .Join(2)
                    .Join(Optional.None<string>())
                    .Match(
                        some: (p1, p2, p3) => someHandleCalled = true,
                        none: () => noneHandleCalled = true
                    );

            noneHandleCalled.Should().BeTrue();
            someHandleCalled.Should().BeFalse();
        }

        [Test]
        public void Match_WhenAllOptionalsAreSome_ThenHandleGetsRightParamters()
        {
            var someHandleCalled = false;
            var noneHandleCalled = false;

            Optional.From(1)
                    .Join(2)
                    .Join(3)
                    .Match(
                        some: (p1, p2, p3) =>
                        {
                            someHandleCalled = true;
                            p1.Should().Be(1);
                            p2.Should().Be(2);
                            p3.Should().Be(3);
                        },
                        none: () => noneHandleCalled = true
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
                        .Match(
                            some: (p1, p2, p3) => "some",
                            none: () => "none"
                        );

            x.Should().Be("some");
        }


        [Test]
        public void Match_WhenOneOptionalIsNone_ThenMatchReturnsNoneValue()
        {
            var x =
                Optional.From(1)
                        .Join(2)
                        .Join(Optional.None<int>())
                        .Match(
                            some: (pp1, p2, p3) => "some",
                            none: () => "none"
                        );

            x.Should().Be("none");
        }

        [Test]
        public void MatchNone_WhenOneOptionalIsNone_ThenMatchSomeHandleGetsCalled()
        {
            var noneHandleCalled = false;

            Optional.From(1)
                .Join(2)
                .Join(Optional.None<int>())
                .MatchNone(() => noneHandleCalled = true);

            noneHandleCalled.Should().BeTrue();
        }

        [Test]
        public void MatchSome_WhenAllOptionalsAreSome_ThenMatchSomeHandleGetsCalled()
        {
            var someHandleCalled = false;

            Optional.From(1)
                .Join(2)
                .Join(3)
                .MatchSome((p1, p2, p3) => someHandleCalled = true);

            someHandleCalled.Should().BeTrue();
        }

        [Test]
        public void IsNone_WhenOneOptionalIsNone_ThenIsNoneIsTrue()
        {
            Optional.From(1)
                .Join(2)
                .Join(Optional.None<int>())
                .IsNone.Should().BeTrue();
        }

        [Test]
        public void IsSome_WhenAlOptionalsAreSome_ThenIsSomeIsTrue()
        {
            Optional.From(1)
                .Join(2)
                .Join(3)
                .IsSome.Should().BeTrue();
        }
    }
}