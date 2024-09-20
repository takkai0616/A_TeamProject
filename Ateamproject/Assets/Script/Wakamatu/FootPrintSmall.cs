using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintSmall : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField]
    private float x;
    [SerializeField]
    private float y;
    [SerializeField]
    private float z;
    public GameObject footPrintPrefab;
    bool create;
    void Start()
    {
        create = true;
    }
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(x, y, z);
        if (player.isRotate && create)
        {
            Instantiate(footPrintPrefab, transform.position, transform.rotation);
            create = false;
        }
        if (!player.isRotate)
        {
            create = true;
        }
    }
}
