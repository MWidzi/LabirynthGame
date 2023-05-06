using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform Player;
    public Transform Reciever;
    private bool PlayerIsOverlapping = false;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerIsOverlapping = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerIsOverlapping = false;
        }
    }

    public void FixedUpdate()
    {
        Teleport();
    }

    public void Teleport()
    {
        if(PlayerIsOverlapping)
        {
            Vector3 portalToPlayer = Player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if(dotProduct < 0f)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, Reciever.rotation);
                rotationDiff += 180f;

                Player.Rotate(Vector3.up, rotationDiff);
                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                Player.position = Reciever.position + positionOffset;

                PlayerIsOverlapping = false;
            }
        }
    }

}
