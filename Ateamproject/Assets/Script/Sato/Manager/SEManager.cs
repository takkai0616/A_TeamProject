using UnityEngine;

public class SEManager : MonoBehaviour
{
    [Header("�唠��]"), SerializeField] AudioClip bigBoxRollSE;
    [Header("������]"), SerializeField] AudioClip smallBoxRollSE;
    [Header("������]2"), SerializeField] AudioClip smallBoxRollSE2;
    [Header("�������Ԃ��ꂽ�Ƃ�"), SerializeField] AudioClip finishSE;
    [Header("���U���g�{�^���������ꂽ"), SerializeField] AudioClip resultButtonSE;
    [Header("�J�[�\���ړ�"), SerializeField] AudioClip cursorSE;
    [Header("�L�����Z��"), SerializeField] AudioClip cancelSE;
    [Header("����{�^��"), SerializeField] AudioClip decisionSE;    

    public static SEManager instance;

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

        DontDestroyOnLoad(gameObject);
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

    public void CursorSEPlaying(AudioSource _audioSource)
    {
        _audioSource.Stop();
        _audioSource.clip = cursorSE;
        _audioSource.Play();
    }

    public void CancelSEPlaying(AudioSource _audioSource)
    {
        _audioSource.Stop();
        _audioSource.clip = cancelSE;
        _audioSource.Play();
    }

    public void DecisionSEPlaying(AudioSource _audioSource)
    {
        _audioSource.Stop();
        _audioSource.clip = decisionSE;
        _audioSource.Play();
    }
}
