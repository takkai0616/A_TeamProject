using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void OnStart(AudioClip _audioClip)
    {
        DontDestroyOnLoad(gameObject);

        audioSource.clip = _audioClip;　//タイトルのBGMを設定
        audioSource.Play(); //BGMを再生
    }

    public void ReplayBGM(AudioClip _audioClip)
    {
        audioSource.Stop();
        audioSource.clip = _audioClip;　//BGMを設定
        audioSource.Play(); //BGMを再生
    }
    
    public void StopBGM()
    {
        audioSource.Stop();
    }
}
