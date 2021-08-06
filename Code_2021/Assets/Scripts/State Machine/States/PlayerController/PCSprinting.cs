using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCSprinting : PCGrounded {
    public PCSprinting (StateMachine stateMachine , Player player) : base (stateMachine , player) {
        this.stateMachine = stateMachine;
        this.player = player;
        this.cam = Camera.main;
        this.transform = player.transform;
        this.playerInput = player.PlayerInput;
    }

    public override void OnEnter () {
        base.OnEnter ();
    }

    public override void OnExit () {
        base.OnExit ();
    }

    public override void Tick () {
        base.Tick ();
        PollSprinting ();
    }

    public override void FixedTick () {
        base.FixedTick ();
    }

    protected override void OnSprintPressed (InputAction.CallbackContext context) {
        return;
    }

    protected virtual void PollSprinting () {
        if (playerInput.CharacterInput.Sprint.ReadValue<float> () == 0) stateMachine.ChangeState (player.StateRunning);
    }
}
