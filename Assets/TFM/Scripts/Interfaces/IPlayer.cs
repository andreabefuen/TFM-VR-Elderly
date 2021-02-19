
namespace Assets.TFM.Scripts.Interfaces
{
    public interface IPlayer : ICharacter
    {
        int Money { get; }

        int Experience { get; }

        void EarnMoney(int money);
        void EarnExperience(int experience);
    }
}
