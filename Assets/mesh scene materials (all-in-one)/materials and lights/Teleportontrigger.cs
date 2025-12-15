using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportOnTrigger : MonoBehaviour
{
    public Transform targetPoint;    // ViewPoint1
    public Transform xrOrigin;       // XR Origin to move

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering is the player (XR Origin)
        if (other.CompareTag("Player"))
        {
            xrOrigin.position = targetPoint.position;
            xrOrigin.rotation = targetPoint.rotation;
        }
    }
}
