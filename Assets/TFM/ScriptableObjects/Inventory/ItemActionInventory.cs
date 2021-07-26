using System.Collections;
using System.Collections.Generic;
using TFM.ScriptableObjects;
using TFM.Utils;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Item/New ACTION")]
public class ItemActionInventory : ItemAction
{
    public override UnityAction Action(ItemSO i, int n, object inventory)
    {
        return new UnityAction(delegate
        {
            Inventory inv = inventory as Inventory;

            inv.RemoveFromInventory(i, n);

            i.DoItemStuff();
        });

    }
}
