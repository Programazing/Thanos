using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Thanos.Common;

namespace Thanos.Tests
{
    [TestFixture]
    class Thanos
    {
        Common.Thanos thanos;

        [Test]
        public void Thanos_IsAPerson()
        {
            thanos = new Common.Thanos();
            var sut = thanos is IPerson;

            sut.Should().BeTrue();
        }

        [Test]
        public void Thanos_CanWear_TheGauntlet()
        {
            thanos = new Common.Thanos();

            thanos.WearInfinityGauntlet();

            thanos.IsWearingInfinityGauntlet.Should().BeTrue();
        }
    }
}
