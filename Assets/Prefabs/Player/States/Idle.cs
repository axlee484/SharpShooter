using UnityEngine;

namespace PlayerStates.StateMachine
{
    public class Idle: BaseState<PlayerStateType, PlayerContext>
    {
        public Idle(PlayerStateType stateId, PlayerContext playerContext): base(stateId, playerContext){}
    }
}