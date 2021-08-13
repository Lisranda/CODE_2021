using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCFalling : PCAnyState {
    public PCFalling (StateMachine stateMachine , Player player) : base (stateMachine , player) {
    }

    public override void OnEnter () {
        base.OnEnter ();
        player.Motor.ResetMovementVelocity (false);
        player.Motor.ResetYVelocity (false);
        player.Motor.AddLastFrameMovementVelocity ();
    }

    public override void OnExit () {
        base.OnExit ();
        player.Motor.ResetMovementVelocity (true);
        player.Motor.ResetYVelocity (true);
    }

    public override void Tick () {
        base.Tick ();
    }

    public override void FixedTick () {
        base.FixedTick ();
    }

    protected override void OnJumpPressed (InputAction.CallbackContext context) { }

    protected override void PollSprinting () { }

    protected override void PollSlipping () { }

    protected override void PollGrounded () {
        if (player.CharacterController.isGrounded) stateMachine.ChangeState (player.StateRunning);
    }

    protected override void Locomotion () {
        speed = player.Attributes.FallControlSpeed.Value * Time.deltaTime;
        base.Locomotion ();
    }
}
