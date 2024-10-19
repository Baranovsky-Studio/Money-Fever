using System;
using NaughtyAttributes;
using UnityEngine;

public class Advertisement : MonoBehaviour
{
    public Action<int> OnRewardedComplete;
    [ReadOnly]
    public bool IsPlaying;
    [ReadOnly]
    public int RewardedId;

    public static Advertisement Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowInterstitial()
    {
        IsPlaying = true;
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
