using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public interface ICharacter { }

    public class Character : MonoBehaviour
    {
        public Rigidbody rb;


        [SerializeField]
        protected float drag = 0.95f;

        [SerializeField]
        protected float maxVelocity = 10f;

        [SerializeField]
        protected Transform direction;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 velocity)
        {
            float velocityClamp = maxVelocity;
            
            rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x * drag + velocity.x, -velocityClamp, velocityClamp), rb.velocity.y, Mathf.Clamp(rb.velocity.z * drag + velocity.z, -velocityClamp, velocityClamp));
        }
    }
}
