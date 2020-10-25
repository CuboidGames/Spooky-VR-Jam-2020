using UnityEngine;
using System.Collections;
using KidStates;

namespace Assets.Scripts.AI
{
    public class GroupController : MonoBehaviour
    {
        public Transform currentGoal;

        private GameObject[] houseEntrances;
        private KidController[] kidControllers;

        public void GetGroupKids()
        {
            kidControllers = GetComponentsInChildren<KidController>();
        }

        public void GetNewTarget()
        {
            houseEntrances = GameObject.FindGameObjectsWithTag("HouseEntrance");
            currentGoal = houseEntrances[Random.Range(0, houseEntrances.Length)].transform;

            foreach (var kidController in kidControllers)
            {
                if (!(kidController.kidState is EscapingState) && kidController.kidState != null)
                {
                    kidController.SetState(new NavigatingState(kidController));
                }
            }
        }
    }
}