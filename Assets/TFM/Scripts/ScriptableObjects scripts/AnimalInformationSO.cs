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
    
    [Range(0,10)]
    [SerializeField] private int currentFeed = 5;



    public void FeedAnimal(int value)
    {
        currentFeed += value;
        if(currentFeed > 10)
        {
            currentFeed = 10;
            Debug.LogError("Maximum value of feed");
        }
    }

    public int GetCurrentValueFeed()
    {
        return currentFeed;
    }

    public Sprite GetAnimalSprite()
    {
        return animalSprite;
    }

    public string GetAnimalName()
    {
        return animalName;
    }
}
