using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{

    [SerializeField]
    private float x;
    [SerializeField]
    private float y;
    [SerializeField]
    private float z;

    public bool IsCasted = false;
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "PlayerBig")
        {
            IsCasted = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "PlayerBig")
        {
            IsCasted = false;
        }
    }
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(x, y, z);
    }
}
