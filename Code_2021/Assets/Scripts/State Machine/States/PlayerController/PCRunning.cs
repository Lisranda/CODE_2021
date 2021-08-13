using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCRunning : PCAnyState {

    public PCRunning (StateMachine stateMachine , Player player) : base (stateMachine , player) {
    }

    public override void OnEnter () {
        base.OnEnter ();
        if (player.RememberWalking) stateMachine.ChangeState (player.StateWalking);
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

    protected override void Locomotion () {
        speed = player.Attributes.Speed.Value;
        base.Locomotion ();
    }
}
