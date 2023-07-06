using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlatformShoot
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D _mRig;
        private float _mGroundMoveSpeed = 5f;
        private float _mJumpForce = 12f;
        private bool _mJumpInput;
        private MainPanel _mainPanel;
        private GameObject _mGamePass;
        private int _mFaceDir = 1;

        private void Start()
        {
            _mRig = GetComponent<Rigidbody2D>();
            _mGamePass = GameObject.Find("GamePass");
            _mGamePass.SetActive(false);
            _mainPanel = GameObject.Find("MainPanel").GetComponent<MainPanel>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                var bullet = Resources.Load<GameObject>("Bullet");
                bullet = Instantiate(bullet, transform.position, quaternion.identity);
                bullet.GetComponent<Bullet>().InitDir(_mFaceDir);
                bullet.GetComponent<Bullet>().GetGamePass(_mGamePass);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _mJumpInput = true;
            }
        }

        private void FixedUpdate()
        {
            if (_mJumpInput)
            {
                _mJumpInput = false;
                _mRig.velocity = new Vector2(_mRig.velocity.x, _mJumpForce);
            }

            var faceDir = Input.GetAxisRaw("Horizontal");
            if (faceDir != 0 && faceDir != _mFaceDir)
            {
                _mFaceDir = -_mFaceDir;
                transform.Rotate(0, 180, 0);
            }

            _mRig.velocity = new Vector2(faceDir * _mGroundMoveSpeed, _mRig.velocity.y);
        }

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.CompareTag("Reword"))
            {
                Destroy(coll.gameObject);
                _mainPanel.UpdateScoreText(1);
            }

            if (coll.gameObject.CompareTag("Door"))
            {
                SceneManager.LoadScene("GamePassScene");
            }
        }
    }
}