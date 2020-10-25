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
            // TODO: use group target
        }

        public override void OnStateExit()
        {
        }

        public override void Update()
        {
            if (GetDistanceToPlayer() < 10) {
                kidController.SetState(new EscapingState(kidController));
            }
        }
    }
}

