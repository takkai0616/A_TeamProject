using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintManager : MonoBehaviour
{
    private float time;�@//���ԑ���
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    void Update()
    {
        //��b��j��
        time += Time.deltaTime;
        if (time > 1)
        {
            Destroy(gameObject);
        }
    }
}
