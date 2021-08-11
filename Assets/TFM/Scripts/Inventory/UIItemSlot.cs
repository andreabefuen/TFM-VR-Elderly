using System.Collections;
using System.Collections.Generic;
using TFM.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class UIItemSlot : MonoBehaviour
{

    [SerializeField] private Button giveItemButton = null;
    [SerializeField] private Button removeButton = null;
    [SerializeField] private TextMeshProUGUI nameText = null;
    [SerializeField] private TextMeshProUGUI countText = null;
    [SerializeField] private Image itemIcon = null;

    public delegate void OnClickRemove();
    public OnClickRemove onClickRemove;

    public delegate void OnClickGive();
    public OnClickGive onClickGive;


    // Start is called before the first frame update
    void Start()
    {
        if (removeButton != null)
        {
            removeButton.onClick.AddListener(() => onClickRemove?.Invoke());
        }
    }

    public virtual void UpdateSlotUI(ItemSO item, int count, UnityAction buttonAction)
    {
        nameText.text = item.ItemName;
        countText.text = count.ToString();

        itemIcon.sprite = item.Icon;

        if(buttonAction != null)
        {
            giveItemButton.onClick.RemoveAllListeners();
            giveItemButton.onClick.AddListener(buttonAction);
        }
    }
}
