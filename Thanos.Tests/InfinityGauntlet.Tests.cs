using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Thanos.Common;


namespace Thanos.Tests
{
    [TestFixture]
    class InfinityGauntlet
    {
        Common.InfinityGauntlet Gauntlet;

        public InfinityGauntlet()
        {
            Gauntlet = Common.InfinityGauntlet.Instance;
        }

        // Gauntlet is a singleton, we have to remove wearers before each test
        [SetUp]
        public void RemoveGauntlet()
        { Gauntlet.Remove(); }

        [TestCaseSource(typeof(MyData), "InfinityStones")]
        public void CanAddStoneToGauntlet(InfinityStones stone)
        {
            Gauntlet.PlaceStone(stone);

            var sut = Gauntlet.ContainsStone(stone);

            sut.Should().BeTrue();
        }

        [TestCaseSource(typeof(MyData), "InfinityStones")]
        public void CanRemoveStoneFromGauntlet(InfinityStones stone)
        {
            Gauntlet.PlaceStone(stone);

            Gauntlet.RemoveStone(stone);

            var sut = Gauntlet.ContainsStone(stone);

            sut.Should().BeFalse();
        }

        [TestCaseSource(typeof(MyData), "InfinityStones")]
        public void GauntletDoesNotContainsStoneIfNotAdded(InfinityStones stone)
        {
            var sut = Gauntlet.ContainsStone(stone);

            sut.Should().BeFalse();
        }

        [Test]
        public void OnlyOnePersonCanWearTheGauntletAtATime()
        {
            IPerson thanos = new Person()
            {
                Name = "Thanos"
            };

            IPerson hulk = new Person()
            {
                Name = "Hulk"
            };

            Gauntlet.Wear(thanos);
            Gauntlet.Wear(hulk);

            var sut = Gauntlet.Wearer;

            sut.Should().BeEquivalentTo(thanos.Name);
        }

        [Test]
        public void APersonCanWearGauntletIfRemovedFromSomeoneElse()
        {
            IPerson thanos = new Person()
            {
                Name = "Thanos"
            };

            IPerson hulk = new Person()
            {
                Name = "Hulk"
            };

            Gauntlet.Wear(thanos);
            Gauntlet.Remove();

            Gauntlet.Wear(hulk);

            var sut = Gauntlet.Wearer;

            sut.Should().BeEquivalentTo(hulk.Name);
        }
    }

    class MyData
    {
        public static System.Collections.IEnumerable InfinityStones
        {
            get
            {
                yield return new TestCaseData(Common.InfinityStones.MindStone);
                yield return new TestCaseData(Common.InfinityStones.PowerStone);
                yield return new TestCaseData(Common.InfinityStones.RealityStone);
                yield return new TestCaseData(Common.InfinityStones.SoulStone);
                yield return new TestCaseData(Common.InfinityStones.SpaceStone);
                yield return new TestCaseData(Common.InfinityStones.TimeStone);
            }
        }
    }
}
