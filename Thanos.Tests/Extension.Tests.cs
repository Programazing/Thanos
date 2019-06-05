using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Thanos.Common;

namespace Thanos.Tests
{
    [TestFixture]
    class Extension
    {
        

        public Extension()
        {

        }

        [Test]
        public static void ReduceListByHalf_ReducesStringList_ByHalf()
        {
            var alphabet = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n",
            "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};

            var halfOfList = alphabet.ReduceListByHalf();

            halfOfList.Should().HaveCount(alphabet.Count / 2);
        }
    }
}
