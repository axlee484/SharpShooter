using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace PlayerStates.StateMachine
{
    public enum PlayerStateType
    {
        Idle,
        Moving,
        Jumping,
        Dead,
        None
    }
    

    public readonly struct PlayerContext
    {
        private readonly Player player;
        public readonly Player Player => player;
        public PlayerContext(Player player)
        {
            this.player = player;
        }
    }


    public class PlayerStateMachine: BaseStatemachine<PlayerStateType, PlayerContext>
    {
        private Player player;
        private void Awake()
        {
            player = GetComponent<Player>();
        }
        protected override Dictionary<PlayerStateType, BaseState<PlayerStateType, PlayerContext>> Init()
        {
            var states = new Dictionary<PlayerStateType, BaseState<PlayerStateType, PlayerContext>>();
            PlayerContext playerContext = new(player);
            var idleState = new Idle(PlayerStateType.Idle, playerContext);
            var movingState = new Moving(PlayerStateType.Moving, playerContext);
            var jumpingState = new Jumping(PlayerStateType.Jumping, playerContext);
            var deadState = new Dead(PlayerStateType.Dead, playerContext);
            states.Add(PlayerStateType.Idle, idleState);
            states.Add(PlayerStateType.Moving, movingState);
            states.Add(PlayerStateType.Jumping, jumpingState);
            states.Add(PlayerStateType.Dead, deadState);

            return states;
        }
    }
}
