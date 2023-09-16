using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AchievementsEarn : MonoBehaviour
{
    public void EarnAchievement(string achievmentName)
    {
        if(PlayerPrefs.GetInt(achievmentName)==0)
        {
            PlayerPrefs.SetInt(achievmentName, 1);
            //play achievement animation
            print("achievement "+achievmentName+" earned");
        }
    }
}
