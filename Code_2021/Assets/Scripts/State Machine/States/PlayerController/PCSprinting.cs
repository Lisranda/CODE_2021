using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCSprinting : PCGrounded {
    public PCSprinting (StateMachine stateMachine , Player player) : base (stateMachine , player) {
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
        if (player.PlayerInput.CharacterInput.Sprint.ReadValue<float> () == 0) stateMachine.ChangeState (player.StateRunning);
    }
}
