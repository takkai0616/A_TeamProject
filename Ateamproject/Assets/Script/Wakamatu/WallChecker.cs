using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChecker : MonoBehaviour
{

    [SerializeField]
    private float x;
    [SerializeField]
    private float y;
    [SerializeField]
    private float z;

    public bool IsCasted = false;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Wall")
        {
            IsCasted = true;
        }
        if (col.gameObject.tag == "PlayerBig")
        {
            IsCasted = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Wall")
        {
            IsCasted = false;
        }
        if (col.gameObject.tag == "PlayerBig")
        {
            IsCasted = false;
        }
    }
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(x, y, z);
    }
}
