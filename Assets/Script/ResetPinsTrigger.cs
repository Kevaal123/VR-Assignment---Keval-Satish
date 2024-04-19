using UnityEngine;

public class ResetPinsTrigger : MonoBehaviour
{
    // Initial positions of the game objects
    private Vector3[] initialPositions;

    // Array of game objects to reset
    public GameObject[] objectsToReset;

    void Start()
    {
        // Store the initial positions of the game objects
        StoreInitialPositions();
    }

    void StoreInitialPositions()
    {
        initialPositions = new Vector3[objectsToReset.Length];// Store the initial positions of the game objects
        for (int i = 0; i < objectsToReset.Length; i++) // Loop through all the game objects
        {
            initialPositions[i] = objectsToReset[i].transform.position; // Store the initial position of the game object
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Reset the positions of the game objects
            ResetObjectPositions();
        }
    }

    void ResetObjectPositions() // Reset the positions of the game objects
    {
        for (int i = 0; i < objectsToReset.Length; i++) // Loop through all the game objects
        {
            objectsToReset[i].transform.position = initialPositions[i]; // Reset the position of the game object
            objectsToReset[i].GetComponent<Pin>().wasKnockedLastFrame = false; // Reset the wasKnockedLastFrame flag
        }
    }
}
