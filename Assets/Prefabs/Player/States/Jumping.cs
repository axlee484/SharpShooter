using StarterAssets;
using UnityEngine;

namespace PlayerStates.StateMachine
{
    public class Jumping: BaseState<PlayerStateType, PlayerContext>
    {
        private StarterAssetsInputs input;
        public Jumping(PlayerStateType stateId, PlayerContext playerContext): base(stateId, playerContext)
        {
            input = Context.Player.GetComponent<StarterAssetsInputs>();
        }
        private bool IsIdle()
        {
            return !input.jump;
        }
        public override void Enter()
        {
            Debug.Log("Jumping");
        }

        public override void Update()
        {
            if(IsIdle()) InvokeChangeState(PlayerStateType.Idle);
        }
    }
}