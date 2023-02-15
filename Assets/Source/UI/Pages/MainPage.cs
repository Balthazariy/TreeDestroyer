using System;
using UnityEngine;
using UnityEngine.UI;

namespace Balthazariy.TreeDestroyer.UI
{
    public class MainPage : MonoBehaviour
    {
        [SerializeField] private Button _shootButton;

        public event Action ShootButtonClickEvent;

        private void OnEnable()
        {
            _shootButton.onClick.AddListener(ShootButtonOnClickHandler);
        }

        private void OnDisable()
        {
            _shootButton.onClick.RemoveListener(ShootButtonOnClickHandler);
        }

        private void ShootButtonOnClickHandler()
        {
            Debug.Log("<color=#F20F6B>==== SHOOT BUTTON CLICKED ====</color>");
            ShootButtonClickEvent?.Invoke();
        }
    }
}