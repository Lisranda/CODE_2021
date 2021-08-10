using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCWalking : PCGrounded {
    public PCWalking (StateMachine stateMachine , Player player) : base (stateMachine , player) {
    }

    public override void OnEnter () {
        base.OnEnter ();
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
        stateMachine.ChangeState (player.StateRunning);
    }
}
