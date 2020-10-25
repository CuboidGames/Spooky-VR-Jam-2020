using UnityEngine;
using System.Collections;
using KidStates;
using UnityEngine.AI;

public class KidController : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;

    private AbstractKidState kidState;

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

    void HandleKidState()
    {
        if (kidState != null)
        {
            kidState.Update();
        } 
        else
        {
            SetState(new NavigatingState(this));
        }
    }
}