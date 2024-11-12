using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState playerIdle {  get; private set; }
    public PlayerStateMove playerMove { get; private set; }
    public PlayerStateAttack playerAttack { get; private set; }
    public Rigidbody2D rb {  get; private set; }
    public Animator anim;


    public VariableJoystick joystick;

    private float xInput;
    private float yInput;
    private bool isKnocked;

    public float playerSpeed;
    public Button attackButton;
    public GameObject facingSword;
    public bool isBusy { get; private set; }
    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        playerIdle = new PlayerIdleState(this, stateMachine, "Idle");
        playerMove = new PlayerStateMove(this, stateMachine, "Move");
        playerAttack = new PlayerStateAttack(this, stateMachine, "Attack");
    }

    void Start()
    {
        stateMachine.Initialize(playerIdle);

        rb = GetComponent<Rigidbody2D>();
        xInput = UnityEngine.Input.GetAxisRaw("Horizontal");
        yInput = UnityEngine.Input.GetAxisRaw("Vertical");

        attackButton.onClick.AddListener(AttackPlayer);
    }
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    void Update()
    {
        stateMachine.currentState.Update();
        MovePlayer();

    }
    private void MovePlayer()
    {
            rb.velocity = new Vector2(joystick.Direction.x * playerSpeed, joystick.Direction.y * playerSpeed);
            anim.SetFloat("x",xInput = joystick.Direction.x);
            anim.SetFloat("y",yInput = joystick.Direction.y);
    }
    public void ZoreVelocity()
    {
        if (isKnocked) return;

        playerSpeed = 0;
    }
    public void AttackPlayer()
    {
        stateMachine.ChangeState(playerAttack);
    }
    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }
    public void FacingSword()
    {

    }
}
