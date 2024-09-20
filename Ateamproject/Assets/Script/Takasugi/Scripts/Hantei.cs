using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hantei : MonoBehaviour
{


    float hanntei = 0;//判定があるか否か

    float anime = 0;//アニメーション起動フラグ

    float OFF = 0;//リセットのアレ

    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {

        if (hanntei == 0) ;
        {
            anime = 0;
        }

        if (hanntei == 1) ;
        {
            anime = 1;
        }

        if (anime == 1)
        {


        }

        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player"||"PlayerBig")
        {

            hanntei = 1;

        }

    }
}
