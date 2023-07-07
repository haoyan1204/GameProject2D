using QFramework;
using Unity.Mathematics;
using UnityEngine;

namespace PlatformShoot
{
    public class Player : MonoBehaviour, IController
    {
        private Rigidbody2D _mRig;
        private float _mGroundMoveSpeed = 5f;
        private float _mJumpForce = 12f;
        private bool _mJumpInput;
        private int _mFaceDir = 1;

        private void Start()
        {
            _mRig = GetComponent<Rigidbody2D>();
            this.GetSystem<ICameraSystem>().SetTarget(this.transform);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                var bullet = Resources.Load<GameObject>("Item/Bullet");
                bullet = Instantiate(bullet, transform.position, quaternion.identity);
                bullet.GetComponent<Bullet>().InitDir(_mFaceDir);
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

        private void LateUpdate()
        {
            this.GetSystem<ICameraSystem>().Update();
        }

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.CompareTag("Reword"))
            {
                Destroy(coll.gameObject);
                this.GetModel<IGameModel>().Score.Value++;
            }

            if (coll.gameObject.CompareTag("Door"))
            {
                this.SendCommand(new NextLevelCommand("GamePassScene"));
            }
        }

        public IArchitecture GetArchitecture()
        {
            return PlatformShootGame.Interface;
        }
    }
}