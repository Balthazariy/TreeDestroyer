using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balthazariy.TreeDestroyer.Player
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject _finishObject;
        [SerializeField] private GameObject _bulletPrefabObject;
        [SerializeField] private GameObject _treeCheckerPrefabObject;

        [SerializeField] private Transform _bulletParent;
        [SerializeField] private Transform _shootPivot;

        [SerializeField] private Move _movePlayer;

        private bool _canShoot;
        private float _cooldown = 0.5f;
        private float _couldownTimer;

        private void Start()
        {
            Main.Instance.InputController.ScreenTouchEvent += OnScreenTouchEventHandler;

            _canShoot = true;
        }

        private void OnDisable()
        {
            Main.Instance.InputController.ScreenTouchEvent -= OnScreenTouchEventHandler;
        }

        private void OnScreenTouchEventHandler()
        {
            Debug.Log("<color=#0E72E8>==== SHOOTED ====</color>");
            DoShoot();
        }

        private void Update()
        {
            if (!_canShoot)
            {
                _couldownTimer -= Time.deltaTime;

                if (_couldownTimer <= 0)
                {
                    _couldownTimer = _cooldown;
                    _canShoot = true;
                }
            }
        }

        private void DoShoot()
        {
            if (_canShoot)
            {
                Bullet currentBullet = Instantiate(_bulletPrefabObject, _bulletParent).GetComponent<Bullet>();
                currentBullet.DestroyBulletEvent += DestroyBulletEventHandler;
                currentBullet.Init(_finishObject);

                _couldownTimer = _cooldown;
                _canShoot = false;
            }
        }

        public void DestroyBulletEventHandler(bool isTree, Vector3 worldPosition)
        {
            if (isTree)
            {
                TreeChecker checker = Instantiate(_treeCheckerPrefabObject, _bulletParent).GetComponent<TreeChecker>();
                checker.Init(worldPosition);
            }
            else
            {
                _movePlayer.MovePlayerToFinish();
            }
        }
    }
}