using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelCoordinate : MonoBehaviour
{

    public Vector3 nowLocalPosition;
    public Quaternion nowLocalQuaternion;
    public float x_max = 150.0f;
    public float y_max = 110.0f;
    // Start is called before the first frame update
    void Start()
    {
        // cursor = this.transform.Find("Sphere").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(cursor.transform.localPosition);
        nowLocalPosition = this.transform.localPosition;
        if(nowLocalPosition.x <= -x_max)   nowLocalPosition.x = -x_max;
        else if(nowLocalPosition.x >=  x_max)   nowLocalPosition.x =  x_max;
        if(nowLocalPosition.y <= -y_max)   nowLocalPosition.y = -y_max;
        else if(nowLocalPosition.y >=  y_max)   nowLocalPosition.y =  y_max;
        this.transform.localPosition = new Vector3( nowLocalPosition.x, nowLocalPosition.y, 0);

        Vector3 _Rotation = gameObject.transform.localEulerAngles;
        this.transform.localRotation = Quaternion.Euler( 0, 0, _Rotation.z);

        nowLocalPosition = this.transform.localPosition;
        nowLocalQuaternion = this.transform.localRotation;
        // Debug.Log(this.transform.localPosition);
    }
}
