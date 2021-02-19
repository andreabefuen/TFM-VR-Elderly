using UnityEngine;

namespace Assets.TFM.Scripts.Interfaces
{
    public interface ICharacter
    {
        string Name { get; }
        string Description { get; }


        Vector3 Position { get; }
        void Move(Vector3 direction);
    }
}

