using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimalInfoSlot : MonoBehaviour
{
    AnimalInformationSO animalInformationSO = null;
    public Image animalIcon;
    public TextMeshProUGUI animalNameText;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI loveCountText;
    public TextMeshProUGUI foodCountText;

    private void Start()
    {
       // AddListeners();
    }

    private void OnDisable()
    {
        RemoveListeners();
    }

    void AddListeners()
    {
        animalInformationSO.onFeedValueChange += ChangeFoodValue;
    }
    void RemoveListeners()
    {
        animalInformationSO.onPetValueChange += ChangeLoveValue;
    }

    void ChangeFoodValue()
    {
        foodCountText.text = animalInformationSO.GetCurrentValueFeed().ToString();
    }

    void ChangeLoveValue()
    {
        loveCountText.text = animalInformationSO.GetCurrentLoveValue().ToString();
    }
    void ChangeCountValue()
    {
        countText.text = animalInformationSO.GetCurrentCountAnimals().ToString();
    }
    public void ChangUIAnimalInfoSlot(AnimalInformationSO animalInfoSO)
    {
        if (animalInfoSO == null) return;
        animalInformationSO = animalInfoSO;

        animalIcon.sprite = animalInfoSO.GetAnimalSprite();
        animalNameText.text = animalInfoSO?.GetAnimalName();

        countText.text = animalInfoSO.GetCurrentCountAnimals().ToString();

        loveCountText.text = animalInfoSO.GetCurrentLoveValue().ToString();
        foodCountText.text = animalInfoSO.GetCurrentValueFeed().ToString();
        AddListeners();
    }
}
