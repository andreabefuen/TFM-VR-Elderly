using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    public int totalHits = 3;
    public GameObject dustParticlePrefab;
    public Transform startPositionParticle;
    public GameObject treeGameobject;

    public GameObject woodStack;
    int count = 0;
    int countResources = 4;

    private void Awake()
    {
        StartCoroutine(CuttingDown());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Axe")
        {
            count++;
            Debug.Log("Cut!");
        }
    }

    IEnumerator CuttingDown()
    {
        yield return new WaitUntil(() => count >= totalHits);
        GameObject particles = Instantiate(dustParticlePrefab, startPositionParticle);
        dustParticlePrefab.GetComponent<ParticleSystem>().Play();
        StartCoroutine(FellDown());

    }

    IEnumerator FellDown()
    {
        while(treeGameobject.transform.rotation.eulerAngles.z < 90)
        {
            treeGameobject.transform.Rotate(Vector3.forward * Time.deltaTime * 100);
            yield return null;
        }
        Destroy(treeGameobject);
        Invoke("CreateResources", 3f);
    }

    void CreateResources()
    {
        for (int i = 0; i < countResources; i++)
        {
            GameObject aux = Instantiate(woodStack);
            aux.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);

        }
    }

}
