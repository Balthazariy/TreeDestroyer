using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balthazariy.TreeDestroyer.Door
{
    public class OpenDoor : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _winParticles;
        [SerializeField] private Animator _animator;

        private void OnTriggerEnter(Collider other)
        {
            if (other.name != "Bullet(Clone)")
                return;

            _animator.Play("Action", -1, 0);
            
            _winParticles.gameObject.SetActive(true);

            _winParticles.Play();
        }
    }
}