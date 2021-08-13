using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    protected override void PollSprinting () { }

    protected override void PollSlipping () {
        if (player.CharacterController.SureFooted ()) stateMachine.ChangeState (player.StateRunning);
    }

    protected override void Locomotion () {
        speed = player.Attributes.Speed.Value;
        Vector2 movementInput = player.PlayerInput.CharacterInput.Locomotion.ReadValue<Vector2> ();
        player.Motor.HandleSlippingInput (movementInput , speed , player.CharacterController.SlopeDirection () , -3f - Time.deltaTime);
    }

    

    
}
