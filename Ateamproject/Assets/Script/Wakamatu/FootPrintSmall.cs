using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintSmall : MonoBehaviour
{
    [SerializeField] Player player;�@//�v���C���[�w��
    [SerializeField]
    public GameObject footPrintPrefab; //�A�j���[�V�����w��
    private bool IsCreate; //����
    void Start()
    {
        IsCreate = true;
    }
    void Update()
    {
        if (player.isRotate && IsCreate)//��]���ɐ���
        {
            Instantiate(footPrintPrefab, transform.position, transform.rotation);
            IsCreate = false;
        }
        if (!player.isRotate)
        {
            IsCreate = true;
        }
    }
}
