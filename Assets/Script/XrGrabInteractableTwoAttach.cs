using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // Import the necessary XR Interaction Toolkit namespace

public class XrGrabInteractableTwoAttach : XRGrabInteractable // Inherit from the XRGrabInteractable class
{

    public Transform leftAttachTransform; // Reference to the left attach transform
    public Transform rightAttachTransform; // Reference to the right attach transform

    protected override void OnSelectEntered(SelectEnterEventArgs args) // Override the OnSelectEntered method
    {

        if(args.interactorObject.transform.CompareTag("Left Hand")) // Check if the interactor object is the left hand
        {
            attachTransform = leftAttachTransform; // Set the attach transform to the left attach transform
        }
        else if(args.interactorObject.transform.CompareTag("Right Hand")) // Check if the interactor object is the right hand
        {
            attachTransform = rightAttachTransform;// Set the attach transform to the right attach transform
        }


        base.OnSelectEntered(args);// Call the base OnSelectEntered method
    }

}
