using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : ResourceBehaviour
{
    int count = 0;
    public override void CreateResources()
    {
        for (int i = 0; i < totalResources; i++)
        {
            GameObject aux = Instantiate(resourcePrefab, this.gameObject.transform);
            aux.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(1f, 3f), ForceMode.Impulse);

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
        Destroy(mainResourceGameobject);
        yield return null;
        Invoke("CreateResources", 0.5f);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == toolName)
        {
            other.GetComponent<ToolBehaviour>()?.Hit();
            count++;
            Debug.Log("Hit!");
        }
    }

}
