using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManagement namespace

public class MenuManager : MonoBehaviour
{
    // Method to be called when the start button is clicked
    public void StartGame()
    {
        SceneManager.LoadScene("BowlingAlley"); // Load the BowlingAlley scene
    }
    // Method to be called when the quit button is clicked
    public void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop playing the scene in the Unity Editor
#else
        Application.Quit();
#endif
    }
}
