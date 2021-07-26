using System.Collections;
using System.Collections.Generic;
using TFM.ScriptableObjects;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PickupItem : MonoBehaviour
{

    [SerializeField] private ItemSO item;

    public InputHelpers.Button grabActivationButton;
    public float activationThreshold = 0.1f;

    public XRController leftRayInteractor;
    public XRController rightRayInteractor;

    public delegate void PickItem();
    public event PickItem pickedItem;


    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, grabActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.layer.ToString() == "PlayerRightHand" || other.gameObject.layer.ToString() == "PlayerLeftHand")
        //{
        //    Debug.Log("you can grab this object");
        //    if(CheckIfActivated(leftRayInteractor) || CheckIfActivated(rightRayInteractor))
        //    {
        //        AddToInventoryAndDestroyThis();
        //    }
        //}

        Debug.Log(other.gameObject.name);
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerRightHand"))
        {
            AddToInventoryAndDestroyThis();
        }
    }

    private void AddToInventoryAndDestroyThis()
    {
        Debug.Log("1");
        Inventory inventory = FindObjectOfType<Inventory>().gameObject.GetComponent<Inventory>();
        inventory.AddToInventory(item);
        this.gameObject.SetActive(false);
        pickedItem();


    }

  // public void SetItem(ItemSO item, int amount = 1)
  // {
  //     
  // }
}
