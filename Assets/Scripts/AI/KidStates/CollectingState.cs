using System.Collections;
using UnityEngine;

namespace KidStates
{
    public class CollectingState : AbstractKidState
    {
        private Coroutine coroutine;

        public CollectingState(KidController kidController) : base(kidController)
        {
        }

        public override void OnStateEnter()
        {
            coroutine = kidController.StartCoroutine(CollectCoroutine());
            kidController.candyParticleSystem.Stop();
        }

        public override void OnStateExit()
        {
            if (coroutine != null)
            {
                kidController.StopCoroutine(CollectCoroutine());
            }
            kidController.candyParticleSystem.Play();
        }

        public override void Update()
        {
            if (GetDistanceToPlayer() < 10) {
                kidController.SetState(new EscapingState(kidController));
            }
        }

        private IEnumerator CollectCoroutine()
        {
            yield return new WaitForSeconds(10);
            kidController.groupController.GetNewTarget();
            coroutine = null;
        }
    }
}

