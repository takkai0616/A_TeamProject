using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hantei : MonoBehaviour
{
    bool OnBlock = false;//判定があるか否か

    float anime = 0;//アニメーション起動フラグ

    float OFF = 0;//リセットのアレ

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
 
    // Update is called once per frame
    void Update()
    {

        if (OnBlock == false) ;
        {
            animator.SetBool("On Block", false);
        }

        if (OnBlock == true) ;
        {
            animator.SetBool("On Block", true);
        }

        if (anime == 1)
        {


        }

        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            OnBlock = true;

        }

        if (collision.gameObject.tag == "PlayerBig")
        {

            OnBlock = true;

        }
    }
}
