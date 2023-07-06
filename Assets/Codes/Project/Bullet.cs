using UnityEngine;

namespace PlatformShoot
{
    public class Bullet : MonoBehaviour
    {
        private float _vailidTime = 3f;
        private LayerMask _mLayerMask;
        private GameObject _mGamePass;
        private int _bulletDir;

        private void Start()
        {
            Destroy(gameObject, _vailidTime);
            _mLayerMask = LayerMask.GetMask("Ground", "Trigger");
        }

        public void GetGamePass(GameObject pass)
        {
            _mGamePass = pass;
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
                    _mGamePass.SetActive(true);
                }
                Destroy(gameObject);
            }
        }
    }
}