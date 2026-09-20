using System;
using UnityEngine;


public abstract class BaseState<TStateType, TContext>
{

    public BaseState(TStateType stateId, TContext context)
    {
        this.stateId = stateId;
        this.context = context;
    }


    public event Action<TStateType> ChangeStateEvent;
    protected void InvokeChangeState(TStateType nextStateId)
    {
        ChangeStateEvent?.Invoke(nextStateId);
    }
    private readonly TStateType stateId;
    public TStateType StateId => stateId;

    private readonly TContext context;
    public TContext Context => context;
    public virtual void Exit(){}
    public virtual void Enter(){}
    public virtual void Update(){}
    public virtual void FixedUpdate(){}
    public virtual void OnCollisionEnter(Collision collision){}
    public virtual void OnCollisionStay(Collision collision){}
    public virtual void OnCollisionExit(Collision collision){}
    public virtual void OnTriggerEnter(Collider collider){}
    public virtual void OnTriggerStay(Collider collider){}
    public virtual void OnTriggerExit(Collider collider){}
}
