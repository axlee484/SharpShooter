using UnityEngine;

namespace GunStates.StateMachine
{
    public class Reloading: BaseState<GunStateType, GunContext>
    {
        public Reloading(GunStateType stateId, GunContext context): base(stateId, context){}

        public override void Enter()
        {
            if(Context.gun.BulletsRemaining == Context.gun.gunConfig.MagazineSize)
            {
                Context.gun.SetCanReload(false);
                InvokeChangeState(GunStateType.Idle);
                return;
            }
            Context.gun.ReloadTimeTimer.TimerFinishedEvent += OnTimerFinished;
            Context.gun.ReloadTimeTimer.StartTimer();
            Context.gun.PlaySound(Context.gun.ReloadSound);
        }
        private void OnTimerFinished()
        {
            Context.gun.SetBulletsRemaining(Context.gun.gunConfig.MagazineSize);
            Debug.Log("Reloaded: bullets remaining: " + Context.gun.BulletsRemaining);
            InvokeChangeState(GunStateType.Idle);
        }

        public override void Exit()
        {
            Context.gun.ReloadTimeTimer.TimerFinishedEvent -= OnTimerFinished;
            Context.gun.ReloadTimeTimer.ResetTimer();
            Context.gun.SetCanReload(false);
        }
    }
}