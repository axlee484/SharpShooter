using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseStatemachine<TStateType, TContext>  : MonoBehaviour
where TStateType: Enum
where TContext: struct
{
    [SerializeField] private TStateType initialStateId;
    protected Dictionary<TStateType, BaseState<TStateType, TContext>> states = new();
    private BaseState<TStateType, TContext> currentState;
    public BaseState<TStateType, TContext> CurrentState => currentState;
    protected abstract Dictionary<TStateType, BaseState<TStateType, TContext>> Init();
    private void Start()
    {
        states = Init();
        if(states.Count <=0) throw new Exception("Init states not implemented");
        foreach(var (stateId, state) in states)
        {
            state.ChangeStateEvent += OnStateChange;
        }
        currentState = states[initialStateId];
        currentState.Enter();
    }

    private void OnStateChange(TStateType nextStateId)
    {
        currentState.Exit();
        currentState = states[nextStateId];
        currentState.Enter();
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        currentState.OnCollisionExit(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        currentState.OnCollisionStay(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }

    private void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }



}
