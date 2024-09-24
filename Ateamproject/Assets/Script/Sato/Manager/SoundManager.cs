using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("大箱回転"), SerializeField] AudioClip bigBoxRollSE;
    [Header("小箱回転"), SerializeField] AudioClip smallBoxRollSE;
    [Header("小箱回転2"), SerializeField] AudioClip smallBoxRollSE2;
    [Header("小箱がつぶされたとき"), SerializeField] AudioClip finishSE;
    [Header("リザルトボタンが押された"), SerializeField] AudioClip resultButtonSE;

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
