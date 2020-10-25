using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Controls
{
    public class MovementDirector : MonoBehaviour
    {
        [SerializeField]
        private Transform pivot;

        [SerializeField]
        private bool xManaged = false;

        [SerializeField]
        private bool yManaged = false;

        private void Update()
        {
            if (!xManaged) { 
                float horizontal = Input.GetAxis("RightHorizontal");
                transform.Rotate(pivot.up, horizontal, Space.World);
            }

            if (!yManaged)
            {
                float vertical = Input.GetAxis("RightVertical");
                float yEuler = transform.rotation.eulerAngles.x - vertical;

                if (yEuler < 0)
                {
                    yEuler += 360;
                }

                if (yEuler > 180)
                {
                    yEuler = Mathf.Clamp(yEuler, 269.9f, 360);
                }
                else if (yEuler < 180)
                {
                    yEuler = Mathf.Clamp(yEuler, 0, 89.9f);
                }

                transform.rotation = Quaternion.Euler(
                    yEuler,
                    transform.rotation.eulerAngles.y,
                    transform.rotation.eulerAngles.z
                );;
            }
        }
    }
}
