using UnityEngine;
using System.Collections;

public class GuardRailController : MonoBehaviour
{
    public float raisedHeight = 1.0f; // Height to raise the guard railing objects
    public float raiseSpeed = 1.0f; // Speed at which the guard railing objects rise
    public float lowerSpeed = 1.0f; // Speed at which the guard railing objects lower

    private Vector3 initialPosition;
    private bool isRaised = false;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void ToggleGuardRails()
    {
        isRaised = !isRaised;

        if (isRaised)
        {
            // Raise the guard railing objects
            StartCoroutine(RaiseGuardRails());
        }
        else
        {
            // Lower the guard railing objects
            StartCoroutine(LowerGuardRails());
        }
    }

    IEnumerator RaiseGuardRails()
    {
        while (transform.position.y < initialPosition.y + raisedHeight)
        {
            transform.position += Vector3.up * raiseSpeed * Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator LowerGuardRails()
    {
        while (transform.position.y > initialPosition.y)
        {
            transform.position -= Vector3.up * lowerSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
