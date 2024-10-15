using System;
using CAS.AdObject;
using NaughtyAttributes;
using UnityEngine;

public class Advertisement : MonoBehaviour
{
    [BoxGroup("LINKS")] [SerializeField]
    private InterstitialAdObject _interstitial;
    [BoxGroup("LINKS")] [SerializeField]
    private RewardedAdObject _rewarded;

    public Action<int> OnRewardedComplete;
    [ReadOnly]
    public bool IsPlaying;
    [ReadOnly]
    public int RewardedId;

    public static Advertisement Instance;

    private void Awake()
    {
        Instance = this;

        _interstitial.OnAdClosed.AddListener(OnInterstitialClosed);
        _interstitial.OnAdShown.AddListener(OnInterstitialShown);
        _interstitial.OnAdFailedToShow.AddListener(OnInterstitialFailedToShow);
        
        _rewarded.OnAdClosed.AddListener(OnRewardedClosed);
        _rewarded.OnAdShown.AddListener(OnRewardedShown);
        _rewarded.OnAdFailedToShow.AddListener(OnRewardedFailedToShow);
        _rewarded.OnReward.AddListener(OnRewardedReward);
    }

    public void ShowInterstitial()
    {
        IsPlaying = true;
        _interstitial.Present();
    }

    private void OnInterstitialClosed()
    {
        IsPlaying = false;
    }
    
    private void OnInterstitialShown()
    {
        IsPlaying = false;
    }
    
    private void OnInterstitialFailedToShow(string exception)
    {
        IsPlaying = false;
    }

    public void ShowRewarded(int id)
    {
        IsPlaying = true;
        RewardedId = id;
        _rewarded.Present();
    }

    private void OnRewardedClosed()
    {
        IsPlaying = false;
    }

    private void OnRewardedShown()
    {
        IsPlaying = false;
    }
    
    private void OnRewardedFailedToShow(string exception)
    {
        IsPlaying = false;
    }
    
    private void OnRewardedReward()
    {
        IsPlaying = false;
        OnRewardedComplete?.Invoke(RewardedId);
    }
}
