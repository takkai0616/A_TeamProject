using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
     private Transform target; //�I�u�W�F�N�g�w��
    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.position;�@//�w��̃I�u�W�F�N�g�ʒu�Ɉړ�
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
