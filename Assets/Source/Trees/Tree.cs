using Balthazariy.TreeDestroyer.Player;
using UnityEngine;

namespace Balthazariy.TreeDestroyer.Trees
{
    public class Tree : MonoBehaviour
    {
        private GameObject _selfObject;

        private bool _isInfected;
        private float _countdown = 1f;
        private float _countdownTimer;

        private void Awake()
        {
            _selfObject = this.gameObject;
            _isInfected = false;
        }

        public void Init(Vector3 pos)
        {
            _selfObject.transform.position = pos;
        }

        private void InfectedAreaEventHandler()
        {
            _countdownTimer = _countdown;
            _isInfected = true;
        }

        private void Update()
        {
            if (_isInfected)
            {
                _countdownTimer -= Time.deltaTime;

                if (_countdownTimer <= 0)
                {
                    _countdownTimer = _countdown;
                    Dispose();
                }
            }
        }

        public void Dispose()
        {
            _isInfected = false;
            Destroy(_selfObject);
        }
    }
}