using UnityEngine;

namespace PlayerStates.StateMachine
{
    public class Moving: BaseState<PlayerStateType, PlayerContext>
    {
        public Moving(PlayerStateType stateId, PlayerContext playerContext): base(stateId, playerContext){}
    }
}