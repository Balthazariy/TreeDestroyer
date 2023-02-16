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
        [SerializeField] private VictoryPage _victoryPage;
        [SerializeField] private GameOverPage _gameOverPage;

        private bool _gameOver;
        private bool _victory;

        public VictoryPage VictoryPage { get => _victoryPage; private set => _victoryPage = value; }
        public GameOverPage GameOverPage { get => _gameOverPage; private set => _gameOverPage = value; }

        public bool GameOver { get => _gameOver; set => _gameOver = value; }
        public bool Victory { get => _victory; set => _victory = value; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
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