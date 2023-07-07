using QFramework;
using UnityEngine;
using UnityEngine.UI;

namespace PlatformShoot
{
    public class MainPanel : MonoBehaviour, IController
    {
        private Text _mScoreText;

        private void Start()
        {
            _mScoreText = transform.Find("ScoreText").GetComponent<Text>();
            this.GetModel<IGameModel>().Score.RegisterWithInitValue(OnScoreChanged)
                .UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnScoreChanged(int score)
        {
            _mScoreText.text = score.ToString();
        }

        public IArchitecture GetArchitecture()
        {
            return PlatformShootGame.Interface;
        }
    }
}