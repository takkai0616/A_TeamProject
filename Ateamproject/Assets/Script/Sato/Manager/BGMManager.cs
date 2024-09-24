using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void OnStart(AudioClip _audioClip)
    {
        DontDestroyOnLoad(gameObject);

        audioSource.clip = _audioClip;�@//�^�C�g����BGM��ݒ�
        audioSource.Play(); //BGM���Đ�
    }

    public void ReplayBGM(AudioClip _audioClip)
    {
        audioSource.Stop();
        audioSource.clip = _audioClip;�@//BGM��ݒ�
        audioSource.Play(); //BGM���Đ�
    }
    
    public void StopBGM()
    {
        audioSource.Stop();
    }
}
