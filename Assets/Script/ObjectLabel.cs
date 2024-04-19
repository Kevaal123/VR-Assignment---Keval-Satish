using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectLabel : MonoBehaviour
{
    public TextMeshPro nameLabel;
    public string customName; // Public variable to set custom name for the object

    private void Start()
    {
        nameLabel.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Check if the player is looking at this object
        if (IsPlayerLookingAtObject())
        {
            // Show the label and make it face the player
            nameLabel.gameObject.SetActive(true);
            nameLabel.text = customName; // Set custom name
            nameLabel.transform.LookAt(Camera.main.transform.position);
            nameLabel.transform.Rotate(0, 180, 0); // Rotate label 180 degrees around y-axis
        }
        else
        {
            // Hide the label if the player is not looking at this object
            nameLabel.gameObject.SetActive(false);
        }
    }

    private bool IsPlayerLookingAtObject()
    {
        Vector3 raycastOrigin = Camera.main.transform.position + (Camera.main.transform.forward * 0.5f); // Lowering the raycast origin
        // Raycast from the lowered player's head
        if (Physics.Raycast(raycastOrigin, Camera.main.transform.forward, out RaycastHit hit))
        {
            // Check if the raycast hits this object
            return (hit.collider.gameObject == gameObject);
        }
        return false;
    }
}
