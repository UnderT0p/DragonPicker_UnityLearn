using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager 
{
    public static Action eventOnScoreUpdate;
    public static void CallonScoreUpdate()
    {
        eventOnScoreUpdate?.Invoke();
    }
    public static Action eventOnHealthUpdate;

    public static void CallonHealthUpdate()
    {
        eventOnHealthUpdate?.Invoke();
    }
    public static Action eventOnWinGame;

    public static void CallonwinGame()
    {
        eventOnWinGame?.Invoke();
    }
    public static Action eventOnSoundChange;

    public static void CallonSoundChange()
    {
        eventOnSoundChange?.Invoke();
    }


}
