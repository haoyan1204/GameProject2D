using System;
using UnityEngine;

namespace PlatformShoot
{
    public class Bullet : MonoBehaviour
    {
        private float _vailidTime = 2f;
        private LayerMask _mLayerMask;
        private GameObject _mGamePass;

        private void Start()
        {
            GameObject.Destroy(this.gameObject, _vailidTime);
            _mLayerMask = LayerMask.GetMask("Ground", "Trigger");
        }

        public void GetGamePass(GameObject pass)
        {
            _mGamePass = pass;
        }

        private void Update()
        {
            transform.Translate(12 * Time.deltaTime, 0, 0);
        }

        private void FixedUpdate()
        {
            var coll = Physics2D.OverlapBox(transform.position, transform.localScale, 0, _mLayerMask);
            if (coll)
            {
                if (coll.CompareTag("Trigger"))
                {
                    GameObject.Destroy(coll.gameObject);
                    _mGamePass.SetActive(true);
                }
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}