using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats {

    public event EventHandler OnStatsChanged;

    public static int STAT_MIN = 0;
    public static int STAT_MAX = 80;

    public enum Type {
        Zerokotto,
        Androididzu,
        Napitone,
        Reliaochoki,
        Chatabotto,
        Igrahagi,
        Javascriptu,
    }

    private SingleStat ZerokottoStat;
    private SingleStat AndroididzuStat;
    private SingleStat NapitoneStat;
    private SingleStat ReliaochokiStat;
    private SingleStat ChatabottoStat;
    private SingleStat IgrahagiStat;
    private SingleStat JavascriptuStat;

    public Stats(int ZerokottoStatAmount, int AndroididzuStatAmount, int NapitoneStatAmount, int ReliaochokiStatAmount, int ChatabottoStatAmount, int IgrahagiStatAmount, int JavascriptuStatAmount) {
        ZerokottoStat   = new SingleStat(ZerokottoStatAmount);
        AndroididzuStat = new SingleStat(AndroididzuStatAmount);
        NapitoneStat    = new SingleStat(NapitoneStatAmount);
        ReliaochokiStat = new SingleStat(ReliaochokiStatAmount);
        ChatabottoStat  = new SingleStat(ChatabottoStatAmount);
        IgrahagiStat    = new SingleStat(IgrahagiStatAmount);
        JavascriptuStat = new SingleStat(JavascriptuStatAmount);
    }

    private SingleStat GetSingleStat(Type statType) {
        switch (statType) {
        default:
        case Type.Zerokotto:    return ZerokottoStat;
        case Type.Androididzu:  return AndroididzuStat;
        case Type.Napitone:     return NapitoneStat;
        case Type.Reliaochoki:  return ReliaochokiStat;
        case Type.Chatabotto:   return ChatabottoStat;
        case Type.Igrahagi:     return IgrahagiStat;
        case Type.Javascriptu:  return JavascriptuStat;
        }
    }
    
    public void SetStatAmount(Type statType, int statAmount) {
        GetSingleStat(statType).SetStatAmount(statAmount);
        if (OnStatsChanged != null) OnStatsChanged(this, EventArgs.Empty);
    }

    public void IncreaseStatAmount(Type statType) {
        SetStatAmount(statType, GetStatAmount(statType) + 1);
    }

    public void DecreaseStatAmount(Type statType) {
        SetStatAmount(statType, GetStatAmount(statType) - 1);
    }

    public int GetStatAmount(Type statType) {
        return GetSingleStat(statType).GetStatAmount();
    }

    public float GetStatAmountNormalized(Type statType) {
        return GetSingleStat(statType).GetStatAmountNormalized();
    }



    /*
     * Represents a Single Stat of any Type
     * */
    private class SingleStat {

        private int stat;

        public SingleStat(int statAmount) {
            SetStatAmount(statAmount);
        }

        public void SetStatAmount(int statAmount) {
            stat = Mathf.Clamp(statAmount, STAT_MIN, STAT_MAX);
        }

        public int GetStatAmount() {
            return stat;
        }

        public float GetStatAmountNormalized() {
            return (float)stat / STAT_MAX;
        }
    }
}
