using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("ƒeƒXƒg"), SerializeField] AudioClip testClip;

    public static SoundManager instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TestSE(AudioSource _audioSource)
    {
        _audioSource.Stop();
        _audioSource.clip = testClip;
        _audioSource.Play();
    }
}
