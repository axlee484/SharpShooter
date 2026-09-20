using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStatemachine<TStateType, TContext>  : MonoBehaviour
where TStateType: Enum
where TContext: struct
{
    [SerializeField] private TStateType initialStateId;
    protected Dictionary<TStateType, IState> states = new();
    private IState currentState;
    public IState CurrentState => currentState;
    protected abstract Dictionary<TStateType, IState> Init();
    private void Start()
    {
        states = Init();
        if(states.Count <=0) throw new Exception("Init states not implemented");
        foreach(var (stateId, state) in states)
        {
            (state as BaseState<TStateType, TContext>).ChangeStateEvent += OnStateChange;
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


}
