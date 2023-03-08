using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class PointerAttach : MonoBehaviour, IMixedRealityPointerHandler
{
    private Color color_IdleState = Color.cyan;
    private Color color_OnHover = Color.white;
    private Color color_OnSelect = Color.blue;
    private Material material;
    public GameObject targetobject = null;
    // Start is called before the first frame update
    void Start()
    {
        material = targetobject.GetComponent<Renderer>().material;
        Debug.Log( material.color);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void IMixedRealityPointerHandler.OnPointerDown( MixedRealityPointerEventData eventData)
    {
        material.color = color_OnHover;
        Debug.Log( eventData.Pointer.Result.Details.Point);
    }

    void IMixedRealityPointerHandler.OnPointerUp( MixedRealityPointerEventData eventData)
    {
        material.color = color_IdleState;
    }

    void IMixedRealityPointerHandler.OnPointerDragged( MixedRealityPointerEventData eventData)
    {
        // aud
    }

    void IMixedRealityPointerHandler.OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        material.color = color_OnSelect;
    }
}