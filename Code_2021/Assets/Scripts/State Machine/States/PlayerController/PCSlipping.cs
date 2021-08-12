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
        OnSureFooted ();
        SlippingMovement ();
    }

    public override void FixedTick () {
        base.FixedTick ();
    }

    protected virtual void OnSureFooted () {
        if (player.CharacterController.SureFooted ()) stateMachine.ChangeState (player.StateRunning);
    }

    public virtual void SlippingMovement () {
        player.Motor.HandleSlidingMovement (player.CharacterController.SlopeDirection () , -3f - Time.deltaTime);
    }

    

    
}
