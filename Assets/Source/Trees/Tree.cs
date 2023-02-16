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

        [SerializeField] private float _minScaleFactor;
        [SerializeField] private float _maxScaleFactor;

        public bool IsInfected { get => _isInfected; private set => _isInfected = value; }

        private void Awake()
        {
            _selfObject = this.gameObject;
            _isInfected = false;
        }

        public void Init(Vector3 pos)
        {
            _selfObject.transform.position = pos;
            _selfObject.transform.localScale = new Vector3(UnityEngine.Random.Range(_minScaleFactor, _maxScaleFactor), 1, 
                                                           UnityEngine.Random.Range(_minScaleFactor, _maxScaleFactor));

            _selfObject.transform.Rotate(new Vector3(0, UnityEngine.Random.Range(0, 360), 0));
        }

        public void InitInfectedTree()
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