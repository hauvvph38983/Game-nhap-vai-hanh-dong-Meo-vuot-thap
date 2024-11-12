using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    public PlayerStateMachine stateMachine;
    public Player player;
    private string animBoolName;

    public VariableJoystick joystick;
    public Rigidbody2D rb;

    protected float stateTimer;
    protected bool triggerCalled;
    public PlayerState(Player _player,PlayerStateMachine _StateMachine,string _animBoolName)
    {
        player = _player;
        stateMachine = _StateMachine;
        animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName,true);
        joystick = player.joystick;
        rb = player.rb;
        triggerCalled = false;
    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime; 
    }
    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName,false);
    }
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
