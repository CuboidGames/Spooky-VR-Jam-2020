using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    public class KidsKillCounter : MonoBehaviour
    {
        [SerializeField]
        private GameObject kidSpritePrefab;
    
        void Start()
        {
            KidController[] kids = GameObject.FindGameObjectsWithTag("Kid").Select(k => k.GetComponent<KidController>()).ToArray();
            
            foreach (var kid in kids)
            {
                GameObject kidSprite = Instantiate(kidSpritePrefab, transform);
                KidKillState killStateUI = kidSprite.GetComponent<KidKillState>();

                killStateUI.kidController = kid;
            }
        }
    }

}
