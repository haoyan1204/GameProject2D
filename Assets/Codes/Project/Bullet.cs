using System;
using UnityEngine;

namespace PlatformShoot
{
    public class Buliet : MonoBehaviour
    {
        private float _vailidTime = 2f;

        private void Start()
        {
            GameObject.Destroy(this.gameObject, _vailidTime);
        }

        private void Update()
        {
            transform.Translate(12 * Time.deltaTime, 0, 0);
        }
    }
}