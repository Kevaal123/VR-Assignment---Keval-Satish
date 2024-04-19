using UnityEngine;
using UnityEngine.SceneManagement; // Import the necessary SceneManagement namespace
using UnityEngine.InputSystem; // Import the necessary InputSystem namespace
using System.Collections;
using System.Collections.Generic;


public class GameMenuManager : MonoBehaviour
{

    public GameObject menu; // Reference to the menu game object
    public InputActionProperty showButton; // Reference to the show button input action
    public Transform head; // Reference to the head transform
    public float spawnDistance = 2f; // Distance from the head to spawn the menu


    // Method to be called when the quit button is clicked
    public void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Quit the editor play mode
#else
        Application.Quit(); // Quit the application
#endif
    }

    void Update() 
    {
        if(showButton.action.WasPressedThisFrame()) // Check if the show button was pressed this frame
        {
            menu.SetActive(!menu.activeSelf); // Toggle the menu active state

            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance; // Set the menu position in front of the head
        }

        menu.transform.LookAt(new Vector3 (head.position.x, menu.transform.position.y, head.position.z)); // Make the menu face the head
        menu.transform.forward *= -1; // Reverse the menu forward direction
    }

}
