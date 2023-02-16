using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balthazariy.TreeDestroyer.Player
{
    public class Bullet : MonoBehaviour
    {
        public event Action<bool, Vector3> DestroyBulletEvent;

        private GameObject _selfObject;
        private GameObject _finishObject;

        private Vector3 _moveVector;

        private bool _isAlive;

        [SerializeField] private float _speed;

        public void Init(GameObject finishObject)
        {
            _selfObject = this.gameObject;

            _finishObject = finishObject;

            _moveVector = new Vector3(0.5f, 0, 0.5f); // move object diagonaly

            _isAlive = true;
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
                Debug.Log("<color=#9EF20F>==== BULLET DESTROYED BY FINISH ====</color>");
                // start move player to finish
                DestroyBulletEvent?.Invoke(false, _selfObject.transform.position);
                Dispose();
            }
            else if (other.name == "Tree(Clone)")
            {
                Debug.Log("<color=#9EF20F>==== BULLET DESTROYED BY TREE ====</color>");
                DestroyBulletEvent?.Invoke(true, _selfObject.transform.position);
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