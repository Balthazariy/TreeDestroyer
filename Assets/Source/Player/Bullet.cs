using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balthazariy.TreeDestroyer.Player
{
    public class Bullet : MonoBehaviour
    {
        public event Action<bool, Vector3, float> DestroyBulletEvent;

        private GameObject _selfObject;
        private GameObject _finishObject;

        private Vector3 _moveVector;

        private bool _isAlive;

        private float _scaleFactor;

        [SerializeField] private float _speed;
        [SerializeField] private GameObject _modelObject;

        public void Init(GameObject finishObject)
        {
            _selfObject = this.gameObject;

            _finishObject = finishObject;

            _moveVector = new Vector3(0.5f, 0, 0.5f); // move object diagonaly

            _isAlive = true;
        }

        public void UpdateScale(float scaleFactor)
        {
            _scaleFactor = scaleFactor;
            transform.localScale += new Vector3(_scaleFactor, _scaleFactor, _scaleFactor);
        }

        private void FixedUpdate()
        {
            if (_isAlive)
            {
                _selfObject.transform.Translate(_moveVector * _speed * Time.deltaTime);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == _finishObject)
            {
                DestroyBulletEvent?.Invoke(false, _selfObject.transform.position, _scaleFactor);
                Dispose();
            }
            else if (other.name == "Tree(Clone)")
            {
                DestroyBulletEvent?.Invoke(true, _selfObject.transform.position, _scaleFactor);
                Dispose();
            }

        }

        private void Dispose()
        {
            _isAlive = false;
            Destroy(this.gameObject);
        }
    }
}