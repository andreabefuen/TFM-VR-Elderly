using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFM.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Mission/New mission")]
    public class MissionsSO : ScriptableObject
    {
        [SerializeField] private MissionType missionType;
        [SerializeField] private ItemSO itemNeeded = null; //Solo si es del tipo dar objeto
        [SerializeField] private int cuantityNeeded = 1;
        [SerializeField] private string missionName;
        [SerializeField, Multiline] private string description;
         
        [SerializeField] private int moneyReward;
        [SerializeField] private ItemSO itemReward;
        [SerializeField] private bool isCompleted = false;

        public string MissionName => missionName;
        public string Description => description;

        public Sprite Icon => itemNeeded?.Icon;
        public int Cuantity => cuantityNeeded;

        public ItemSO ItemNeeded()
        {
            if(missionType != MissionType.bringItem)
            {
                return null;
            }
            return itemNeeded;
        }

        private void OnValidate()
        {

        }
    }

    public enum MissionType
    {
        bringItem,
        talkToSomeone
    }

}
