using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class CharacterControllerExtension {
    private static RaycastHit hit;

    public static bool SureFooted (this CharacterController CharacterController) {
        if (!CharacterController.isGrounded) {
            return false;
        }
        if (SlopeAngle (CharacterController) > CharacterController.slopeLimit) {
            return false;
        } 
        return true;
    }

    public static float SlopeAngle (this CharacterController CharacterController) {
        if (Physics.Raycast (CharacterController.transform.position , Vector3.down , out hit , (CharacterController.height / 2) + 1f)) {
            return Vector3.Angle (hit.normal , Vector3.up);
        }
        return float.MaxValue;
    }

    public static Vector3 SlopeDirection (this CharacterController CharacterController) {
        return Vector3.up - hit.normal * Vector3.Dot (Vector3.up , hit.normal);
    }
}
