using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thanos.Common
{
    public sealed class InfinityGauntlet
    {
        HashSet<InfinityStones> Stones = new HashSet<InfinityStones>();
        public string Wearer { get; private set; }

        public InfinityGauntlet(){}

        private static readonly Lazy<InfinityGauntlet> lazy = 
            new Lazy<InfinityGauntlet>(() => new InfinityGauntlet());

        public static InfinityGauntlet Instance => lazy.Value;

        public void PlaceStone(InfinityStones stone) => Stones.Add(stone);

        public void RemoveStone(InfinityStones stone) => Stones.Remove(stone);

        public bool ContainsStone(InfinityStones stone) => Stones.Contains(stone);

        public void Wear(IPerson person)
        {
            if (string.IsNullOrEmpty(Wearer))
                Wearer = person.Name;
        }

        public void Remove() => Wearer = String.Empty;
    }
}
