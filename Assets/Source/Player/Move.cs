using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Balthazariy.TreeDestroyer.Player
{
    public class Move : MonoBehaviour
    {
        private bool _isMooving;
        private Vector3 _moveVector;

        [SerializeField] private float _speed;

        [SerializeField] private float _moveDecreaseScaleFactor;
        [SerializeField] private GameObject _playerObject;

        private void Start()
        {
            _isMooving = false;
            _moveVector = new Vector3(0.5f, 0, 0.5f);
        }

        public void MovePlayerToFinish()
        {
            _isMooving = true;
            Main.Instance.InputController.IsEndedGame = true;
        }

        private void Update()
        {
            if (_isMooving)
            {
                transform.Translate(_moveVector * _speed * Time.deltaTime);
                _playerObject.transform.localScale -= new Vector3(_moveDecreaseScaleFactor, _moveDecreaseScaleFactor, _moveDecreaseScaleFactor);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            _isMooving = false;

            Main.Instance.VictoryPage.Show();
        }
    }
}