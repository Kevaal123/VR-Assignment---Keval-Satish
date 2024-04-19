using UnityEngine;
using UnityEngine.Events;// Import Unity Engine Events

public class ResetPinsButton : MonoBehaviour
{
    public GameObject button;// Reference to the button GameObject
    public UnityEvent OnPress;// Unity Event to be invoked when the button is pressed
    public UnityEvent OnRelease;// Unity Event to be invoked when the button is released
    public GameObject pinsParent; // Parent GameObject containing all the grouped pins
    public GameObject ball; // Reference to the ball GameObject

    private bool isPressed = false;// Boolean to check if the button is pressed
    private GameObject presser;// GameObject that pressed the button
    private Vector3[] initialPositions; // Array to store initial positions of pins
    private Quaternion[] initialRotations; // Array to store initial rotations of pins
   

    private Vector3[] initialBallPosition; // Array to store initial positions of pins
    private Quaternion[] initialBallRotations; // Array to store initial rotations of pins

    private Vector3 buttonOriginalPosition;// Original position of the button

    // Start is called before the first frame update
    void Start()
    {
        // Store initial positions and rotations of all pins
        StoreInitialTransforms();
        // Store initial position of the ball
        StoreInitialBallPosition();

        // Store the original position of the button
        buttonOriginalPosition = button.transform.localPosition;
    }

    void StoreInitialTransforms() // Store initial positions and rotations of all pins
    {
        if (pinsParent != null) // Check if the pinsParent is assigned
        {
            int numPins = pinsParent.transform.childCount; // Get the number of pins
            initialPositions = new Vector3[numPins]; // Initialize the arrays to store initial positions and rotations of pins
            initialRotations = new Quaternion[numPins]; // Initialize the arrays to store initial positions and rotations of pins
            for (int i = 0; i < numPins; i++) // Loop through all the pins
            {
                Transform pin = pinsParent.transform.GetChild(i); // Get the pin at index i
                initialPositions[i] = pin.position; // Store the initial position of the pin
                initialRotations[i] = pin.rotation; // Store the initial rotation of the pin
            }
        }
    }

    void StoreInitialBallPosition() // Store initial position of the ball
    {
        if (ball != null)
        {
            int numBall = ball.transform.childCount; // Get the number of balls
            initialBallPosition = new Vector3[numBall]; // Initialize the arrays to store initial positions and rotations of balls
            initialBallRotations = new Quaternion[numBall];// Initialize the arrays to store initial positions and rotations of balls
            for (int i = 0; i < numBall; i++) // Loop through all the balls
            {
                Transform Ball = ball.transform.GetChild(i); // Get the ball at index i
                initialBallPosition[i] = Ball.position;// Store the initial position of the ball
                initialBallRotations[i] = Ball.rotation;// Store the initial rotation of the ball
            }
        }
    }

    void OnTriggerEnter(Collider other) // Check if the button is pressed
    {
        if (!isPressed && (other.CompareTag("Left Hand") || other.CompareTag("Right Hand"))) // Check if the button is not already pressed and the object that entered the trigger is a hand
        {
            button.transform.localPosition += new Vector3(0, 0.03f, 0); // Move the button up in local space
            presser = other.gameObject; // Store the object that entered the trigger
            OnPress.Invoke(); // Invoke the OnPress event
            ResetPinsAndBall(); // Reset pins and ball when the button is pressed
            isPressed = true; // Set isPressed to true
        }
    }


    void OnTriggerExit(Collider other) // Check if the button is released
    {
        if (other.gameObject == presser) // Check if the object that exited the trigger is the same object that pressed the button
        {
            button.transform.localPosition = buttonOriginalPosition; // Reset button position in local space
            OnRelease.Invoke(); // Invoke the OnRelease event
            isPressed = false; // Set isPressed to false
        }
    }

    public void ResetPinsAndBall() // Reset pins and ball
    {
        // Reset pins
        if (initialPositions != null && initialRotations != null) // Check if the initial positions and rotations of pins are stored
        {
            int numPins = pinsParent.transform.childCount; // Get the number of pins
            for (int i = 0; i < numPins; i++) // Loop through all the pins
            {
                Transform pin = pinsParent.transform.GetChild(i); // Get the pin at index i
                pin.position = initialPositions[i];// Reset the position of the pin
                pin.rotation = initialRotations[i];// Reset the rotation of the pin
            }
        }


        // Reset ball
        if (initialBallPosition != null && initialBallRotations != null)
        {
            int numBall = ball.transform.childCount;
            for (int i = 0; i < numBall; i++)
            {
                Transform Ball = ball.transform.GetChild(i);
                Ball.position = initialBallPosition[i];
                Ball.rotation = initialBallRotations[i];
            }
        }
       
    }
}
