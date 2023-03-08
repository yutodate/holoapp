using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;
using System;

public class CubeResize : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject indexTip;
    public GameObject head;
    public GameObject Pin;
    bool flag;
    void Start()
    {
        //indexTip = GameObject.CreatePrimitive(PrimitiveType.Cube);  //表示用の立方体を作成
        //indexTip.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);  //大きさを指定
    }

    // Update is called once per frame
    void Update()
    {
        double d;

        //右手の人差し指の指先の位置情報を取得
        if (flag == true)
        {


            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose))
            {
                //indexTip.transform.position = pose.Position; //座標を設定
                var eulerAngles = pose.Rotation.eulerAngles;
                indexTip.transform.eulerAngles = new Vector3(0, eulerAngles.y,0); //回転を設定
                d = Math.Sqrt(Math.Pow(head.transform.position.x - pose.Position.x, 2) + Math.Pow(head.transform.position.y - pose.Position.y, 2) + Math.Pow(head.transform.position.z - pose.Position.z, 2));
                d = 1 - d;
                indexTip.transform.localScale = new Vector3((float)d, (float)d, (float)d);
                indexTip.transform.position = Pin.transform.position+ new Vector3(0, (float)d/2, 0);

            }

        }
    }
    public void setcubeflag()
    {
        if (flag==true)
        {
            flag = false;
        }
        else
        {
            flag = true;
        }
    }
}
