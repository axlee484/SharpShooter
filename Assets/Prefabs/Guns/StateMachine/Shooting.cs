using UnityEngine;

namespace GunStates.StateMachine
{
    public class Shooting : BaseState<GunStateType, GunContext>
    {
        private readonly Timer fireRateTimer;

        public Shooting(GunStateType stateId, GunContext context) : base(stateId, context)
        {
            fireRateTimer = Context.gun.FireRateTimer;
        }

        private void ShootRayCast()
        {
            var rayCastHit = Physics.Raycast(
                            Camera.main.transform.position,
                            Camera.main.transform.forward,
                            out RaycastHit hit,
                            Context.gun.gunConfig.Range
                            );
            if (rayCastHit)
            {
                var hurtBox = hit.collider.GetComponentInParent<HurtBox>();
                if(hurtBox != null)
                {
                    hurtBox.InvokeTakeHit(Context.gun.gunConfig.Damage);
                }
                Debug.Log("Shot at: " + hit.collider.gameObject.name);
            }
        }
        public override void Enter()
        {
            if(Context.gun.BulletsRemaining == 0) 
            {
                InvokeChangeState(GunStateType.Reloading);
                return;
            }
            ShootRayCast();
            Context.gun.SetBulletsRemaining(Context.gun.BulletsRemaining - 1);
            Context.gun.SetCanShoot(false);
            Context.gun.SetCanReload(false);

            fireRateTimer.TimerFinishedEvent += OnTimerFinished;
            fireRateTimer.StartTimer();
        }
        private void OnTimerFinished()
        {
            InvokeChangeState(GunStateType.Idle);
        }

        public override void Exit()
        {
            Context.gun.SetCanShoot(true);
            if(Context.gun.BulletsRemaining < Context.gun.gunConfig.MagazineSize) Context.gun.SetCanReload(true);
            fireRateTimer.TimerFinishedEvent -= OnTimerFinished;
            fireRateTimer.ResetTimer();
        }
    }
}