using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject GroundB; // ��������I�u�W�F�N�g�̃v���n�u
    public GameObject GroundW; // ��������I�u�W�F�N�g�̃v���n�u
    public Vector3 AreaMin = new Vector3(0.0f, 0.0f, 0.0f); // �ŏ��l
    public Vector3 AreaMax = new Vector3(12.0f, 0.0f, 12.0f);   // �ő�l
    private int press_count;

    void Update()
    {
        // �X�y�[�X�L�[�������ƐV�����I�u�W�F�N�g�𐶐�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �����_���Ȉʒu���v�Z
            Vector3 randomPosition = new Vector3(
                Random.Range(AreaMin.x, AreaMax.x),
                Random.Range(AreaMin.y, AreaMax.y),
                Random.Range(AreaMin.z, AreaMax.z)
            );

            // Instantiate�֐����g�p���ăI�u�W�F�N�g�𐶐�
            GameObject newObject = Instantiate(GroundB, randomPosition, transform.rotation);
            press_count++; // �X�y�[�X�L�[�������ꂽ�񐔂��J�E���g�A�b�v
            Debug.Log("Space key has been pressed " + press_count + " times.");
            Debug.Log("Random Position: " + randomPosition);
        }
    }
}
