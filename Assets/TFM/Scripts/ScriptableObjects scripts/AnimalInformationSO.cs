using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Animals/New info animal")]
public class AnimalInformationSO : ScriptableObject
{

    [SerializeField] private string animalName;

    [SerializeField] private GameObject animalPrefab;

    [SerializeField] private Sprite animalSprite;

    [SerializeField] private int animalCost;

    [SerializeField] private int foodPerDay;

    [SerializeField] private string animalDescription;

    [SerializeField] private int maxAnimals;

    [SerializeField] private int currentCountAnimals = 0;
    
    [Range(0,10)]
    [SerializeField] private int currentFeed = 5;

    [Range(0, 10)]
    [SerializeField] private int currentLove = 0;

    // DELEGATES
    public delegate void OnFeedValueChange();
    public OnFeedValueChange onFeedValueChange;

    public delegate void OnPetValueChange();
    public OnPetValueChange onPetValueChange;

    public void FeedAnimal(int value)
    {
        currentFeed += value;
        if(currentFeed > 10)
        {
            currentFeed = 10;
            Debug.LogError("Maximum value of feed");
        }
        onFeedValueChange?.Invoke();
    }

    public void PetAnimal(int value)
    {
        currentLove += value;
        if(currentLove> 10)
        {
            currentLove = 10;
        }
        onPetValueChange?.Invoke();
    }

    public int GetCurrentValueFeed()
    {
        return currentFeed;
    }

    public int GetCurrentLoveValue()
    {
        return currentLove;
    }

    public Sprite GetAnimalSprite()
    {

            return animalSprite;
    }

    public string GetAnimalName()
    {
        return animalName;
    }

    public int GetCurrentCountAnimals()
    {
        return currentCountAnimals;
    }

    public int GetCostAnimal()
    {
        return currentCountAnimals * animalCost;
    }
}
