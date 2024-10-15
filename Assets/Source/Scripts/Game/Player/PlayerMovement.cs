using Kuhpik;
using NaughtyAttributes;
using UnityEngine;

namespace PocketSnake
{
    public class PlayerMovement : MonoBehaviour
    {
        [BoxGroup("SETTINGS")] [SerializeField]
        private float _speed;
        [BoxGroup("SETTINGS")] [SerializeField]
        private float _sidesSpeed;

        [BoxGroup("SIDES")] [SerializeField]
        private float _sidePos;
        
        [BoxGroup("SPEED")]
        public float SpeedsMultiplier;
        [BoxGroup("SPEED")] [SerializeField]
        private float _finishingSpeedMultiplier;

        private void Start()
        {
            _sidesSpeed = 0.2f;
            
            Bootstrap.Instance.GameData.OnUpgrade += UpdateSpeed;
            UpdateSpeed();
        }

        private void UpdateSpeed()
        {
            SpeedsMultiplier = Bootstrap.Instance.GameData.Speed;
        }
        
        private void Update()
        {
            if (Bootstrap.Instance.GetCurrentGamestateID() != GameStateID.Game) return;
            
            if (Input.GetMouseButton(0))
            {
                var clampedPos = Mathf.Clamp(transform.position.z + -Input.GetAxis("Mouse X") * _sidesSpeed * SpeedsMultiplier, -_sidePos, _sidePos);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, clampedPos), 1f);
            }
            
            transform.Translate(Vector3.right * _speed * SpeedsMultiplier * Time.deltaTime);
        }

        public void StartFinishing()
        {
            SpeedsMultiplier = _finishingSpeedMultiplier;
        }

        public float GetFramesToFinishCount(Transform platform)
        {
            var distance = Vector3.Distance(transform.position, platform.position);
            return distance / (_speed * _finishingSpeedMultiplier * Time.fixedDeltaTime);
        }
    }
}
