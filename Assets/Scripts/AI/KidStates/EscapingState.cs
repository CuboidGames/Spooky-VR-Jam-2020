using UnityEngine;
using UnityEngine.AI;

namespace KidStates
{
    public class EscapingState : AbstractKidState
    {
        private GameObject[] escapeObjects;

        public EscapingState(KidController kidController) : base(kidController)
        {
            escapeObjects = GameObject.FindGameObjectsWithTag("EscapeObject");
        }

        public override void OnStateEnter()
        {
            Vector3 targetPosition = GetClosestEscapePosition();
            NavMeshPath path = new NavMeshPath();

            kidController.navMeshAgent.speed = 7.5f;
            kidController.navMeshAgent.destination = targetPosition;
            kidController.navMeshAgent.CalculatePath(targetPosition, path);
            kidController.animationController.SetInteger("state", 2);
        }

        public override void OnStateExit()
        { 
        }

        public override void Update()
        {
            if (GetDistanceToPlayer() > 60)
            {
                kidController.SetState(new NavigatingState(kidController));
            }
        }

        // Gets the vector3 of the closest place to escape (in straight line, not using NavMeshAgent)
        private Vector3 GetClosestEscapePosition()
        {
            if (escapeObjects.Length == 0)
            {
                return Vector3.zero;
            }

            Vector3 closestEscapePosition = escapeObjects[0].transform.position;

            foreach (var escapeObject in escapeObjects)
            {
                // TODO: avoid walking towards player 
                if (Vector3.Distance(kidController.transform.position, escapeObject.transform.position) < Vector3.Distance(kidController.transform.position, closestEscapePosition))
                {
                    closestEscapePosition = escapeObject.transform.position;
                }
            }

            return closestEscapePosition;
        }
    }
}

