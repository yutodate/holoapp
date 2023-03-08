using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using TMPro;

// public class RayInputTest : BaseInputHandler, IMixedRealityInputHandler
public class RayInputTest : MonoBehaviour
{
    // public static PointerUtils pointer;
    private TextMeshPro data;
    public GameObject obj;
    private int count;
    static private int max_count = 60*3;

    // Start is called before the first frame update
    void Start()
    {
        data = obj.GetComponent<TextMeshPro>();
        count = 0;
    }
    // Update is called once per frame
    void Update()
    {
        count ++;
        if (count > max_count){
            count = max_count;
            obj.SetActive(false);
        }else{

        }
    }
    public void Task(){
        obj.SetActive(true);
        count = 0;
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose)){
            Vector3 position;
            // if(PointerUtils.TryGetPointerEndpoint<LinePointer>(Handedness.Both, out position)){
            if(PointerUtils.TryGetHandRayEndPoint(Handedness.Right, out position)){
                // data.text = "X:"+position.x.ToString() + "\nY:"+position.y.ToString() + "\nZ:"+position.z.ToString();
                data.text = "Send a coodinate!!";
            }else{
                data.text = "Not found hands";
            }
        }else{
            data.text = "Here is no Right Hand!";
        }
    }
}
