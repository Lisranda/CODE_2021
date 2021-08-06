using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCRunning : PCGrounded {

    public PCRunning (StateMachine stateMachine , Player player) : base (stateMachine , player) {
        this.stateMachine = stateMachine;
        this.player = player;
        this.cam = Camera.main;
        this.transform = player.transform;
        this.playerInput = player.PlayerInput;
    }

    public override void OnEnter () {
        base.OnEnter ();
        if (player.rememberWalking) stateMachine.ChangeState (player.StateWalking);
    }

    public override void OnExit () {
        base.OnExit ();
    }

    public override void Tick () {
        base.Tick ();
    }

    public override void FixedTick () {
        base.FixedTick ();
    }

    protected override void OnWalkPressed (InputAction.CallbackContext context) {
        base.OnWalkPressed (context);
        stateMachine.ChangeState (player.StateWalking);
    }
}
