using UnityEngine;
using System.Collections;
using KidStates;
using UnityEngine.AI;
using Assets.Scripts.AI;
using UnityEngine.Events;

public class KidController : MonoBehaviour
{

    [SerializeField]
    public Animator animationController;

    [SerializeField]
    public ParticleSystem candyParticleSystem;

    public NavMeshAgent navMeshAgent;
    public GroupController groupController;

    public AbstractKidState kidState;

    public UnityEvent OnDie; 

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        HandleKidState();
    }

    public void SetState(AbstractKidState state)
    {
        if (kidState != null)
        {
            kidState.OnStateExit();
        }

        kidState = state;
        kidState.OnStateEnter();
    }

    public void RequestNewGroupTarget()
    {
        groupController.GetNewTarget();
    }

    public void Die()
    {
        SetState(new DeadState(this));
        OnDie.Invoke();
    }

    void HandleKidState()
    {
        if (kidState == null)
        {
            SetState(new NavigatingState(this));
        } 

        kidState.Update();
    }
}