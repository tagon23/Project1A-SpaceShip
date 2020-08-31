using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //player detection
        PlayerShip playerShip
            = other.gameObject.GetComponent<PlayerShip>();
        //if valid, die
        if(playerShip != null)
        {
            playerShip.Kill();
        }
    }
}
