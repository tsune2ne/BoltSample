using System;
using UnityEngine;
using UnityEngine.UI;

namespace StateGraphSample
{ 
    public class UIController : MonoBehaviour
    {
        [SerializeField] Image CountDownBack;
        [SerializeField] Text CountDownText3;
        [SerializeField] Text CountDownText2;
        [SerializeField] Text CountDownText1;

        [SerializeField] Image FinishBack;
        [SerializeField] Text FinishWinText;
        [SerializeField] Text FinishLoseText;

        const float CountDownTime = 3f;
        float remainCountDown;
        bool isCountDown;
        Action onCountDownFinished;

        private void Update()
        {
            if (!isCountDown) return;

            remainCountDown = Mathf.Max(0, remainCountDown - Time.deltaTime);

            switch (Math.Ceiling(remainCountDown))
            {
                case 3:
                    CountDownBack.gameObject.SetActive(true);
                    CountDownText3.gameObject.SetActive(true);
                    CountDownText2.gameObject.SetActive(false);
                    CountDownText1.gameObject.SetActive(false);
                    break;
                case 2:
                    CountDownBack.gameObject.SetActive(true);
                    CountDownText3.gameObject.SetActive(false);
                    CountDownText2.gameObject.SetActive(true);
                    CountDownText1.gameObject.SetActive(false);
                    break;
                case 1:
                    CountDownBack.gameObject.SetActive(true);
                    CountDownText3.gameObject.SetActive(false);
                    CountDownText2.gameObject.SetActive(false);
                    CountDownText1.gameObject.SetActive(true);
                    break;
            }

            if (remainCountDown == 0)
            {
                CountDownText3.gameObject.SetActive(false);
                CountDownText2.gameObject.SetActive(false);
                CountDownText1.gameObject.SetActive(false);
                CountDownBack.gameObject.SetActive(false);
                isCountDown = false;
                onCountDownFinished?.Invoke();
            }
        }

        public void StartCountDown(Action onFinish)
        {
            isCountDown = true;
            remainCountDown = CountDownTime;
            onCountDownFinished = onFinish;
        }

        public void StartResult(bool isWin)
        {
            if (isWin)
            {
                FinishBack.gameObject.SetActive(true);
                FinishWinText.gameObject.SetActive(true);
                FinishLoseText.gameObject.SetActive(false);
            }
            else
            {
                FinishBack.gameObject.SetActive(true);
                FinishWinText.gameObject.SetActive(false);
                FinishLoseText.gameObject.SetActive(true);
            }
        }
    }
}