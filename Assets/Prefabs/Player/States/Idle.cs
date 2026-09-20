using StarterAssets;
using UnityEngine;

namespace PlayerStates.StateMachine
{
    public class Idle: BaseState<PlayerStateType, PlayerContext>
    {
        public Idle(PlayerStateType stateId, PlayerContext playerContext): base(stateId, playerContext)
        {
            input = Context.Player.GetComponent<StarterAssetsInputs>();
        }
        private StarterAssetsInputs input;
        public override void Enter()
        {
            Debug.Log("Idle");
        }

        private bool IsMoving()
        {
            return input.move != Vector2.zero;
        }
        private bool IsJumping()
        {
            return input.jump;
        }
        public override void Update()
        {
            if(IsMoving()) InvokeChangeState(PlayerStateType.Moving);
            if(IsJumping()) InvokeChangeState(PlayerStateType.Jumping);
        }
    }
}