using UnityEngine;

namespace StateGraphSample
{ 
    public class HpGauge : MonoBehaviour
    {
        [SerializeField] GameObject background;
        [SerializeField] GameObject foreground;

        float _rate = 1f;
        public float Rate {
            get { return _rate; } 
            set
            {
                _rate = value;
                UpdateHpGauge();
            }
        }

        RectTransform backRect, foreRect;

        void Start()
        {
            backRect = background.gameObject.GetComponent<RectTransform>();
            foreRect = foreground.gameObject.GetComponent<RectTransform>();
            UpdateHpGauge();
        }

        void UpdateHpGauge()
        {
            foreRect.sizeDelta = new Vector2(backRect.sizeDelta.x * Rate, backRect.sizeDelta.y);
            var temp = foreRect.anchoredPosition;
            temp.x = foreRect.sizeDelta.x / 2;
            foreRect.anchoredPosition = temp;
        }
    }
}