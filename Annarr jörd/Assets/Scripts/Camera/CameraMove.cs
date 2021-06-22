using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public enum CameraBehaviorType {Static, MoveToPosition, RotateAround};

[Serializable]
public class CameraInfo
{
    public string Description;
    public CameraBehaviorType behavior;
    public Transform startPostion;
    public Transform endPostion;
    public Transform target;
    public float speed;
    public float timer;
    public float waitTime;
    public bool startTimerNow;
    public bool continueMusic = true;
    public bool fadeOutLong = false;

    [Header("Sound FX")]
    public bool EnableSoundFX = false;
    [ConditionalHide("EnableSoundFX", true)]
    public AudioClip SFX;
    [ConditionalHide("EnableSoundFX", true)]
    public float volume = 1;
    [ConditionalHide("EnableSoundFX", true)]
    public bool fadeIn;
    [ConditionalHide("EnableSoundFX", true)]
    public bool fadeOut;
}

public class CameraMove : MonoBehaviour
{
    public bool secondEnding;
    public int secondCameraIndex;
    private int currentCameraIndex;
    public CameraInfo[] cameraInfo;
    private AudioSource musicHandler;


    void Start()
    {
        currentCameraIndex = 0;
        transform.position = cameraInfo[currentCameraIndex].startPostion.position;
        musicHandler = GetComponent<AudioSource>();
        cameraInfo[currentCameraIndex].volume = 1;

        Time.timeScale = 1;
    }

    void Update()
    {
        if(currentCameraIndex == 25)
        {
            Time.timeScale = 1;
        }

        if (currentCameraIndex < cameraInfo.Length)
        {
            if (cameraInfo[currentCameraIndex].behavior == CameraBehaviorType.Static)
            {
                transform.position = cameraInfo[currentCameraIndex].startPostion.position;
                transform.LookAt(cameraInfo[currentCameraIndex].target);
                cameraInfo[currentCameraIndex].timer += Time.deltaTime;

                #region Sound Effects
                if (cameraInfo[currentCameraIndex].EnableSoundFX == true)
                {
                    if (!musicHandler.isPlaying)
                    {
                        musicHandler.PlayOneShot(cameraInfo[currentCameraIndex].SFX);
                        // Fade In
                        if (cameraInfo[currentCameraIndex].fadeIn == true)
                        {
                            print("IN");
                            StopAllCoroutines();
                            StartCoroutine(FadeIn(musicHandler,
                            0.5f, 0, cameraInfo[currentCameraIndex].volume));
                        }
                        // Fade Out
                        if (cameraInfo[currentCameraIndex].fadeOut == true)
                        {
                            StartCoroutine(FadeOut(musicHandler,
                            2f, cameraInfo[currentCameraIndex].volume, 0, cameraInfo[currentCameraIndex].waitTime - 2f));
                        }
                    }
                }

                // Fade Out Long
                if (cameraInfo[currentCameraIndex].timer > (cameraInfo[currentCameraIndex].waitTime - 2f))
                {
                    if (cameraInfo[currentCameraIndex].continueMusic == false && cameraInfo[currentCameraIndex].fadeOutLong == true)
                    {
                        Debug.Log("STATIC");
                        StartCoroutine(FadeOut(musicHandler,
                            2f, cameraInfo[currentCameraIndex].volume, 0, 0));
                        cameraInfo[currentCameraIndex].fadeOutLong = false;
                    }
                }
                #endregion

                //Second Ending
                if (secondEnding == true && cameraInfo[currentCameraIndex].timer > cameraInfo[currentCameraIndex].waitTime)
                {
                    currentCameraIndex = secondCameraIndex;
                }

                if (cameraInfo[currentCameraIndex].timer > cameraInfo[currentCameraIndex].waitTime)
                {
                    if (cameraInfo[currentCameraIndex].continueMusic == false)
                    {
                        musicHandler.Stop();
                    }
                    cameraInfo[currentCameraIndex].timer = 0;
                    currentCameraIndex++;

                    if (secondEnding == true)
                    {
                        secondCameraIndex++;
                    }

                    if (currentCameraIndex < cameraInfo.Length)
                    {
                        transform.position = cameraInfo[currentCameraIndex].startPostion.position;
                    }                        
                }
            }
            else if (cameraInfo[currentCameraIndex].behavior == CameraBehaviorType.MoveToPosition)
            {
                transform.LookAt(cameraInfo[currentCameraIndex].target);
                transform.position = Vector3.MoveTowards(transform.position, cameraInfo[currentCameraIndex].endPostion.position,
                                                         cameraInfo[currentCameraIndex].speed * Time.deltaTime);

                #region Sound Effects
                if (cameraInfo[currentCameraIndex].EnableSoundFX == true)
                {
                    if (!musicHandler.isPlaying)
                    {
                        musicHandler.PlayOneShot(cameraInfo[currentCameraIndex].SFX);
                        // Fade In
                        if (cameraInfo[currentCameraIndex].fadeIn == true)
                        {
                            print("IN");
                            StopAllCoroutines();
                            StartCoroutine(FadeIn(musicHandler,
                            0.5f, 0, cameraInfo[currentCameraIndex].volume));
                        }
                        // Fade Out
                        if (cameraInfo[currentCameraIndex].fadeOut == true)
                        {
                            StartCoroutine(FadeOut(musicHandler,
                            2f, cameraInfo[currentCameraIndex].volume, 0, cameraInfo[currentCameraIndex].waitTime - 2f));
                        }
                    }
                }

                // Fade Out Long
                if (cameraInfo[currentCameraIndex].timer > (cameraInfo[currentCameraIndex].waitTime - 2f))
                {
                    if (cameraInfo[currentCameraIndex].continueMusic == false && cameraInfo[currentCameraIndex].fadeOutLong == true)
                    {
                        Debug.Log("MTP");
                        StartCoroutine(FadeOut(musicHandler,
                            2f, cameraInfo[currentCameraIndex].volume, 0, 0));
                        cameraInfo[currentCameraIndex].fadeOutLong = false;
                    }
                }
                #endregion

                //Second Ending
                if (secondEnding == true && cameraInfo[currentCameraIndex].timer > cameraInfo[currentCameraIndex].waitTime)
                {
                    currentCameraIndex = secondCameraIndex;
                }

                if (Vector3.Distance(transform.position, cameraInfo[currentCameraIndex].endPostion.position) < 0.1f || cameraInfo[currentCameraIndex].startTimerNow)
                {
                    cameraInfo[currentCameraIndex].timer += Time.deltaTime;
                    if (cameraInfo[currentCameraIndex].timer > cameraInfo[currentCameraIndex].waitTime)
                    {
                        if (cameraInfo[currentCameraIndex].continueMusic == false)
                        {
                            musicHandler.Stop();
                        }
                        cameraInfo[currentCameraIndex].timer = 0;
                        currentCameraIndex++;

                        if (secondEnding == true)
                        {
                            secondCameraIndex++;
                        }

                        if (currentCameraIndex < cameraInfo.Length)
                        {
                            transform.position = cameraInfo[currentCameraIndex].startPostion.position;
                        }
                    }
                }
            }
            else if (cameraInfo[currentCameraIndex].behavior == CameraBehaviorType.RotateAround)
            {
                transform.RotateAround(cameraInfo[currentCameraIndex].target.position, new Vector3(0,1,0), cameraInfo[currentCameraIndex].speed * Time.deltaTime);
                transform.LookAt(cameraInfo[currentCameraIndex].target);
                cameraInfo[currentCameraIndex].timer += Time.deltaTime;

                #region Sound Effects
                if (cameraInfo[currentCameraIndex].EnableSoundFX == true)
                {
                    if (!musicHandler.isPlaying)
                    {
                        musicHandler.PlayOneShot(cameraInfo[currentCameraIndex].SFX);
                        // Fade In
                        if (cameraInfo[currentCameraIndex].fadeIn == true)
                        {
                            print("IN");
                            StopAllCoroutines();
                            StartCoroutine(FadeIn(musicHandler,
                            0.5f, 0, cameraInfo[currentCameraIndex].volume));
                        }
                        // Fade Out
                        if (cameraInfo[currentCameraIndex].fadeOut == true)
                        {
                            StartCoroutine(FadeOut(musicHandler,
                            2f, cameraInfo[currentCameraIndex].volume, 0, cameraInfo[currentCameraIndex].waitTime - 2f));
                        }
                    }
                }

                // Fade Out Long
                if (cameraInfo[currentCameraIndex].timer > (cameraInfo[currentCameraIndex].waitTime - 2f))
                {
                    if (cameraInfo[currentCameraIndex].continueMusic == false && cameraInfo[currentCameraIndex].fadeOutLong == true)
                    {
                        Debug.Log("RA");
                        StartCoroutine(FadeOut(musicHandler,
                            2f, cameraInfo[currentCameraIndex].volume, 0, 0));
                        cameraInfo[currentCameraIndex].fadeOutLong = false;
                    }
                }
                #endregion

                //Second Ending
                if (secondEnding == true && cameraInfo[currentCameraIndex].timer > cameraInfo[currentCameraIndex].waitTime)
                {
                    currentCameraIndex = secondCameraIndex;
                }

                if (cameraInfo[currentCameraIndex].timer > cameraInfo[currentCameraIndex].waitTime)
                {
                    if (cameraInfo[currentCameraIndex].continueMusic == false)
                    {
                        musicHandler.Stop();
                    }
                    cameraInfo[currentCameraIndex].timer = 0;
                    currentCameraIndex++;

                    if (secondEnding == true)
                    {
                        secondCameraIndex++;
                    }

                    if (currentCameraIndex < cameraInfo.Length)
                    {
                        transform.position = cameraInfo[currentCameraIndex].startPostion.position;
                    }
                }
            }
        }

        IEnumerator FadeIn(AudioSource audioSource, float duration, float start, float targetVolume)
        {
            float currentTime = 0;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            yield break;
        }
        
        IEnumerator FadeOut(AudioSource audioSource, float duration, float start, float targetVolume, float timeRemaining)
        {
            yield return new WaitForSeconds(timeRemaining);
            float currentTime = 0;
            print("CORStart");
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            print("COREnd");
            yield break;
        }
    }
}
