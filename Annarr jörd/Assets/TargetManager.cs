using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public GameObject targets;

    private void Start()
    {
        Instantiate(targets, transform.position, Quaternion.identity);
    }

}
