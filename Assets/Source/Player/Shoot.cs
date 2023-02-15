using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balthazariy.TreeDestroyer.Player
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject _finishObject;
        [SerializeField] private GameObject _bulletPrefabObject;


        private void Update()
        {
            if (Input.touchCount > 0)
                Debug.Log(Input.GetTouch(0));
        }

        private void OnScreenTouchEventHandler()
        {

        }
    }
}