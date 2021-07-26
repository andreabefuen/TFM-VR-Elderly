using System.Collections;
using System.Collections.Generic;
using System.IO;
using TFM.ScriptableObjects;
using UnityEngine;

public class InventorySaveSystem : MonoBehaviour
{
    [SerializeField] private Inventory inventory = null;

    private static Dictionary<int, ItemSO> allItemsDictionary = new Dictionary<int, ItemSO>();
    private static int HashItem(ItemSO item) => Animator.StringToHash(item.ItemName);

    const char SPLIT_CHAR = '_';

    private static string FILE_PATH = "NULL!";


    private void Awake()
    {
        FILE_PATH = Application.persistentDataPath + "/Inventory.txt";
        
        CreateItemDictionary();

        if (File.Exists(FILE_PATH))
        {

            inventory.SetDictionary( LoadInventory());

        }

    }

    private void OnDisable()
    {
        SaveInventory();
    }
    private void CreateItemDictionary()
    {
        ItemSO[] allItems = Resources.FindObjectsOfTypeAll<ItemSO>();

        foreach (ItemSO i in allItems)
        {
            int key = HashItem(i);

            if (!allItemsDictionary.ContainsKey(key))
                allItemsDictionary.Add(key, i);
        }
    }

    public void SaveInventory()
    {
        Debug.Log("SAVE in " + FILE_PATH);
        using (StreamWriter sw = new StreamWriter(FILE_PATH))
        {
            foreach (KeyValuePair<ItemSO, int> kvp in inventory.GetInventory)
            {
                ItemSO item = kvp.Key;
                int count = kvp.Value;

                string itemID = HashItem(item).ToString();

                sw.WriteLine(itemID + SPLIT_CHAR + count);
            }
        }
    }

    internal Dictionary<ItemSO, int> LoadInventory()
    {
        if (!File.Exists(FILE_PATH))
        {
            Debug.LogWarning("The file you're trying to access doesn't exist. (Try saving an inventory first).");
            return null;
        }

        Dictionary<ItemSO, int> inventory = new Dictionary<ItemSO, int>();

        string line = "";

        using (StreamReader sr = new StreamReader(FILE_PATH))
        {
            while ((line = sr.ReadLine()) != null)
            {
                int key = int.Parse(line.Split(SPLIT_CHAR)[0]);
                ItemSO item = allItemsDictionary[key];
                int count = int.Parse(line.Split(SPLIT_CHAR)[1]);

                inventory.Add(item, count);
            }
        }

        return inventory;
    }
} 

