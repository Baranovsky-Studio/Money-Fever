using GameAnalyticsSDK;
using Kuhpik;
using NaughtyAttributes;
using Pocket_Snake;
using UnityEngine;
using UnityEngine.UI;

public class LoseUIScreen : UIScreen
{
    [BoxGroup("LINKS")] [SerializeField] 
    private Button _tryAgain;

    public override void Subscribe()
    {
        _tryAgain.onClick.AddListener(OnButtonTryAgainClick);
        base.Subscribe();
    }

    private void OnButtonTryAgainClick()
    {
        GameAnalytics.NewDesignEvent("Level losed:" + Bootstrap.Instance.PlayerData.LevelId);
        GameAnalytics.NewDesignEvent("Match losed:" + Bootstrap.Instance.PlayerData.GameId);
        
        Bootstrap.Instance.ChangeGameState(GameStateID.Menu);
        Bootstrap.Instance.GetSystem<LoadLevelSystem>().LoadLevel();
       
        Advertisement.Instance.ShowInterstitial();
    }
}
