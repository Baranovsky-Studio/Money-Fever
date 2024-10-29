using Kuhpik;
using NaughtyAttributes;
using UnityEngine;

public class PlayerCameraRotation : MonoBehaviour
{
    [BoxGroup("SETTINGS")] [SerializeField] 
    private float _rotationSpeed;
    [BoxGroup("SETTINGS")] [SerializeField] 
    private float _rotationBackSpeed;

    private bool _isRotating = true;
    private bool _stateRight;

    private void Start()
    {
        Bootstrap.Instance.StateEnterEvent += OnStateEnter;
    }

    private void OnStateEnter(GameStateID gameStateID)
    {
        if (gameStateID == GameStateID.Game)
        {
            _isRotating = false;
        }
        else if (gameStateID == GameStateID.Menu)
        {
            _isRotating = true;
        }
    }

    private void Update()
    {
        if (_isRotating)
        {
            if (transform.localEulerAngles.y < 30f && _stateRight)
            {
                _stateRight = false;
            }
            else if (transform.localEulerAngles.y > 135f && !_stateRight)
            {
                _stateRight = true;
            }

            var newLocalEulerAngles = new Vector3(0f, _stateRight ? 10f : 170f, 0f);
            transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, newLocalEulerAngles, _rotationSpeed * Time.deltaTime);
        }
        else
        {
            var newLocalEulerAngles = new Vector3(0f, 90f, 0f);
            transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, newLocalEulerAngles, _rotationBackSpeed * Time.deltaTime);
        }
    }
}
