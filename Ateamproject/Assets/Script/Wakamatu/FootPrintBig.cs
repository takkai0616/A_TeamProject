using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintBig : MonoBehaviour
{
    [SerializeField] Player player;　//プレイヤー指定
    [SerializeField]
    public GameObject footPrintPrefab; //アニメーション指定
    private bool IsCreate; //生成
    void Start()
    {
        IsCreate = false;
    }
    void Update()
    {
        if (player.isRotate && !IsCreate)//回転時に生成
        {
            IsCreate = true;
        }
        if (!player.isRotate && IsCreate)
        {
            Instantiate(footPrintPrefab, transform.position, transform.rotation);
            IsCreate = false;
        }
    }
}
