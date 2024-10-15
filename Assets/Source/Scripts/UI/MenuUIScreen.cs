using GameAnalyticsSDK;
using Kuhpik;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIScreen : UIScreen
{
    [BoxGroup("LINKS")] [SerializeField] 
    private Button _play;
    [BoxGroup("LINKS")] [SerializeField] 
    private Counter _counter;

    public override void Subscribe()
    {
        _play.onClick.AddListener(OnButtonPlayClick);
        base.Subscribe();
    }

    public override void Open()
    {
        _counter.SetValue(Bootstrap.Instance.PlayerData.GameId);
        base.Open();
    }

    private void OnButtonPlayClick()
    {
        GameAnalytics.NewDesignEvent("Level started:" + Bootstrap.Instance.PlayerData.LevelId);
        GameAnalytics.NewDesignEvent("Match started:" + Bootstrap.Instance.PlayerData.GameId);
        Bootstrap.Instance.ChangeGameState(GameStateID.Game);
    }
}
