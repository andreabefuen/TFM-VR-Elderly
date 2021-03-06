using System.Collections;
using System.Collections.Generic;
using TFM.ScriptableObjects.Resources;
using UnityEngine;

namespace TFM.ScriptableObjects.Inventory
{
    public class InventorySO : ScriptableObject
    {

        public List<InventorySlot> Container = new List<InventorySlot>();



        public void AddItem(BaseResourceSO resource, int amount)
        {
            
        }
    }

}



[System.Serializable]
public class InventorySlot
{
    public int amount;
}