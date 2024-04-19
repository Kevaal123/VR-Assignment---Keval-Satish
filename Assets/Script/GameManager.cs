using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Static reference to the GameManager instance

    private int score = 0; // Current score of the player
    public TextMeshPro scoreText; // Reference to the TextMeshPro component for displaying the score

    private void Awake() // Called before Start() on the first frame
    {
        if (instance == null) // Check if the instance is null
        {
            instance = this; // Set the instance to this object
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points) // Method to add points to the score
    {
        score += points;
        UpdateScoreUI(); 
    }

    private void UpdateScoreUI() // Method to update the score displayed in the UI
    {
        // Update the TextMeshPro component to display the current score
        scoreText.text = "Pins Down: " + score.ToString();
    }
}
