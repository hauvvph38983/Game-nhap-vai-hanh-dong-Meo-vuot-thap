using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateAttack : PlayerState
{
    private int comboCounter;

    private float lastTimeAttacked;
    private float comboWindow = 2;
    public PlayerStateAttack(Player _player, PlayerStateMachine _StateMachine, string _animBoolName) : base(_player, _StateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (comboCounter > 1 || Time.time >= lastTimeAttacked + comboWindow)
        {
            comboCounter = 0;
        }
        if (comboCounter == 0)
        {
            player.facingSword.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            player.facingSword.transform.localRotation = Quaternion.Euler(180, 180, 0);
        }
        player.anim.SetInteger("ComboAttack", comboCounter);

        stateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();
        player.StartCoroutine("BusyFor", .15f);
        comboCounter++;
        lastTimeAttacked = Time.time;

    }

    public override void Update()
    {
        base.Update();

        if(triggerCalled)
        {
            stateMachine.ChangeState(player.playerIdle);
        }
    }
}
