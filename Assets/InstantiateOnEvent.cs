using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnEvent : MonoBehaviour
{
    public GameObject prefab;
    public Transform point;

    public void Activate()
    {
        Instantiate(prefab, point.position, new Quaternion(0,0,0,0));
    }
}
