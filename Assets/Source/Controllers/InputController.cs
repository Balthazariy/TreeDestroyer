using Balthazariy.TreeDestroyer.UI;
using System;

namespace Balthazariy.TreeDestroyer.Controllers
{
    public class InputController
    {
        public event Action ScreenTouchEvent;

        private MainPage _mainPage;

        private bool _isEndedGame;

        public bool IsEndedGame { get => _isEndedGame; set => _isEndedGame = value; }

        public InputController(MainPage mainPage)
        {
            _mainPage = mainPage;
            IsEndedGame = false;
            _mainPage.ShootButtonClickEvent += ShootButtonClickEventHandler;
        }

        public void Dispose()
        {
            _mainPage.ShootButtonClickEvent -= ShootButtonClickEventHandler;
        }

        private void ShootButtonClickEventHandler()
        {
            if (!IsEndedGame)
                ScreenTouchEvent?.Invoke();
        }
    }
}