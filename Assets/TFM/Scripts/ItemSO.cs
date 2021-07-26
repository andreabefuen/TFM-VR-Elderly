using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFM.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Item/New item")]
    public class ItemSO : ScriptableObject
    {
        [SerializeField] private string itemName;
        [SerializeField, Multiline] private string description;
        [SerializeField] private Sprite icon = null;
        [SerializeField] private int[] value = new int[3];

        [SerializeField] private GameObject prefab = null;//The form that this object takes

        public Sprite Icon => icon;
        public GameObject Prefab => prefab;

        public string ItemName => itemName;
        public string Description => description;

        public void BuyItem()
        {
            Debug.Log("ITEM BUY: " + itemName);
        }

        public int GetValue(int level) { return value[level]; }

        public void DoItemStuff()
        {
            Debug.Log("HAZ COSAS");
        }

    }

}
