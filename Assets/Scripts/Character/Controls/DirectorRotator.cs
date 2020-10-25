using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Controls
{
    public class DirectorRotator : MonoBehaviour
    {
        [SerializeField]
        private Transform director;

        private void Update()
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, director.eulerAngles.y, 0));
        }
    }
}
