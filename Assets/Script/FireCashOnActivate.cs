using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireCashOnActivate : MonoBehaviour
{

    public GameObject cash;

    public Transform spawnPoint;

    public float fireSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireCash);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireCash(ActivateEventArgs args)
    {
        // Instantiate the cash prefab at the spawn point position with the spawn point's rotation
        GameObject spawnCash = Instantiate(cash, spawnPoint.position, spawnPoint.rotation);

        // Get the Rigidbody component of the spawned cash
        Rigidbody rb = spawnCash.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Apply force to the cash in the spawn point's forward direction
            rb.AddForce(spawnPoint.forward * fireSpeed, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Rigidbody component not found on cash prefab!");
            return; // Exit the method early if Rigidbody is missing
        }

        // Destroy the cash after a certain time
        Destroy(spawnCash, 3f);
    }
}
