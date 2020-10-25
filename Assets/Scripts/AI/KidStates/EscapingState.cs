﻿using UnityEngine;

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
            kidController.navMeshAgent.destination = GetClosestEscapePosition();
        }

        public override void OnStateExit()
        { 
        }

        public override void Update()
        {
            if (GetDistanceToPlayer() > 30)
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

