using DG.Tweening;
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

        private bool _tapped;

        private string _tempTapString;

        [SerializeField] private TextMeshProUGUI _tapTypeText;

        [SerializeField] private GameObject _playerObject;

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

                if (Main.Instance.GameOver)
                    return;

                if (Main.Instance.Victory)
                    return;

                UpdateTapType();
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (Main.Instance.GameOver)
                    return;

                if (Main.Instance.Victory)
                    return;

                _tapped = false;
                _tapTypeText.text = "";

                UpdateTapType();

                ShootButtonClickEvent?.Invoke(_tapType);
            }
        }

        private void UpdateTapType()
        {
            float holdDownTime = Time.time - _holdDownStartTime;

            if (holdDownTime <= 1f)
            {
                _tapType = 0;
                _tempTapString = "Tap";
            }

            if (holdDownTime > 1 && holdDownTime <= 2)
            {
                _tapType = 1;
                _tempTapString = "Short tap";
            }

            if (holdDownTime > 2 && holdDownTime <= 5)
            {
                _tapType = 2;
                _tempTapString = "Long tap";
            }

            if (holdDownTime > 5)
            {
                _tapType = 5;
                _tempTapString = "Extra Long tap";
            }

            _tapTypeText.text = _tempTapString;
        }
    }
}