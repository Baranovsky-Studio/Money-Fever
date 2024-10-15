using BaranovskyStudio;
using Kuhpik;
using NaughtyAttributes;
using Source.Scripts;
using UnityEngine;

public class LoadUpgradesSystem : GameSystem
{
    [BoxGroup("SETTINGS")] [SerializeField] private UpgradableItem _banknotes;
    [BoxGroup("SETTINGS")] [SerializeField] private UpgradableItem _speed;

    [BoxGroup("SETTINGS")] [SerializeField] private Upgrades _upgrades;
    
    public override void OnInit()
    {
        _banknotes.Initialize();
        _speed.Initialize();
        
        _banknotes.OnUpgradeItem.AddListener(OnUpgrade);
        _speed.OnUpgradeItem.AddListener(OnUpgrade);

        OnUpgrade(0);
        
        base.OnInit();
    }

    private void OnUpgrade(int n)
    {
        game.StartDollars = _upgrades.StartDollars[_banknotes.UpgradeLevel];
        game.Speed = _upgrades.Speed[_speed.UpgradeLevel];
        game.OnUpgrade?.Invoke();
    }
}
