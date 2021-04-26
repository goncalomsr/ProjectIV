using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSky : MonoBehaviour
{

    public Material sky1;
    public Material sky2;
    public float Timer = 20f;
  
  public void Update()
    {

        if (Timer > 0)
        {
            Timer = Timer - Time.deltaTime;
        }

        if (Timer <= 10f)
        {
            RenderSettings.skybox = sky1;
        }

        if (Timer <= 0f)
        {
            RenderSettings.skybox = sky2;
        }
    }
}
