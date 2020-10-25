using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidParticles : MonoBehaviour
{
    ParticleSystem ps;
    void Start()
    {
        GameObject collisionPlane = GameObject.FindGameObjectWithTag("Floor");

        ps = GetComponent<ParticleSystem>();

        ps.collision.SetPlane(0, collisionPlane.transform);
    }
}
