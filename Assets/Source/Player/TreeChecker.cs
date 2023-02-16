using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balthazariy.TreeDestroyer.Player
{
    public class TreeChecker : MonoBehaviour
    {

        public event Action<List<Tree>> InfectedAreaEvent;
        private List<Tree> _treeList;

        private bool _isAlive;
        private float _countdown = 0.3f;
        private float _countdownTimer;

        public void Init()
        {
            _treeList = new List<Tree>();
        }

        private void Dispose()
        {

        }

        private void Update()
        {
            if (_isAlive)
            {
                _countdownTimer -= Time.deltaTime;

                if (_countdownTimer <= 0)
                {
                    _countdownTimer = _countdown;
                    Debug.Log(_treeList);
                    InfectedAreaEvent?.Invoke(_treeList);
                    Dispose();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            _treeList.Add(other.GetComponent<Tree>());
        }
    }
}