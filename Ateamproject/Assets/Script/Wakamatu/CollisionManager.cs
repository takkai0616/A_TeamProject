using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
     private Transform target; //オブジェクト指定
    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.position;　//指定のオブジェクト位置に移動
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
