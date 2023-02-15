using Balthazariy.TreeDestroyer.Controllers;
using Balthazariy.TreeDestroyer.UI;
using UnityEngine;

namespace Balthazariy.TreeDestroyer
{
    public class Main : MonoBehaviour
    {
        public static Main Instance { get; private set; }

        [HideInInspector] public InputController InputController { get; private set; }

        [SerializeField] private MainPage _mainPage;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                Debug.Log("<color=#47EB92>==== MAIN INSTANCE INITED ====</color>");
            }
        }

        private void Start()
        {
            InputController = new InputController(_mainPage);

        }

        private void OnDestroy()
        {
            InputController.Dispose();
        }
    }
}