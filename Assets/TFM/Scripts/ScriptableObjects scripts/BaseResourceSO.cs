using System.Collections;
using TFM.ScriptableObjects;
using UnityEngine;

namespace TFM.ScriptableObjects
{
    public enum ResourceType
    {
        Wood,
        Rock,
        Pumpkins
    }

    public class Resource
    {
        public string Name;
        public int Id;
        public Resource(BaseResourceSO resource)
        {
            Name = resource.name;
            Id = resource.Id;

        }
    }


    public abstract class BaseResourceSO : ScriptableObject
    {
        public int Id;
        public Sprite uiDisplay;
        public ResourceType resourceType;
        [TextArea(15,20)]
        public string description;

        public Resource CreateResource()
        {
            Resource newResource = new Resource(this);
            return newResource;
        }

    }
}

