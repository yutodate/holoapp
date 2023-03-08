using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDestination : MonoBehaviour
{
    /// <summary>
    /// 受け取ったトランスフォームをオブジェクトに反映する
    /// </summary>
    /// <param name="a_transform"></param>
    public void SetTransform(Transform a_transform)
    {
        this.transform.SetPositionAndRotation(a_transform.position, a_transform.rotation);
    }
}