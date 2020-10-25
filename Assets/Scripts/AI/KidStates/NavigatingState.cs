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
            kidController.navMeshAgent.destination = kidController.groupController.currentGoal.position;
        }

        public override void OnStateExit()
        {
        }

        public override void Update()
        {
            if (GetDistanceToPlayer() < 10) {
                kidController.SetState(new EscapingState(kidController));
            } else if (Vector3.Distance(kidController.transform.position, kidController.navMeshAgent.destination) < 3)
            {
                kidController.SetState(new CollectingState(kidController));
            }
        }
    }
}

