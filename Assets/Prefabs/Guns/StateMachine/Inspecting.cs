using UnityEngine;

namespace GunStates.StateMachine
{
    public class Inspecting: BaseState<GunStateType, GunContext>
    {
        public Inspecting(GunStateType stateId, GunContext context): base(stateId, context){}
    }
}