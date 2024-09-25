using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_SE : MonoBehaviour
{
    [SerializeField] Player player; //プレイヤー指定

    [SerializeField] AudioSource audioSource;
    private bool IsSound; //生成
    void Start()
    {
        IsSound = false;
    }
    void Update()
    {
        if (player.isRotate && !IsSound)//回転時に生成
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
