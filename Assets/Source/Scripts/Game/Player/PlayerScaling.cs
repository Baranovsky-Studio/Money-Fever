using System;
using Kuhpik;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using Math = System.Math;

public class PlayerScaling : MonoBehaviour
{
    [BoxGroup("LINKS")] [SerializeField] 
    private Transform _cylinder;
    [BoxGroup("LINKS")] [SerializeField] 
    private TextMeshPro _counter;
    [BoxGroup("LINKS")] [SerializeField] 
    private ParticleSystem _particle;
    [BoxGroup("LINKS")] [SerializeField] 
    private AudioSource _audio;
    [BoxGroup("LINKS")] [SerializeField] 
    private CounterFx _counterFx;

    [BoxGroup("SETTINGS")] [SerializeField]
    private float _scalingSpeed;
    [BoxGroup("SETTINGS")] [SerializeField]
    private float _scaleForDollar;
    [BoxGroup("SETTINGS")] [SerializeField]
    private float _decreaseDollars;

    public float ScalingMultiplier;
    public float Dollars
    {
        get => _dollars;
        set
        {
            _particle.Play();
            _audio.Play();
            _counterFx.ShowCounterFx(value > _dollars, value - _dollars);

            _dollars = Mathf.Clamp(value, 0, Single.MaxValue);

            if (_dollars <= 0)
            {
                Bootstrap.Instance.ChangeGameState(GameStateID.Lose);
            }
        }
    }

    [SerializeField]
    private float _dollars;

    private void Start()
    {
        Bootstrap.Instance.GameData.OnUpgrade += UpdateDollars;
        UpdateDollars();
        UpdateCylinderScale();
        
        _cylinder.localScale = new Vector3(0.4f, 0.4f, 1);
    }

    private void UpdateDollars()
    {
        Dollars = Bootstrap.Instance.GameData.StartDollars;
    }

    private void OnDestroy()
    {
        if (Bootstrap.Instance != null)
        {
            Bootstrap.Instance.GameData.OnUpgrade -= UpdateDollars;
        }
    }

    private void FixedUpdate()
    {
        _counter.text = $"${Math.Round(_dollars, 1, MidpointRounding.AwayFromZero)}";

        if (Bootstrap.Instance.GetCurrentGamestateID() != GameStateID.Game) return;

        DecreaseDollars();
        UpdateCylinderScale();
    }

    private void DecreaseDollars()
    {
        _dollars -= _decreaseDollars * ScalingMultiplier;
        _dollars = Mathf.Clamp(_dollars, 0, Single.MaxValue);
        
        if (_dollars <= 0)
        {
            Bootstrap.Instance.ChangeGameState(GameStateID.Lose);
        }
    }

    private void UpdateCylinderScale()
    {
        var scale = new Vector3(_scaleForDollar * _dollars, _scaleForDollar * _dollars, 1f);
        if (scale.x < 0.2f)
        {
            scale = new Vector3(0.2f, 0.2f, 1f);
        }
        _cylinder.localScale = Vector3.MoveTowards(_cylinder.localScale, scale, _scalingSpeed * Time.fixedDeltaTime);
    }

    public void StartFinishing(float frames)
    {
        var decreasingFrames = _dollars / _decreaseDollars;
        var multiplier = decreasingFrames / frames;
        
        ScalingMultiplier = multiplier;
    }

    public void OnFinish()
    {
        _dollars = 0;
    }
}
