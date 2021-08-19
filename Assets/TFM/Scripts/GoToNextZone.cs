using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextZone : MonoBehaviour
{
    public GameObject panelCanvas;
    public string SceneToLoad;

    private void Awake()
    {
       panelCanvas.gameObject.SetActive(false);

    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            panelCanvas.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panelCanvas.gameObject.SetActive(false);

        }
    }
}
