using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleObjectNames : MonoBehaviour
{
    public GameObject[] objectsWithLabels; // Array of objects with labels
    private bool areLabelsVisible = true; // Flag to track label visibility

    private void Start()
    {
        // Initially, set all object labels to be visible
        foreach (GameObject obj in objectsWithLabels)
        {
            obj.SetActive(true);
        }
    }

    public void ToggleLabels()
    {
        // Toggle label visibility
        areLabelsVisible = !areLabelsVisible;

        // Set label visibility based on the flag
        foreach (GameObject obj in objectsWithLabels)
        {
            obj.SetActive(areLabelsVisible);
        }
    }
}
