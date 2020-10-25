using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class KidKillState : MonoBehaviour
    {
        [SerializeField]
        public KidController kidController;

        [SerializeField]
        public Sprite aliveSprite;

        [SerializeField]
        public Sprite deadSprite;

        private Image image;

        private void MarkAsDead()
        {
            image.sprite = deadSprite;
        }

        void Start()
        {
            image = GetComponent<Image>();
            image.sprite = aliveSprite;

            kidController.OnDie.AddListener(MarkAsDead);
        }

        void Destroy()
        {
            kidController.OnDie.RemoveListener(MarkAsDead);
        }
    }

}
