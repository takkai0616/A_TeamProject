using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintManager : MonoBehaviour
{
    [SerializeField]
    private float deadline = 1;
    private float time;@//ŽžŠÔ‘ª’è
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    void Update()
    {
        //ˆê•bŒã”j‰ó
        time += Time.deltaTime;
        if (time > deadline)
        {
            Destroy(gameObject);
        }
    }
}
