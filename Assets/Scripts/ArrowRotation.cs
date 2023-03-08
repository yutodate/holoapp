using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
     [HideInInspector]
    public Vector3 startPosition = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        // Debug.Log( startPosition);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0.2f, 0));
        this.transform.position = new Vector3( startPosition.x, startPosition.y + 0.1f*Mathf.Sin(Time.time), startPosition.z);
    }
}
