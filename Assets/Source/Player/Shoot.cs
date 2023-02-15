using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balthazariy.TreeDestroyer.Player
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject _finishObject;
        [SerializeField] private GameObject _bulletPrefabObject;

        [SerializeField] private Transform _bulletParent;
        [SerializeField] private Transform _shootPivot;

        private Bullet _currentBullet;

        private bool _canShoot;
        private float _cooldown = 0.5f;

        private void Start()
        {
            Main.Instance.InputController.ScreenTouchEvent += OnScreenTouchEventHandler;
        }

        private void OnDisable()
        {
            Main.Instance.InputController.ScreenTouchEvent -= OnScreenTouchEventHandler;
        }

        private void OnScreenTouchEventHandler()
        {
            Debug.Log("<color=#0E72E8>==== SHOOTED ====</color>");

            InitShoot();
        }

        private void InitShoot()
        {
            _currentBullet = Instantiate(_bulletPrefabObject).GetComponent<Bullet>();

            _currentBullet.Init(_finishObject, _bulletParent);
        }
    }
}