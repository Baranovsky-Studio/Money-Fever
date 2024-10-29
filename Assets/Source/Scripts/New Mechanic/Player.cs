using System;
using Kuhpik;
using NaughtyAttributes;
using UnityEngine;

public class Player : MonoBehaviour
{
    [BoxGroup("LINKS")] [SerializeField] 
    private Animator _animator;
    [BoxGroup("LINKS")] [SerializeField]
    private Cart _cart;
    [BoxGroup("LINKS")] [SerializeField] 
    private AudioSource _audioSource;

    [BoxGroup("MOVEMENT")] [SerializeField]
    private float _speed;
    [BoxGroup("MOVEMENT")] [SerializeField]
    private float _sidesSpeed;
    [BoxGroup("MOVEMENT")] [SerializeField]
    private float _sidePos;

    private void Start()
    {
        _cart.OnValueChanged += OnGoldCountChanged;
    }

    private void OnEnable()
    {
        Bootstrap.Instance.StateEnterEvent += OnGameStateChanged;
    }

    private void OnDisable()
    {
        Bootstrap.Instance.StateEnterEvent -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameStateID gameStateID)
    {
        if (gameStateID == GameStateID.Game)
        {
            _animator.SetBool("Is Running", true);
        }
        else
        {
            _animator.SetBool("Is Running", false);
        }
    }

    private void Update()
    {
       if (Bootstrap.Instance.GetCurrentGamestateID() != GameStateID.Game) return;

       if (Input.GetMouseButton(0))
       {
           var clampedPos = Mathf.Clamp(transform.position.z + -Input.GetAxis("Mouse X") * _sidesSpeed * _speed,
               -_sidePos, _sidePos);
           transform.position = Vector3.MoveTowards(transform.position,
               new Vector3(transform.position.x, transform.position.y, clampedPos), 1f);
       }

       transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnGoldCountChanged(int goldCount)
    {
        _speed = 14f + goldCount / 12f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            _speed *= 1.4f;
        }

        if (other.CompareTag("Finish Platform"))
        {
            var platform = other.gameObject.GetComponent<FinishPlatformNew>();
            if (_cart.GoldCount >= platform.GoldCount)
            {
                platform.OnReached();
            }
            else
            {
                _speed = 0f;
                _animator.SetBool("Is Running", false);
                _animator.SetTrigger("Finished");
                _cart.OnFinished();
                _audioSource.Play();
                Bootstrap.Instance.ChangeGameState(GameStateID.Win);
            }
        }
    }
}
