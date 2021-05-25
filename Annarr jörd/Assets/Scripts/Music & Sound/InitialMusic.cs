using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialMusic : MonoBehaviour
{
    public float seconds;
    public GameObject MusicHandler;
    void Start()
    {
        StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(seconds);

    }
}
