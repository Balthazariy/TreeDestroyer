using Balthazariy.TreeDestroyer.UI;
using System;

namespace Balthazariy.TreeDestroyer.Controllers
{
    public class InputController
    {
        public event Action ScreenTouchEvent;

        private MainPage _mainPage;

        public InputController(MainPage mainPage)
        {
            _mainPage = mainPage;

            _mainPage.ShootButtonClickEvent += ShootButtonClickEventHandler;
        }

        public void Dispose()
        {
            _mainPage.ShootButtonClickEvent -= ShootButtonClickEventHandler;
        }

        private void ShootButtonClickEventHandler()
        {
            ScreenTouchEvent?.Invoke();
        }
    }
}