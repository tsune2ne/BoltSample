using Bolt;
using System;
using UnityEngine;

namespace StateGraphSample
{ 
    public class Battler : MonoBehaviour
    {
        const int MaxHp = 10;

        public enum AttackType : int
        {
            Attack1 = 1,
            Attack2 = 2,
        }

        [SerializeField] Battler targetBattler;
        [SerializeField] HpGauge hpGauge;
        [SerializeField] BattlerAnimatorController animatorController;
        [SerializeField] StateMachine aiStateMachine;

        int _hp = MaxHp;
        public int Hp
        {
            get { return _hp; }
            set
            {
                _hp = Mathf.Max(0, value);
                hpGauge.Rate = (float)_hp / MaxHp;
            }
        }

        public Action OnDead;

        bool isDamaging;
        bool isAttacking;

        bool IsDead { get { return Hp == 0; } }
        public bool IsAttackable { get { return !IsGuard && !isDamaging && !IsDead && !isAttacking; } }

        public bool IsGuard { get; private set; } = false;

        public bool IsGuardedAttack1 { get; private set; } = false;

        public void StartAi()
        {
            if (aiStateMachine)
            {
                aiStateMachine.enabled = true;
            }
        }

        public void Hit(AttackType attackType)
        {
            if (IsDead) return;
            // ƒK[ƒh‚µ‚Ä‚½‚çAttack1‚Í–³Œø
            if (attackType == AttackType.Attack1 && IsGuard)
            {
                EffectController.Instance.PlayGuardEffect();
                return;
            }
            if (IsGuard)
            {
                // ƒK[ƒh”j‰ó
                EndGuard();
                EffectController.Instance.PlayGuardBreakEffect();
            }

            EffectController.Instance.PlayHitEffect();

            Hp -= (int)attackType;
            if (!IsDead)
            {
                isDamaging = true;
                animatorController.StartDamage(() =>
                {
                    isDamaging = false;
                });
            }
            else
            {
                animatorController.StartDead(() =>
                {
                    OnDead?.Invoke();
                });
            }
        }

        public void Attack1()
        {
            if (!IsAttackable)
            {
                return;
            }

            isAttacking = true;
            animatorController.StartAttack1(() =>
            {
                targetBattler.Hit(AttackType.Attack1);
            }, () =>
            {
                isAttacking = false;
            });
        }

        public void Attack2()
        {
            if (!IsAttackable)
            {
                return;
            }

            isAttacking = true;
            animatorController.StartAttack2(() =>
            {
                targetBattler.Hit(AttackType.Attack2);
            }, () =>
            {
                isAttacking = false;
            });
        }

        public void StartGuard()
        {
            if (IsGuard || IsDead)
            {
                return;
            }

            IsGuard = true;
            animatorController.StartGuard();
        }

        public void EndGuard()
        {
            if (!IsGuard)
            {
                return;
            }

            IsGuard = false;
            animatorController.StopGuard();
        }
    }
}