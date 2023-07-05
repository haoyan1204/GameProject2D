using UnityEngine;
using UnityEngine.UI;

namespace PlatformShoot
{
    public class MainPanel : MonoBehaviour
    {
        private Text _mScoreText;

        private void Start()
        {
            _mScoreText = transform.Find("ScoreText").GetComponent<Text>();
        }

        public void UpdateScoreText(int score)
        {
            var temp = int.Parse(_mScoreText.text);
            _mScoreText.text = (temp + score).ToString();
        }
    }
}