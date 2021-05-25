using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserHandsKinect : MonoBehaviour
{
    public Transform mHandsMesh;

    private void Update()
    {
        mHandsMesh.position = Vector3.Lerp(mHandsMesh.position, transform.position, Time.deltaTime * 15);
    }

}
