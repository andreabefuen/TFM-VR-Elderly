using System.Collections;
using UnityEngine;

namespace Assets.TFM.Scripts.Utils
{
    public abstract class CollisionBehaviour : MonoBehaviour
    {
        public abstract void OnTriggerEnter(Collider other);

        public abstract void OnCollisionEnter(Collision collider);
    }
}