using UnityEngine;

public class Pin : MonoBehaviour
{
    private bool isKnocked = false;
    public int scoreValue = 1; // Score to be awarded when the pin is knocked down
    public bool wasKnockedLastFrame = false;
    // Threshold for raycast distance to detect if the pin is standing upright
    public float uprightRaycastDistance = 0.1f;
    public float halfHeightThreshold = 0.1f;
    float originalY;
    void Start()
    {
        originalY = transform.position.y;
    }

    void Update()
    {
        
        // Cast a ray from the pin's position downward to check if it's standing upright
        RaycastHit hit;
        if (!isKnocked && Physics.Raycast(transform.position, -transform.up, out hit, uprightRaycastDistance))
        {
            // If the ray hits something, check if it's the ground
            if (hit.collider.CompareTag("Ground"))
            {
                // If the pin is standing upright, it's not knocked down
                isKnocked = false;
            }
            else
            {
                // If the pin is not standing upright (i.e., the ray doesn't hit the ground), it's knocked down
                isKnocked = true;
                // Award points for knocking the pin down using the GameManager
                GameManager.instance.AddScore(scoreValue);
                // You can add any other effects here, like playing a sound or animation
            }
        }
        else
        {
            Debug.Log("Raycast did not hit the ground.");
        }
    }

}
