using QFramework;
using UnityEngine;

namespace PlatformShoot
{
    public class Bullet : MonoBehaviour, IController
    {
        private float _validTime = 3f;
        private LayerMask _mLayerMask;
        private int _bulletDir;

        private void Start()
        {
            Destroy(gameObject, _validTime);
            _mLayerMask = LayerMask.GetMask("Ground", "Trigger");
        }

        public void InitDir(int dir)
        {
            _bulletDir = dir;
        }

        private void Update()
        {
            transform.Translate(_bulletDir * 12 * Time.deltaTime, 0, 0);
        }

        private void FixedUpdate()
        {
            var coll = Physics2D.OverlapBox(transform.position, transform.localScale, 0, _mLayerMask);
            if (coll)
            {
                if (coll.CompareTag("Trigger"))
                {
                    Destroy(coll.gameObject);
                    this.SendCommand<ShowPassDoorCommand>();
                }
                Destroy(gameObject);
            }
        }

        public IArchitecture GetArchitecture()
        {
            return PlatformShootGame.Interface;
        }
    }
}