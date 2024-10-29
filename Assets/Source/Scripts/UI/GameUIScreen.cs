using Kuhpik;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class GameUIScreen : UIScreen
{
    [BoxGroup("LINKS")] [SerializeField] 
    private Counter _counter;
    [BoxGroup("LINKS")] [SerializeField] 
    private TextMeshProUGUI _gold;

    public override void Open()
    {
        _counter.SetValue(Bootstrap.Instance.PlayerData.GameId);
        
        Bootstrap.Instance.GameData.OnGoldCountChanged += OnGoldCountChanged;
        OnGoldCountChanged();
        
        base.Open();
    }

    public override void Close()
    {
        if(Bootstrap.Instance.GameData == null) return;
        Bootstrap.Instance.GameData.OnGoldCountChanged -= OnGoldCountChanged;
        base.Close();
    }

    private void OnGoldCountChanged()
    {
        _gold.text = Bootstrap.Instance.GameData.Gold.ToString();
    }
}
