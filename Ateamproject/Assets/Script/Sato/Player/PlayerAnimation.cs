using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerAnimationEvent playerAnimationEvent;
    
    public void PlayMotion()
    {
        if (playerAnimationEvent.IsMotion) return;
        playerAnimationEvent.IsMotion = true;
        animator.SetTrigger("OnMotion");
    }  
}
