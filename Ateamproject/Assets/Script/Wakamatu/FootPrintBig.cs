using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintBig : MonoBehaviour
{
    [SerializeField] Player player;�@//�v���C���[�w��
    [SerializeField]
    public GameObject footPrintPrefab; //�A�j���[�V�����w��
    private bool IsCreate; //����
    void Start()
    {
        IsCreate = false;
    }
    void Update()
    {
        if (player.isRotate && !IsCreate)//��]���ɐ���
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
