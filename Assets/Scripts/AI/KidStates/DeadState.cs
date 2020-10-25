using System.Collections;
using UnityEngine;

namespace KidStates
{
    public class DeadState : AbstractKidState
    {
        public DeadState(KidController kidController) : base(kidController)
        {
        }

        public override void OnStateEnter()
        {
            kidController.navMeshAgent.isStopped = true;
            kidController.animationController.SetBool("isDead", true);
            kidController.navMeshAgent.destination = kidController.transform.position;
            kidController.candyParticleSystem.Stop();
        }

        public override void OnStateExit()
        {
            kidController.navMeshAgent.isStopped = false;
            kidController.animationController.SetBool("isDead", false);
            kidController.candyParticleSystem.Play();
        }

        public override void Update()
        {
        }
    }
}

