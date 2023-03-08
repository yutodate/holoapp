using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Input{
    public class getGazePosition : MonoBehaviour
    {
        // Start is called before the first frame update

        public GameObject pointer;
        void Start()
        {
            // Vector3 s = CoreServices.InputSystem.EyeGazeProvider.GazeDirection;
        }

        // Update is called once per frame
        void Update()
        {
            float static_distance = 6.0f;
            // gaze origin
            Vector3 gazeOrigin;
            // gaze direction
            Vector3 gazeDirection;
            // gaze Hit Point
            Vector3 gazeHitPoint;
            // gaze point static distance
            Vector3 gazePoint_static_distance;

            gazeOrigin      = CoreServices.InputSystem.EyeGazeProvider.GazeOrigin;
            gazeDirection   = CoreServices.InputSystem.EyeGazeProvider.GazeDirection;
            gazeHitPoint    = CoreServices.InputSystem.EyeGazeProvider.HitPosition;
            gazePoint_static_distance = gazeOrigin + gazeDirection.normalized * static_distance;

            if(gazeHitPoint.x == 0 && gazeHitPoint.x == 0 && gazeHitPoint.x == 0){
                pointer.transform.position = gazePoint_static_distance;
            }else{
                float distance_2_HitPoint = Vector3.SqrMagnitude( gazeHitPoint - gazeOrigin);
                if( distance_2_HitPoint < static_distance*static_distance){
                    // 一定距離より手前にヒットポインターがある場合
                    pointer.transform.position = gazeHitPoint;
                }else{
                    pointer.transform.position = gazePoint_static_distance;
                }

            }

            // Debug.Log(CoreServices.InputSystem.EyeGazeProvider.HitPosition);
        }
    }
}