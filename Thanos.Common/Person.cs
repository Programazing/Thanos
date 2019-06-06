namespace Thanos.Common
{
    public class Person : IPerson
    {
        InfinityGauntlet Gauntlet = InfinityGauntlet.Instance;

        public virtual string Name { get; set; }
        public virtual bool isWearingInfinityGauntlet { get; set; } = false;
        public virtual int HP { get; set; } = 100;

        public virtual void WearInfinityGauntlet()
        {
            Gauntlet.Wear(this);
            if(Name == Gauntlet.Wearer)
            {
                isWearingInfinityGauntlet = true;
            }
        }

        public virtual void RemoveInfinityGauntlet()
        {
            if(isWearingInfinityGauntlet)
                Gauntlet.Remove();
        }
    }
}