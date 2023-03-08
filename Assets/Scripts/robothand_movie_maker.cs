using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robothand_movie_maker : MonoBehaviour
{

    public GameObject lefthand;
    public GameObject righthand;
    public Vector3 nowLocalPosition;
    public Quaternion nowLocalQuaternion;
    public float x_max = 150.0f;
    public float y_max = 110.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        nowLocalPosition = this.transform.localPosition;
        if(nowLocalPosition.x <= -x_max)   nowLocalPosition.x = -x_max;
        else if(nowLocalPosition.x >=  x_max)   nowLocalPosition.x =  x_max;
        if(nowLocalPosition.y <= -y_max)   nowLocalPosition.y = -y_max;
        else if(nowLocalPosition.y >=  y_max)   nowLocalPosition.y =  y_max;
        this.transform.localPosition = new Vector3( nowLocalPosition.x, nowLocalPosition.y, 0);

        Vector3 _Rotation = gameObject.transform.localEulerAngles;
        this.transform.localRotation = Quaternion.Euler( 0, 0, _Rotation.z);

        float sin = Mathf.Sin(Time.time);
        lefthand.transform.localRotation  = Quaternion.Euler(0.0f,  0.0f, this.map(sin, 1.0f, -1.0f, 45.0f, -10.0f));
        righthand.transform.localRotation = Quaternion.Euler(0.0f,180.0f, this.map(sin, 1.0f, -1.0f, 45.0f, -10.0f));

        nowLocalPosition = this.transform.localPosition;
        nowLocalQuaternion = this.transform.localRotation;

        Debug.Log(nowLocalPosition);
    }

    private float map(float val, float in_max,float in_min, float out_max, float out_min){
        return (val-in_min) * (out_max-out_min)/(in_max-in_min) + out_min;
    }
}
