using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddManipulationCopyOnClick : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Interactable interactableComponent = this.GetComponent<Interactable>();
        interactableComponent.OnClick.AddListener(Copy);

        spawnPoint = GameObject.Find("SpawnPoint").transform;
    }
    public void Copy()
    {
        GameObject copy = Instantiate(this.gameObject);
        copy.transform.position = spawnPoint.position;
        copy.transform.rotation = spawnPoint.rotation;
        copy.transform.up = Vector3.up;
        copy.transform.localScale = spawnPoint.localScale;
        
        copy.AddComponent<ObjectManipulator>();
        BoundingBox boundingBox = copy.AddComponent<BoundingBox>();
        boundingBox.BoundingBoxActivation = BoundingBox.BoundingBoxActivationType.ActivateByProximityAndPointer;

        RotationAxisConstraint rotationAxisConstraint = copy.AddComponent<RotationAxisConstraint>();
        rotationAxisConstraint.ConstraintOnRotation = Microsoft.MixedReality.Toolkit.Utilities.AxisFlags.XAxis | Microsoft.MixedReality.Toolkit.Utilities.AxisFlags.ZAxis;

        Destroy(copy.GetComponent<Interactable>());
        Destroy(copy.GetComponent<AddManipulationCopyOnClick>());

        EditModeManager.Instance.furnitureGameObjects.Add(copy);
    }
}
