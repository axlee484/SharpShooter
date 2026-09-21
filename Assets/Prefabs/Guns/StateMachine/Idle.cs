using UnityEngine;

namespace GunStates.StateMachine
{
    public class Idle: BaseState<GunStateType, GunContext>
    {
        public Idle(GunStateType stateId, GunContext context): base(stateId, context){}
        public override void Enter()
        {
            Debug.Log("Idle: bullets remaining: " + Context.gun.BulletsRemaining);
        }

        private void TryFire()
        {
            if(!Context.gun.CanShoot) return;
            InvokeChangeState(GunStateType.Shooting);
            
        }

        private void TryReload()
        {
            if(!Context.gun.CanReload) return;
            InvokeChangeState(GunStateType.Reloading);
        }
        public override void Update()
        {
            if(Context.gun.IsTriggerPressed) TryFire();
            else if (Context.gun.IsReloadPressed) TryReload();
        }
    }
}