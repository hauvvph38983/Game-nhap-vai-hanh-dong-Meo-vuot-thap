using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMove : PlayerState
{

    public PlayerStateMove(Player _player, PlayerStateMachine _StateMachine, string _animBoolName) : base(_player, _StateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(joystick.Direction.y == 0) stateMachine.ChangeState(player.playerIdle);
    }
}
