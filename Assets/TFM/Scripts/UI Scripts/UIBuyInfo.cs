using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBuyInfo : MonoBehaviour
{

    public Image icon;
    public TextMeshProUGUI textName;

    AnimalInformationSO currentAnimalInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateBuyInfo(AnimalInformationSO animalInfo)
    {
        icon.sprite = animalInfo.animalSprite;
        icon.preserveAspect = true;
        textName.text = animalInfo.animalName;

        currentAnimalInfo = animalInfo;
    }

    public void BuyAnimal()
    {

    }
}
