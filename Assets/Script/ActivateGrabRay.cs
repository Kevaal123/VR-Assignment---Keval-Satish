using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // Required for XRDirectInteractor

public class ActivateGrabRay : MonoBehaviour
{
    public GameObject leftGrabRay; // The left grab ray
    public GameObject rightGrabRay; // The right grab ray

    public XRDirectInteractor leftDirectInteractor; // The left direct interactor
    public XRDirectInteractor rightDirectInteractor; // The right direct interactor

    // Update is called once per frame
    void Update()
    {
        leftGrabRay.SetActive(leftDirectInteractor.interactablesSelected.Count == 0); // If there are no interactables selected, activate the left grab ray
        rightGrabRay.SetActive(rightDirectInteractor.interactablesSelected.Count == 0); // If there are no interactables selected, activate the right grab ray
    }
}
