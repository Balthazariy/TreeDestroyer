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
        [SerializeField] private GameObject _playerObject;

        [SerializeField] private float _tapDecreaseScaleFactor;
        [SerializeField] private float _holdTapDecreaseScaleFactor;

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

        private void OnScreenTouchEventHandler(byte force)
        {
            Debug.Log("<color=#0E72E8>==== SHOOTED ====</color>");
            DoShoot(force);
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

        private void DoShoot(byte force)
        {
            if (_canShoot)
            {
                float scaleFactor = force == 0 ? 0 : (force == 1 ? _tapDecreaseScaleFactor : _holdTapDecreaseScaleFactor);

                    _playerObject.transform.localScale -= new Vector3(scaleFactor, scaleFactor, scaleFactor);

                Bullet currentBullet = Instantiate(_bulletPrefabObject, _bulletParent).GetComponent<Bullet>();
                currentBullet.DestroyBulletEvent += DestroyBulletEventHandler;
                currentBullet.Init(_finishObject);
                currentBullet.UpdateScale(scaleFactor);

                _couldownTimer = _cooldown;
                _canShoot = false;
            }
        }

        public void DestroyBulletEventHandler(bool isTree, Vector3 worldPosition, float scaleFactor)
        {
            if (isTree)
            {
                TreeChecker checker = Instantiate(_treeCheckerPrefabObject, _bulletParent).GetComponent<TreeChecker>();
                checker.Init(worldPosition);
                checker.UpdateScale(scaleFactor);
            }
            else
            {
                _movePlayer.MovePlayerToFinish();
            }
        }
    }
}