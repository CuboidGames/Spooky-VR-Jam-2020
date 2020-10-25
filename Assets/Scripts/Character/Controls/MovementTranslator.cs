using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Controls
{
    public class MovementTranslator : MonoBehaviour
    {
        [SerializeField]
        private Character character;

        [SerializeField]
        private Transform movementDirector;

        private void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");


            Vector3 forwardVelocity = Vector3.ProjectOnPlane(movementDirector.forward, character.transform.up).normalized * vertical;
            Vector3 sidewardVelocity = movementDirector.right * horizontal;

            character.Move(forwardVelocity + sidewardVelocity);
        }
    }
}
