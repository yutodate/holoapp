using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
public class Setcursor_pin : MonoBehaviour
{
    public void SetcusorTransform()
    {
        

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose))
        {
            Vector3 cursor_position;
            // if(PointerUtils.TryGetPointerEndpoint<LinePointer>(Handedness.Both, out cursor_position)){
            if (PointerUtils.TryGetHandRayEndPoint(Handedness.Right, out cursor_position))
            {

                Quaternion quaternion;
                quaternion.x = 0;
                quaternion.y = 0;
                quaternion.z = 0;
                quaternion.w = 0;
                this.transform.SetPositionAndRotation(cursor_position, quaternion);
            }
            else
            {
            }
        }
        else
        {
        }
    }
}
