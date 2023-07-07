using System;
using QFramework;
using UnityEngine.SceneManagement;

namespace PlatformShoot
{
    public class NextLevelCommand : AbstractCommand
    {
        private readonly String mSceneName;

        public NextLevelCommand(String name)
        {
            mSceneName = name;
        }

        protected override void OnExecute()
        {
            SceneManager.LoadScene(mSceneName);
        }
    }
}