using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activechange_true : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject image_viewer;
    bool object_enable;
    void Start()
    {
        object_enable = true;
        image_viewer.SetActive(object_enable);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void toggleEnable()
    {
        object_enable = !object_enable;
        image_viewer.SetActive(object_enable);
    }
}
