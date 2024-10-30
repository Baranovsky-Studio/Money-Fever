using System;
using System.Collections.Generic;
using Kuhpik;
using NaughtyAttributes;
using Source.Scripts.New_Mechanic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    [BoxGroup("LINKS")] [SerializeField] 
    private Animator _animator;
    [BoxGroup("LINKS")] [SerializeField] 
    private Transform[] _spawnPoints;
    [BoxGroup("LINKS")] [SerializeField] 
    private GameObject _goldPrefab;
    [BoxGroup("LINKS")] [SerializeField] 
    private AudioSource _audioSource;

    [BoxGroup("AUDIO")] [SerializeField] 
    private AudioClip _stonksUp, _stonksDown;

    [BoxGroup("SETTINGS")] [SerializeField]
    private int _startGoldCount;
    [BoxGroup("SETTINGS")] [SerializeField]
    private int _maxGoldCount;

    private List<Gold> _spawnedGold = new List<Gold>();
    public int GoldCount 
    {
        get
        {
            return _goldCount;
        }
        set
        {
            _goldCount = Mathf.Clamp(value, 0, _maxGoldCount);
            OnUpdateGoldValue();
        }
    }

    [SerializeField] [ReadOnly]
    private int _goldCount;
    
    private int _lastSpawnPoint;
    private int _layer = 1;
    private bool _playSound = false;
    private bool _isUpgrade = true;

    public Action<int> OnValueChanged;

    private void Start()
    {
        GoldCount = _startGoldCount;
        _playSound = true;
    }

    private void OnUpdateGoldValue()
    {
        UpdateVisibility();
        
        if (Bootstrap.Instance.GameData.Gold > GoldCount)
        {
            _animator.SetTrigger("SizeDown");
            if (_playSound)
            {
                _audioSource.PlayOneShot(_stonksDown);
            }
        }
        else
        {
            _animator.SetTrigger("SizeUp");
            if (_playSound)
            {
                _audioSource.PlayOneShot(_stonksUp);
            }
        }

        Bootstrap.Instance.GameData.Gold = GoldCount;
        OnValueChanged?.Invoke(GoldCount);

        if (GoldCount == 0)
        {
            Bootstrap.Instance.ChangeGameState(GameStateID.Lose);
        }
    }

    private void UpdateVisibility()
    {
        while (_spawnedGold.Count != GoldCount)
        {
            if (_spawnedGold.Count < GoldCount)
            {
                var goldItem = Instantiate(_goldPrefab, _spawnPoints[_lastSpawnPoint].transform.position, _spawnPoints[_lastSpawnPoint].transform.rotation, _spawnPoints[_lastSpawnPoint].transform).GetComponent<Gold>();
                goldItem.transform.localPosition = new Vector3(0f, _layer * 0.2f, 0f);
                _spawnedGold.Add(goldItem);

                _lastSpawnPoint++;
                if (_lastSpawnPoint == _spawnPoints.Length)
                {
                    _lastSpawnPoint = 0;
                }

                if (_spawnedGold.Count % 8 == 0)
                {
                    _layer++;
                }
            }
            else if (_spawnedGold.Count > GoldCount)
            {
                Destroy(_spawnedGold[_spawnedGold.Count - 1].gameObject);
                _spawnedGold.RemoveAt(_spawnedGold.Count - 1);

                _lastSpawnPoint--;
                if (_lastSpawnPoint <= 0)
                {
                    _lastSpawnPoint = 7;
                }

                if (_spawnedGold.Count % 8 == 0)
                {
                    _layer--;
                }
            }
        }
    }

    public void OnFinished()
    {
        foreach (var gold in _spawnedGold)
        {
            gold.Throw();   
        }
        gameObject.SetActive(false);
    }
}
