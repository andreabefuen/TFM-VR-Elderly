using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UISlotHolderMissions <T> : MonoBehaviour
{
    protected Dictionary<T, string> missionsType;
    protected UIMissionSlot[] missionsSlots = null;
    [SerializeField] private GameObject missionSlotUIPrefab = null;
    [SerializeField] private GameObject holderObject = null;
    [SerializeField] private Transform contentParent;


    protected virtual void InitializeUI(Dictionary<T,string> missions, int numSlots)
    {
        missionsType = missions;
        CreateMissionsSlots(numSlots);
        UpdateMissionSlot();

    }

    private void CreateMissionsSlots(int numSlots)
    {
        if (missionsSlots != null && missionsSlots.Length >= numSlots) return;

        missionsSlots = new UIMissionSlot[numSlots];
        for (int i = 0; i < numSlots; i++)
        {
            GameObject aux = Instantiate(missionSlotUIPrefab, contentParent);
            missionsSlots[i] = aux.GetComponent<UIMissionSlot>();
            aux.SetActive(false);
        }
    }
    protected void UpdateMissionSlot()
    {
        int index = 0;

        foreach (KeyValuePair<T, string> kvp in missionsType)
        {
            UpdateSlotAt(index, kvp.Key, kvp.Value);
            index++;
            
        }

        //for (int i = index; i < missionsSlots.Length; ++i)
        //{
        //    missionsSlots[i].gameObject.SetActive(false);
        //}
    }

    protected abstract void UpdateSlotAt(int _index, T missionType, string state);

    public void ChangeMissionState() => holderObject.SetActive(!holderObject.activeSelf);
}
