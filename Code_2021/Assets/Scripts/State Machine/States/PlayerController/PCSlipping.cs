using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCSlipping : PCAnyState {
    public PCSlipping (StateMachine stateMachine , Player player) : base (stateMachine , player) {
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

    protected override void OnJumpPressed (InputAction.CallbackContext context) { }

    protected override void PollSprinting () { }

    protected override void PollSlipping () {
        if (player.CharacterController.SureFooted ()) stateMachine.ChangeState (player.StateRunning);
    }

    protected override void Locomotion () {
        speed = player.Attributes.Speed.Value;
        if (player.CharacterController.SlopeAngle () != float.MaxValue) {
            Vector3 slipVelocity = player.CharacterController.SlopeDirection () * (-3f - Time.deltaTime);
            player.Motor.AddVelocity (slipVelocity , MoveType.External);
        }
        base.Locomotion ();
    }

    

    
}
