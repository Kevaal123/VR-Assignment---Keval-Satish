using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleObjectNames : MonoBehaviour
{
    private bool areLabelsVisible = true; // Flag to track label visibility

    private void Start()
    {
        // Initially, set all objects with the tag "NameTag" to be visible
        ToggleObjectsWithTag("Nametag", true);
    }

    public void ToggleLabels()
    {
        // Toggle label visibility
        areLabelsVisible = !areLabelsVisible;

        // Set label visibility based on the flag
        ToggleObjectsWithTag("Nametag", areLabelsVisible);
    }

    // Function to toggle objects with a specific tag
    private void ToggleObjectsWithTag(string tag, bool isActive)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objectsWithTag)
        {
            obj.SetActive(isActive);
        }
    }
}
