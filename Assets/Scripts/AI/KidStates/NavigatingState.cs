using UnityEngine;

namespace KidStates
{
    public class NavigatingState : AbstractKidState
    {

        public NavigatingState(KidController kidController) : base(kidController)
        {
        }

        public override void OnStateEnter()
        {
            kidController.navMeshAgent.speed = 3.5f;
            kidController.navMeshAgent.destination = kidController.groupController.currentGoal.position;
            kidController.animationController.SetInteger("state", 1);
        }

        public override void OnStateExit()
        {
        }

        public override void Update()
        {
            if (GetDistanceToPlayer() < 30) {
                kidController.SetState(new EscapingState(kidController));
            } else if (Vector3.Distance(kidController.transform.position, kidController.navMeshAgent.destination) < 3)
            {
                kidController.SetState(new CollectingState(kidController));
            }
        }
    }
}

