using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCAnyState : State {
    protected Player player;

    public PCAnyState (StateMachine stateMachine , Player player) : base (stateMachine) {
        this.player = player;
    }

    public override void OnEnter () {
        base.OnEnter ();
    }

    public override void OnExit () {
        base.OnExit ();
    }

    public override void Tick () {
        base.Tick ();
        SetRotation ();
        SetLocomotion ();
    }

    public override void FixedTick () {
        base.FixedTick ();
    }

    protected virtual void SetRotation () {
        Plane normalPlane = new Plane (Vector3.up , player.transform.position);
        Ray ray = player.Cam.ScreenPointToRay (player.PlayerInput.CharacterInput.Cursor.ReadValue<Vector2> ());
        if (normalPlane.Raycast (ray , out float hitDistance)) {
            Vector3 hitPoint = ray.GetPoint (hitDistance);
            Quaternion targetRotation = Quaternion.LookRotation (hitPoint - player.transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            player.SetTargetRotation (targetRotation);
        }
    }

    protected virtual void SetLocomotion () {
        player.SetMovementDirection (player.PlayerInput.CharacterInput.Locomotion.ReadValue<Vector2> ());
    }
}
