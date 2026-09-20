using UnityEngine;

namespace PlayerStates.StateMachine
{
    public class Dead: BaseState<PlayerStateType, PlayerContext>
    {
        public Dead(PlayerStateType stateId, PlayerContext playerContext): base(stateId, playerContext){}
    }
}