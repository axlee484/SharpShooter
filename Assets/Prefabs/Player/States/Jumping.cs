using UnityEngine;

namespace PlayerStates.StateMachine
{
    public class Jumping: BaseState<PlayerStateType, PlayerContext>
    {
        public Jumping(PlayerStateType stateId, PlayerContext playerContext): base(stateId, playerContext){}
    }
}