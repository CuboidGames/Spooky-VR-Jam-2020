using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidKillDetection : MonoBehaviour
{
    [SerializeField]
    private KidController kidController;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("PlayerWeapon"))
        {
            kidController.Die();           
        }
    }
}
