using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Small_SE : MonoBehaviour
{
    [SerializeField] Player player;　//プレイヤー指定
    [SerializeField] AudioSource audioSource;
    private bool IsSound; //生成
    private bool IsChange;
    void Start()
    {
        IsSound = false;
    }
    void Update()
    {
        if (player.isRotate && IsSound && IsChange)//回転時に生成
        {
            SEManager.instance.SmallBoXSEPlaying(audioSource);
            IsSound = false;
            IsChange = false;
            Debug.Log("1");
        }
        if (player.isRotate && IsSound && !IsChange)//回転時に生成
        {
            SEManager.instance.SmallBoXSE2Playing(audioSource);
            IsSound = false;
            IsChange = true;
            Debug.Log("2");
        }
        if (!player.isRotate)
        {
            IsSound = true;
        }
    }
}
