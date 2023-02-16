using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

namespace Balthazariy.TreeDestroyer.UI
{
    public class MainPage : MonoBehaviour
    {
        public event Action<byte> ShootButtonClickEvent; // 0 is short tap || 1 is long tap

        private float _holdDownStartTime;

        private byte _tapType;

        [SerializeField] private TextMeshProUGUI _tapTypeText;

        private bool _tapped;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _holdDownStartTime = Time.time;
                _tapped = true;
            }

            if (Input.GetMouseButton(0))
            {
                if (!_tapped) 
                    return;

                float holdDownTime = Time.time - _holdDownStartTime;
                string text = "";

                if (holdDownTime <= 1f)
                    text = "Tap";

                if (holdDownTime > 1 && holdDownTime <= 2)
                    text = "Short tap";

                if (holdDownTime > 2)
                    text = "Long tap";

                _tapTypeText.text = text;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _tapped = false;
                _tapTypeText.text = "";
                Debug.Log("<color=#F20F6B>==== SHOOT BUTTON CLICKED ====</color>");
                float holdDownTime = Time.time - _holdDownStartTime;

                if (holdDownTime <= 1f)
                    _tapType = 0;

                if (holdDownTime > 1 && holdDownTime <= 2)
                    _tapType = 1;

                if (holdDownTime > 2)
                    _tapType = 2;

                ShootButtonClickEvent?.Invoke(_tapType);
            }
        }
    }
}