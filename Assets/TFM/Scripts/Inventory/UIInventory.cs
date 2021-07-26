using System.Collections;
using System.Collections.Generic;
using TFM.ScriptableObjects;
using TFM.Utils;
using UnityEngine;
using UnityEngine.Events;

public class UIInventory : UISlotHolderItem<ItemSO>
{
    [SerializeField] private Inventory inventory = null;
    [SerializeField] private ItemAction itemAction;

    private float timeBetweenClicks = .2f;
    bool canClick = true;

    private void Start()
    {
        if (inventory)
            InitializeUI(inventory.GetInventory, inventory.GetMaxItemSlots);
    }

    protected override void InitializeUI(Dictionary<ItemSO, int> inventory, int numSlots)
    {
        base.InitializeUI(inventory, numSlots);
        this.inventory.onInventoryChange += UpdateItemSlots;
    }

    protected override void UpdateSlotAt(int _index, ItemSO itemType, int count)
    {
        if (count == 0)
            itemSlots[_index].gameObject.SetActive(false);
        else
        {
            itemSlots[_index].gameObject.SetActive(true);

            UnityAction buttonAction = itemAction.Action(itemType, 1, inventory);

            itemSlots[_index].UpdateSlotUI(itemType, count, buttonAction);

            itemSlots[_index].onClickRemove += () => DropItem(itemType);
        }
    }

    private void DropItem(ItemSO item)
    {
        if (canClick)
        {
            StartCoroutine(StartClickBuffer());
            inventory.DropItem(item, 1);
        }
    }

    private IEnumerator StartClickBuffer()
    {
        canClick = false;
        yield return new WaitForSeconds(timeBetweenClicks);
        canClick = true;
    }


}
