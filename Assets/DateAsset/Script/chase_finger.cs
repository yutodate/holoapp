using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System;

public class chase_finger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject chaseObj;
    public bool chase_flag=false;
    public float speed = 0.005f;
    void Start()
    {
        //indexTip = GameObject.CreatePrimitive(PrimitiveType.Cube);  //表示用の立方体を作成
        //indexTip.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);  //大きさを指定
    }

    // Update is called once per frame
    void Update()
    {
        

        //右手の人差し指の指先の位置情報を取得
        if (chase_flag == true)
        {


            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose))
            {
                Vector3 vec = pose.Position - chaseObj.transform.position; //座標を設定
                double size = Math.Sqrt(Math.Pow(vec.x, 2) + Math.Pow(vec.y, 2) + Math.Pow(vec.z, 2));
                if (size>=0.03)
                {
                    vec = new Vector3(speed * vec.x / (float)size, speed * vec.y / (float)size, speed * vec.z / (float)size);
                    chaseObj.transform.position = chaseObj.transform.position + vec;
                    chaseObj.transform.rotation = Quaternion.LookRotation(vec, Vector3.up);
                }
                
                

            }

        }
    }
    public void set_chase_flag()
    {
        
        chase_flag = !chase_flag;
        
    }
    public void set_chase_flag_false()
    {

        chase_flag = false;

    }
}
