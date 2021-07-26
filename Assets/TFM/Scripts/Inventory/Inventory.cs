using System.Collections;
using System.Collections.Generic;
using TFM.ScriptableObjects;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<ItemSO, int> inventory = new Dictionary<ItemSO, int>();

    private int maxItemSlot = 99;


    [SerializeField] private PickupItem pickupPrefab = null;

    public delegate void OnInventoryChange();
    public OnInventoryChange onInventoryChange;

    public Dictionary<ItemSO, int> GetInventory => inventory;
    public void SetDictionary(Dictionary<ItemSO, int> loadInventory) => inventory = loadInventory;

    public int GetMaxItemSlots => maxItemSlot;

    public bool HasNumberOfItem(ItemSO item, int numNeeded) => inventory.ContainsKey(item) && inventory[item] >= numNeeded;

    public void AddToInventory(ItemSO item, int count = 1)
    {
        if (!inventory.ContainsKey(item))
            inventory.Add(item, count);

        else
            inventory[item] += count;

        onInventoryChange?.Invoke();
    }

    public void RemoveFromInventory(ItemSO item, int count)
    {
        if (!inventory.ContainsKey(item))
            throw new System.Exception("The inventory dictionary doesn't contain that item.");

        if(inventory[item] >= count)
        {
            inventory[item] -= count;
        }
        else
        {
            Debug.LogError($"Inventory contains less that {count} of {item.ItemName}.");
            inventory[item] = 0;
        }

        onInventoryChange?.Invoke();
    }

    public void DropItem(ItemSO item, int count)
    {
        if (!HasNumberOfItem(item, count))
            return;

        RemoveFromInventory(item, count);
        Debug.Log("DROP");
        PickupItem p = Instantiate(item.Prefab!=null ? item.Prefab.GetComponent<PickupItem>() : pickupPrefab, transform.position + transform.TransformDirection(new Vector3(0, 3f, 2f)), transform.rotation);

    }
}
