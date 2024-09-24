using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("ëÂî†âÒì]"), SerializeField] AudioClip bigBoxRollSE;
    [Header("è¨î†âÒì]"), SerializeField] AudioClip smallBoxRollSE;
    [Header("è¨î†âÒì]2"), SerializeField] AudioClip smallBoxRollSE2;
    [Header("è¨î†Ç™Ç¬Ç‘Ç≥ÇÍÇΩÇ∆Ç´"), SerializeField] AudioClip finishSE;
    [Header("ÉäÉUÉãÉgÉ{É^ÉìÇ™âüÇ≥ÇÍÇΩ"), SerializeField] AudioClip resultButtonSE;

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

    public void BigBoxRolltSEPlaying(AudioSource _audioSource)
    {
        _audioSource.Stop();
        _audioSource.clip = bigBoxRollSE;
        _audioSource.Play();
    }

    public void SmallBoXSEPlaying(AudioSource _audioSource)
    {
        _audioSource.Stop();
        _audioSource.clip = smallBoxRollSE;
        _audioSource.Play();
    }

    public void SmallBoXSE2Playing(AudioSource _audioSource)
    {
        _audioSource.Stop();
        _audioSource.clip = smallBoxRollSE2;
        _audioSource.Play();
    }

    public void CrachBoxSEPlaying(AudioSource _audioSource)
    {
        _audioSource.Stop();
        _audioSource.clip = finishSE;
        _audioSource.Play();
    }

    public void ResultButtonSEPlaying(AudioSource _audioSource)
    {
        _audioSource.Stop();
        _audioSource.clip = resultButtonSE;
        _audioSource.Play();
    }
}
