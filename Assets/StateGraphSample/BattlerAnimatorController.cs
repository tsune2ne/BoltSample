using System;
using System.Threading.Tasks;
using UnityEngine;

public class BattlerAnimatorController : MonoBehaviour
{
    const string AnimatorParameterAttack1Trigger = "Attack1Trigger";
    const string AnimatorParameterAttack2Trigger = "Attack2Trigger";
    const string AnimatorParameterIsGuard = "isGuard";
    const string AnimatorParameterDamageTrigger = "DamageTrigger";
    const string AnimatorParameterIsDead = "isDead";

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAttack1(Action onHited, Action onFinished)
    {
        animator.SetTrigger(AnimatorParameterAttack1Trigger);
        DelayAction(200, onHited);
        DelayAction(700, onFinished);
    }

    public void StartAttack2(Action onHited, Action onFinished)
    {
        animator.SetTrigger(AnimatorParameterAttack2Trigger);
        DelayAction(1500, onHited);
        DelayAction(2000, onFinished);
    }

    public void StartDamage(Action onFinished)
    {
        animator.SetTrigger(AnimatorParameterDamageTrigger);
        DelayAction(500, onFinished);
    }

    public void StartDead(Action onFinished)
    {
        animator.SetBool(AnimatorParameterIsDead, true);
        DelayAction(5000, onFinished);
    }

    public void StartGuard()
    {
        animator.SetBool(AnimatorParameterIsGuard, true);
    }

    public void StopGuard()
    {
        animator.SetBool(AnimatorParameterIsGuard, false);
    }

    async void DelayAction(int waitMiliSeconds, Action onFinished)
    {
        await Task.Delay(waitMiliSeconds);
        onFinished?.Invoke();
    }

}
