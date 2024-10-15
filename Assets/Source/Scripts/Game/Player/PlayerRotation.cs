using Kuhpik;
using NaughtyAttributes;
using PocketSnake;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [BoxGroup("LINKS")] [SerializeField] 
    private Transform _cylinder;
    [BoxGroup("LINKS")] [SerializeField] 
    private TrailRenderer _trail;
    
    [BoxGroup("SETTINGS")] [SerializeField]
    private float _cylinderSpeed;
    [BoxGroup("SETTINGS")] [SerializeField]
    private float _trailSpeed;

    private PlayerMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    { 
        if (Bootstrap.Instance.GetCurrentGamestateID() != GameStateID.Game) return;

      _cylinder.Rotate(-Vector3.forward * _cylinderSpeed * _movement.SpeedsMultiplier * Time.fixedDeltaTime);
      _trail.sharedMaterial.mainTextureOffset = new Vector2(_trail.sharedMaterial.mainTextureOffset.x - _trailSpeed * _movement.SpeedsMultiplier * Time.deltaTime, 0f);
    }
}
