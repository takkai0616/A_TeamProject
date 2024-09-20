using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintSmall : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField]
    public GameObject footPrintPrefab;
    bool create;
    void Start()
    {
        create = true;
    }
    void Update()
    {
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
