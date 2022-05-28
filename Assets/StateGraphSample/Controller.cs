using UnityEngine;
using Utils;

namespace StateGraphSample
{
    public class Controller : SingletonMonoBehaviour<Controller>
    {
        enum State
        {
            Ready,
            Battle,
            Finish,
        }

        [SerializeField] UIController uiController;
        [SerializeField] InputController inputController;
        [SerializeField] EffectController effectController;
        [SerializeField] Battler playerBattler, enemyBattler;

        public UIController UIController { get { return uiController; } }

        public InputController InputController { get { return inputController; } }

        public EffectController EffectController { get { return effectController; } }

        State nowState;

        private void Start()
        {
            nowState = State.Ready;
            uiController.StartCountDown(ChangeToBattle);
            inputController.Active = false;
        }

        void ChangeToBattle()
        {
            nowState = State.Battle;
            playerBattler.OnDead = () => { ChangeToFinish(false); };
            enemyBattler.OnDead = () => { ChangeToFinish(true); };
            inputController.Active = true;
        }

        public void ChangeToFinish(bool isWin)
        {
            nowState = State.Finish;
            uiController.StartResult(isWin);
            inputController.Active = false;
        }
    }
}
