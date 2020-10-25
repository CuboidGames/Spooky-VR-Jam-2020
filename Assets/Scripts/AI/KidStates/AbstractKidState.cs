using UnityEngine;

namespace KidStates
{
    public abstract class AbstractKidState
    {
        protected KidController kidController;
        protected GameObject player;

        public AbstractKidState(KidController kidController)
        {
            this.kidController = kidController;
            this.player = GameObject.FindGameObjectWithTag("Player");
        }

        public abstract void Update();

        public abstract void OnStateEnter();
        public abstract void OnStateExit();

        protected float GetDistanceToPlayer()
        {
            return Vector3.Distance(kidController.transform.position, player.transform.position);
        }
    }
}