using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balthazariy.TreeDestroyer.UI
{
    public class GameOverPage : MonoBehaviour
    {
        private GameObject _selfObject;

        private void Start()
        {
            _selfObject = this.gameObject;
            _selfObject.SetActive(false);
        }

        public void Show()
        {
            _selfObject.SetActive(true);
        }
    }
}