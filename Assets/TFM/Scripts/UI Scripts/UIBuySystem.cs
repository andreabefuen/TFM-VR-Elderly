using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBuySystem : MonoBehaviour
{

    public AnimalInformationSO[] animals;
    public GameObject informationToBuyPrefab;
    public Transform parentContainer;
    //UIBuyInfo[] buyInfoUI;


    void Start()
    {
        CreateInformationToBuy();
    }

    void CreateInformationToBuy()
    {
        if (animals == null) Debug.LogError("La lista de animales está vacía crack");
        foreach (var item in animals)
        {
            GameObject aux = Instantiate(informationToBuyPrefab, parentContainer);
            aux.GetComponent<UIBuyInfo>().GenerateBuyInfo(item);

        }
    }
}
