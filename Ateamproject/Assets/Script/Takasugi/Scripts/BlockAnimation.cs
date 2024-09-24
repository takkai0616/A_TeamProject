using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockAnimation : MonoBehaviour
{
    private bool isBlock = false;//判定があるか否か

    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {

        if (!isBlock) 
        {
            animator.SetBool("On Block", false);
        }

        if (isBlock)
        {
            animator.SetBool("On Block", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isBlock = true;
        }

        if (collision.gameObject.tag == "PlayerBig")
        {
            isBlock = true;
        }
    }
}
