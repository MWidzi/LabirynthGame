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

}
