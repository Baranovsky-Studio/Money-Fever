using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Cart : MonoBehaviour
{
    [BoxGroup("LINKS")] [SerializeField] 
    private Animator _animator;
    [BoxGroup("LINKS")] [SerializeField] 
    private Transform[] _spawnPoints;
    [BoxGroup("LINKS")] [SerializeField] 
    private GameObject _goldPrefab;

    [BoxGroup("SETTINGS")] [SerializeField]
    private int _startGoldCount;
    [BoxGroup("SETTINGS")] [SerializeField]
    private int _maxGoldCount;

    private List<GameObject> _spawnedGold = new List<GameObject>();
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

    private void Start()
    {
        GoldCount = _startGoldCount;
    }
    
    public void OnUpdateGoldValue()
    {
        UpdateVisibility();
        _animator.SetTrigger("Size");
    }

    private void UpdateVisibility()
    {
        while (_spawnedGold.Count != GoldCount)
        {
            if (_spawnedGold.Count < GoldCount)
            {
                var goldItem = Instantiate(_goldPrefab, _spawnPoints[_lastSpawnPoint].transform.position, _spawnPoints[_lastSpawnPoint].transform.rotation, _spawnPoints[_lastSpawnPoint].transform);
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
                if (_lastSpawnPoint == 0)
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

   
}
