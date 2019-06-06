using System;
using System.Collections.Generic;
using System.Text;

namespace Thanos.Common
{
    public sealed class InfinityGauntlet
    {
        HashSet<InfinityStones> Stones = new HashSet<InfinityStones>();
        public string Wearer { get; private set; }

        private InfinityGauntlet()
        {

        }
        private static readonly Lazy<InfinityGauntlet> lazy = new Lazy<InfinityGauntlet>(() => new InfinityGauntlet());

        public static InfinityGauntlet Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        public void PlaceStone(InfinityStones stone)
        {
            Stones.Add(stone);
        }

        public void RemoveStone(InfinityStones stone)
        {
            Stones.Remove(stone);
        }

        public bool ContainsStone(InfinityStones stone)
        {
            return Stones.Contains(stone);
        }

        public void Wear(IPerson person)
        {
            if(string.IsNullOrEmpty(Wearer))
                Wearer = person.Name;
        }

        public void Remove()
        {
            Wearer = "";
        }

        // public static List<T> Snap<T>(List<T> universe) => universe.ReduceByHalf();
    }
}
