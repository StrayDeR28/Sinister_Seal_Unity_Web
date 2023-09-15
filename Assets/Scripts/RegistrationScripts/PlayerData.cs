using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int id;

    public string firstname;
    public string middlename;
    public string lastname;
    public string email;
    public string nickname;
    
    public int bits;
    public int[] progress;// = new int[28];
    public int hints;
    
    public bool novel1;
    public bool novel2;
    public bool tutorial;

    public ErrorCode error;
    public RankCode title;
}

public enum ErrorCode {none, loginEmailError, loginPassError, signupEmailError, signupNickError}
public enum RankCode {junior, middle, middleEarn, senior, seniorEarn, samurai, samuraiEarn }