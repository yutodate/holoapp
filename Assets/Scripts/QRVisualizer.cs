using QRTracking;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class QRVisualizer : MonoBehaviour
{
    public GameObject qrCodePlane;
    public string targetString = "sample";
    private SpatialGraphCoordinateSystem spatialGraph;
    private GameObject plane;
    private TextMeshPro data;
    private QRScanner qRScanner;

    private GameObject arrow;

    void Start()
    {
        spatialGraph = qrCodePlane.GetComponent<SpatialGraphCoordinateSystem>();
        plane = qrCodePlane.transform.Find("Cube").gameObject;
        data = qrCodePlane.transform.Find("Text").GetComponent<TextMeshPro>();

        arrow = qrCodePlane.transform.Find("arrow").gameObject;

        qRScanner = GetComponent<QRScanner>();
        qRScanner.OnScanned
            .Subscribe(qr =>
            {
                Debug.Log(qr.Data);
                if( qr.Data != targetString)
                    return;
                qrCodePlane.SetActive(true);
                spatialGraph.Id = qr.SpatialGraphNodeId;
                plane.transform.localPosition = new Vector3(qr.PhysicalSideLength / 2, qr.PhysicalSideLength / 2, 0);
                plane.transform.localScale = new Vector3(qr.PhysicalSideLength, qr.PhysicalSideLength, 0.001f);
                data.text = qr.Data;
                data.gameObject.transform.localPosition = new Vector3(qr.PhysicalSideLength / 2, qr.PhysicalSideLength / 2, 0.1f);

                arrow.GetComponent<ArrowRotation>().startPosition = qrCodePlane.transform.position;
                arrow.transform.localScale = new Vector3(qr.PhysicalSideLength/3.0f, qr.PhysicalSideLength/3.0f, qr.PhysicalSideLength/3.0f);
                arrow.transform.rotation = Quaternion.Euler( 0.0f, arrow.transform.localRotation.y, 0.0f);
            })
            .AddTo(this);
        qRScanner.IsReady
            .Where(x => x)
            .First()
            .Subscribe(_ => qRScanner.StartScan())
            .AddTo(this);


        qrCodePlane.SetActive(false);
    }
}
