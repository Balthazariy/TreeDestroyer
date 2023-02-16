using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Balthazariy.TreeDestroyer.Trees;

namespace Balthazariy.TreeDestroyer.Player
{
    public class TreeChecker : MonoBehaviour
    {
        private List<Trees.Tree> _treeList;

        private GameObject _selfObject;

        private bool _isAlive;
        [SerializeField] private float _countdown = 1f;
        private float _countdownTimer;

        public void Init(Vector3 worldPosition)
        {
            _selfObject = this.gameObject;

            _treeList = new List<Trees.Tree>();

            worldPosition.y = 0;
            _selfObject.transform.position = worldPosition;
        }

        private void Dispose()
        {
            _isAlive = false;
            _treeList.Clear();
            Destroy(_selfObject);
        }

        private void Update()
        {
            if (_isAlive)
            {
                _countdownTimer -= Time.deltaTime;

                if (_countdownTimer <= 0)
                {
                    _countdownTimer = _countdown;
                    Dispose();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var tree = other.GetComponent<Trees.Tree>();
            
            if (tree != null)
                tree.InitInfectedTree();

            _countdownTimer = _countdown;
            _isAlive = true;
        }
    }
}