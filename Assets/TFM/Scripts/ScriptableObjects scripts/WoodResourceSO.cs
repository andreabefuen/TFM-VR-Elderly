using System.Collections;
using UnityEngine;

namespace TFM.ScriptableObjects.Resources
{
    [CreateAssetMenu(fileName = "New wood resource", menuName = "Resource/Wood resource")]
    public class WoodResourceSO : BaseResourceSO
    {
        private void OnEnable()
        {
            resourceType = ResourceType.Wood;
        }

    }
}