using System.Collections;
using System.Collections.Generic;
using TFM.ScriptableObjects;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{

    public ItemSO item;

    private void Start()
    {

    }
    public void GrabItem()
    {
        item.GrabbingItem();
    }
    public void ReleaseItem()
    {

    }
}
