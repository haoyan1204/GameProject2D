using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformShoot
{
    public class exit : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
            }
        }
    }
}