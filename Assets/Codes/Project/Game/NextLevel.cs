using QFramework;
using UnityEngine;

namespace PlatformShoot
{
    public class NextLevel : MonoBehaviour, IController
    {
        public IArchitecture GetArchitecture()
        {
            return PlatformShootGame.Interface;
        }

        private void Start()
        {
            gameObject.SetActive(false);
            this.RegisterEvent<ShowPassDoorEvent>(OnCanGamePass)
                .UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnCanGamePass(ShowPassDoorEvent @event)
        {
            gameObject.SetActive(true);
        }
    }
}