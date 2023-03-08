using QRTracking;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class ceilingQRVisualizer : MonoBehaviour
{
    public GameObject qrCodePlane;
    public string targetString = "Camera";
    private SpatialGraphCoordinateSystem spatialGraph;
    private GameObject plane;
    private TextMeshPro data;
    private QRScanner qRScanner;

    void Start()
    {
        spatialGraph = qrCodePlane.GetComponent<SpatialGraphCoordinateSystem>();
        plane = qrCodePlane.transform.Find("Cube").gameObject;
        data = qrCodePlane.transform.Find("Text").GetComponent<TextMeshPro>();

        qRScanner = GetComponent<QRScanner>();
        qRScanner.OnScanned
            .Subscribe(qr =>
            {
                if (qr.Data != targetString)
                    return;
                qrCodePlane.SetActive(true);
                spatialGraph.Id = qr.SpatialGraphNodeId;
                plane.transform.localPosition = new Vector3(qr.PhysicalSideLength / 2, qr.PhysicalSideLength / 2, 0);
                plane.transform.localScale = new Vector3(qr.PhysicalSideLength, qr.PhysicalSideLength, 0.001f);
                data.text = qr.Data;
                //data.gameObject.transform.localPosition = new Vector3(qr.PhysicalSideLength / 2, qr.PhysicalSideLength / 2, -0.001f);
                data.gameObject.transform.localPosition = new Vector3(qr.PhysicalSideLength / 2, qr.PhysicalSideLength / 2, 0.1f);
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