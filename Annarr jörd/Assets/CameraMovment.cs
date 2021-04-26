using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    public Transform[] viewpoint;
    public bool startmoving;
    
    public int actualPos;

    public float speed;


    void Start()
    {
        StartCoroutine("waitTime");
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, viewpoint[actualPos].position, speed);

    }

    private IEnumerator waitTime()
    {
        yield return new WaitForSeconds(3f);
        actualPos++;

    }
}
