using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResourceBehaviour : MonoBehaviour
{
    public int totalHits = 3;
    public int totalResources = 4;
    public string toolName;
    public GameObject dustParticlePrefab;
    public Transform startPositionParticle;
    public GameObject mainResourceGameobject;
    public GameObject resourcePrefab;


    public virtual void Awake()
    {
        StartCoroutine(DoAction());
    }
    public abstract void OnTriggerEnter(Collider other);
    public abstract void CreateResources();
    public abstract IEnumerator DoAction();
    public abstract IEnumerator FinishGetResource();

}

