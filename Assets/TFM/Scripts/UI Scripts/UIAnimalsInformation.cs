using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimalsInformation : MonoBehaviour
{
    public GameObject animalInformationSlotPrefab;
    public Transform contentParent;
    // Start is called before the first frame update
    void Start()
    {
        AnimalInformationSO[] allAnimals = Resources.FindObjectsOfTypeAll<AnimalInformationSO>();
        Debug.Log("FOUND: " + allAnimals.Length);
        foreach (var item in allAnimals)
        {
            GameObject aux = Instantiate(animalInformationSlotPrefab, contentParent);
            UIAnimalInfoSlot animalInfo = aux.GetComponent<UIAnimalInfoSlot>();
            animalInfo.ChangUIAnimalInfoSlot(item);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
