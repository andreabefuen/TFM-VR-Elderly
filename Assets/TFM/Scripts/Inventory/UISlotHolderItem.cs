using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UISlotHolderItem <T> : MonoBehaviour
{

    protected Dictionary<T, int> inventoryType;
    protected UIItemSlot[] itemSlots = null;
    [SerializeField] private GameObject slotUIPrefab = null;

    [SerializeField] private GameObject holderObject = null;
    [SerializeField] private Transform contentParent;


    protected virtual void InitializeUI(Dictionary<T,int> inventory, int numSlots)
    {
        inventoryType = inventory;
        CreateItemSlots(numSlots);
        UpdateItemSlots();
    }


    private void CreateItemSlots(int numSlots)
    {
        //si ya estan creados, no creamos mas
        if (itemSlots != null && itemSlots.Length >= numSlots)
            return;

        itemSlots = new UIItemSlot[numSlots];

        for(int i = 0; i < numSlots; i++)
        {
            GameObject aux = Instantiate(slotUIPrefab, contentParent);
            itemSlots[i] = aux.GetComponent<UIItemSlot>();
            aux.SetActive(false);
        }

    }

    protected void UpdateItemSlots()
    {
        int index = 0;

        foreach (KeyValuePair<T, int> kvp in inventoryType)
        {
            UpdateSlotAt(index, kvp.Key, kvp.Value);
            index++;
        }

        for (int i = index; i < itemSlots.Length; ++i) //Deactivate unoccupied slots
            itemSlots[i].gameObject.SetActive(false);
    }

    protected abstract void UpdateSlotAt(int _index, T itemType, int count);

    public void ChangeInventoryState() => holderObject.SetActive(!holderObject.activeSelf);

}
