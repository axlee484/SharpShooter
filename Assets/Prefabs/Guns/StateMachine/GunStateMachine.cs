using System.Collections.Generic;
using UnityEngine;

namespace  GunStates.StateMachine
{
    public enum GunStateType
    {
        Idle,
        Inspecting,
        Shooting,
        Reloading
    }
    public readonly struct GunContext
    {
        public readonly BaseGun gun;
        public GunContext(BaseGun gun)
        {
            this.gun = gun;
        }
    }
    public class GunStateMachine: BaseStatemachine<GunStateType, GunContext>
    {
        protected override Dictionary<GunStateType, BaseState<GunStateType, GunContext>> Init()
        {
            var gun = GetComponent<BaseGun>();
            var gunContext = new GunContext(gun);
            var states = new Dictionary<GunStateType, BaseState<GunStateType, GunContext>>();

            var idleState = new Idle(GunStateType.Idle, gunContext);
            var inspectingState = new Inspecting(GunStateType.Inspecting, gunContext);
            var shootingState = new Shooting(GunStateType.Shooting, gunContext);
            var reloadingState = new Reloading(GunStateType.Reloading, gunContext);
            states.Add(GunStateType.Idle, idleState);
            states.Add(GunStateType.Shooting, shootingState);
            states.Add(GunStateType.Reloading, reloadingState);
            states.Add(GunStateType.Inspecting, inspectingState);
            return states;
        }

    }
}