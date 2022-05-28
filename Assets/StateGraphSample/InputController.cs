using UnityEngine;

namespace StateGraphSample
{ 
    public class InputController : MonoBehaviour
    {
        [SerializeField] Battler playerBattler;
        [SerializeField] Battler enemyBattler;

        public bool Active;

        private void Update()
        {
            if (!Active) return;

            if (Input.GetKeyDown(KeyCode.A))
            {
                playerBattler.Attack1();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                playerBattler.Attack2();
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                playerBattler.StartGuard();
            }
            else if (Input.GetKeyUp(KeyCode.G))
            {
                playerBattler.EndGuard();
            }

#if DEBUG
            if (Input.GetKeyDown(KeyCode.U))
            {
                enemyBattler.StartGuard();
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                enemyBattler.EndGuard();
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                enemyBattler.Attack1();
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                enemyBattler.Attack2();
            }
#endif
        }

        public void Attack1()
        {
            if (!Active) return;
            playerBattler.Attack1();
        }

        public void Attack2()
        {
            if (!Active) return;
            playerBattler.Attack2();
        }

        public void StartGuard()
        {
            if (!Active) return;
            playerBattler.StartGuard();
        }

        public void EndGuard()
        {
            if (!Active) return;
            playerBattler.EndGuard();
        }
    }
}