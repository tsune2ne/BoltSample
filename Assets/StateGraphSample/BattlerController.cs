using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlerController : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("Attack1Trigger");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Attack2Trigger");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.ResetTrigger("DamageTrigger");
            animator.SetTrigger("DamageTrigger");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("isDead", true);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetBool("isGuard", true);
        }
        else if (Input.GetKeyUp(KeyCode.G))
        {
            animator.SetBool("isGuard", false);
        }
    }
}
