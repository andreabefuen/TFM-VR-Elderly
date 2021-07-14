using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Animals/New info animal")]
public class AnimalInformationSO : ScriptableObject
{
    public string animalName;

    public GameObject animalPrefab;

    public Sprite animalSprite;

    public int animalCost;

    public int foodPerDay;

    public string animalDescription;
}
