using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{

    [SerializeField]
    private float x; //X座標指定
    [SerializeField]
    private float y; //Y座標指定
    [SerializeField]
    private float z; //Z座標指定

    public bool IsCasted = false;
    private void OnTriggerStay(Collider col) //接触中判定
    {
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "PlayerBig")
        {
            IsCasted = true;
        }
    }
    private void OnTriggerExit(Collider col) //離れたとき判定
    {
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "PlayerBig")
        {
            IsCasted = false;
        }
    }
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(x, y, z); //回転固定
    }
}
