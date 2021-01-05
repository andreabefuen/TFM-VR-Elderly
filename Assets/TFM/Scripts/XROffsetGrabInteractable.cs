using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable
{
    private Vector3 initialAttachLocalPos;
    private Quaternion initialAttachLocalRot;
    private void Start()
    {
        //Create attach point
        if (!attachTransform)
        {
            GameObject grab = new GameObject("Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }
        initialAttachLocalPos = transform.localPosition;
        initialAttachLocalRot = transform.localRotation;
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {

        if(interactor is XRDirectInteractor)
        {
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        }
        else
        {
            attachTransform.localRotation = initialAttachLocalRot;
            attachTransform.localPosition = initialAttachLocalPos;
        }
        base.OnSelectEntered(interactor);
    }
}
