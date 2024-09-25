using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    private bool isMotion;
    public bool IsMotion { get => isMotion; set => isMotion = value;}

    public void EndMotion()
    {
        IsMotion = false;
    }
}
