using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_SE : MonoBehaviour
{
    [SerializeField] Player player; //�v���C���[�w��

    [SerializeField] AudioSource audioSource;
    private bool IsSound; //����
    void Start()
    {
        IsSound = false;
    }
    void Update()
    {
        if (player.isRotate && !IsSound)//��]���ɐ���
        {
            IsSound = true;
        }
        if (!player.isRotate && IsSound)
        {
            SEManager.instance.BigBoxRolltSEPlaying(audioSource);
            IsSound = false;
        }
    }
}
