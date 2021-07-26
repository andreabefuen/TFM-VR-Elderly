using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditModeManager : MonoBehaviour
{
    public static EditModeManager _instance;
    public static EditModeManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<EditModeManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("Game Manager");
                    _instance = container.AddComponent<EditModeManager>();
                }
            }
            DontDestroyOnLoad(_instance);

            return _instance;
        }
    }

    public List<GameObject> furnitureGameObjects = new List<GameObject>();

    public void SaveCurrentLayout()
    {
        foreach (var item in furnitureGameObjects)
        {
            Destroy(item.GetComponent<ObjectManipulator>());
            Destroy(item.GetComponent<BoundingBox>());

        }
    }

    public void EditModeLayout()
    {
        foreach (var item in furnitureGameObjects)
        {
            item.AddComponent<ObjectManipulator>();
            BoundingBox boundingBox = item.AddComponent<BoundingBox>();
            boundingBox.BoundingBoxActivation = BoundingBox.BoundingBoxActivationType.ActivateByProximityAndPointer;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
