using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{

    [SerializeField]
    private float x; //X���W�w��
    [SerializeField]
    private float y; //Y���W�w��
    [SerializeField]
    private float z; //Z���W�w��

    public bool IsCasted = false;
    private void OnTriggerStay(Collider col) //�ڐG������
    {
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "PlayerBig")
        {
            IsCasted = true;
        }
    }
    private void OnTriggerExit(Collider col) //���ꂽ�Ƃ�����
    {
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "PlayerBig")
        {
            IsCasted = false;
        }
    }
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(x, y, z); //��]�Œ�
    }
}
