using Helab.Entity.Character;
using Helab.Input;
using Helab.Input.Key;
using Helab.Simply;
using Helab.Time;
using UnityEngine;

namespace Helab.Camera
{
    public class GameplayCamera : AbstractCamera
    {
        public GameplayCameraParam param;
        
        [SerializeField] private float rotateSpeed = 1.0f;
        
        [SerializeField] private float lookAtRotateSpeed = 1.0f;

        private SimpleRotator _rotator;

        public void SetPlayer(CharacterEntity player)
        {
            param.player = player;
            param.followTarget = player.reference.physicalBody.look;
        }

        private void Awake()
        {
            _rotator = GetComponent<SimpleRotator>();
        }

        protected override void UpdateCamera()
        {
            UpdateCameraInput(param.inputSource);
        }

        private void LateUpdate()
        {
            UpdateCameraEyeTarget();
        }

        private void UpdateCameraInput(InputSource inputSource)
        {
            if (inputSource.Vector3Inputs.HasInput(CameraInputKey.RotateDirection))
            {
                CameraRotate(inputSource.Vector3Inputs.GetInput(CameraInputKey.RotateDirection));
            }
            
            if (inputSource.BoolInputs.GetInput(CameraInputKey.LookAt))
            {
                CameraLookAt();
            }
        }

        private void CameraRotate(Vector3 rotateDirection)
        {
            var deltaRotateY = rotateDirection.x * rotateSpeed * AppTime.DeltaTime;
            _rotator.Rotate(new Vector3(0f, deltaRotateY, 0f), 0f);
        }

        private void CameraLookAt()
        {
            var playerViewDir = param.player.basicParam.viewDirection;
            var cameraViewDir = unityCamera.transform.forward;
            playerViewDir.y = cameraViewDir.y = 0f;
            
            var signedAngle = Vector3.SignedAngle(playerViewDir, cameraViewDir, Vector3.up);
            var targetEuler = transform.rotation.eulerAngles + new Vector3(0f, -signedAngle, 0f);
            _rotator.RotateTo(targetEuler, Mathf.Abs(signedAngle / lookAtRotateSpeed));
        }

        private void UpdateCameraEyeTarget()
        {
            if (param.followTarget == null)
            {
                return;
            }
            
            transform.position = param.followTarget.position;
        }
    }
}
