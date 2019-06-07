namespace Thanos.Common
{
    public interface IPerson
    {
        string Name { get; set; }
        bool IsWearingInfinityGauntlet { get; set; }
        int HP { get; set; }

        void WearInfinityGauntlet();

        void RemoveInfinityGauntlet();
    }
}