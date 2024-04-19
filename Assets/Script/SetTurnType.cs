using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;// Include the XR namespace to access the XR Interaction Toolkit

public class SetTurnType : MonoBehaviour
{

    public ActionBasedSnapTurnProvider snapTurn; // Reference to the ActionBasedSnapTurnProvider component
    public ActionBasedContinuousTurnProvider continuousMove; // Reference to the ActionBasedContinuousTurnProvider component


    public void SetTypeFromIndex(int index) // Function to set the turn type based on the index
    {
        if(index == 0) // If the index is 0, enable continuous movement and disable snap turn
        {
            snapTurn.enabled = false; // Disable the snap turn
            continuousMove.enabled = true;// Enable the continuous movement
        }
        else if(index == 1)// If the index is 1, enable snap turn and disable continuous movement
        {
            snapTurn.enabled = true; // Enable the snap turn
            continuousMove.enabled = false;// Disable the continuous movement
        }
    }
}
