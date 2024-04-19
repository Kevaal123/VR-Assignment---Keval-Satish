using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Required for InputActionProperty
using UnityEngine.XR.Interaction.Toolkit; // Required for XRRayInteractor

public class ActivateTeleportationRay : MonoBehaviour 
{
    
    public GameObject leftTeleportationRay; // The left teleportation ray

    public InputActionProperty leftActivate; // The left activate input action


    public XRRayInteractor leftRay; // The left ray interactor

    // Update is called once per frame
    void Update()
    {
        bool isLeftRayHovering = leftRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal, out int leftNumber, out bool leftValid); // Get the hit info of the left ray

        leftTeleportationRay.SetActive(leftActivate.action.ReadValue<float>() >0.1f); // If the left activate input action is pressed, activate the left teleportation ray
    }
}
