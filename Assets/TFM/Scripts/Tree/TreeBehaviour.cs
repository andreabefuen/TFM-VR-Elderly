using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreeBehaviour : ResourceBehaviour
{
    int count = 0;


    public override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == toolName)
        {
            other.GetComponent<ToolBehaviour>().Hit();
            count++;
            Debug.Log("Cut!");
        }
    }

    public override IEnumerator DoAction()
    {
        yield return new WaitUntil(() => count >= totalHits);
        GameObject particles = Instantiate(dustParticlePrefab, startPositionParticle);
        dustParticlePrefab.GetComponent<ParticleSystem>().Play();
        StartCoroutine(FinishGetResource());

    }

    public override IEnumerator FinishGetResource()
    {
        while(mainResourceGameobject.transform.rotation.eulerAngles.z < 90)
        {
            mainResourceGameobject.transform.Rotate(Vector3.forward * Time.deltaTime * 100);
            yield return null;
        }
        Destroy(mainResourceGameobject);
        Invoke("CreateResources", 0.5f);
    }

    public override void CreateResources()
    {
        for (int i = 0; i < totalResources; i++)
        {
            GameObject aux = Instantiate(resourcePrefab, this.gameObject.transform);
            aux.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(1f, 3f), ForceMode.Impulse);

        }
    }

}
