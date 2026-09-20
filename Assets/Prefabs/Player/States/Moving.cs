using StarterAssets;
using UnityEngine;

namespace PlayerStates.StateMachine
{
    public class Moving: BaseState<PlayerStateType, PlayerContext>
    {
        private StarterAssetsInputs input;
        public Moving(PlayerStateType stateId, PlayerContext playerContext): base(stateId, playerContext)
        {
            input = Context.Player.GetComponent<StarterAssetsInputs>();
        }

        private bool IsIdle()
        {
            return input.move == Vector2.zero;
        }
        private bool IsJumping()
        {
            return input.jump;
        }
        public override void Enter()
        {
            Debug.Log("Moving");
        }

        public override void Update()
        {
            if(IsIdle()) InvokeChangeState(PlayerStateType.Idle);
            if(IsJumping()) InvokeChangeState(PlayerStateType.Jumping);
        }
    }
}