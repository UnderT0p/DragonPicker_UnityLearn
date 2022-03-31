using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ScharedData 
{
    
    private static float score=0;

    public static float Score
    {
        get { return score; }
        set 
        {
            if (value<0)
            {
                score = 0;
            }
            else if (value==50)
            {
                EventManager.eventOnWinGame();
                score = 0;
            }
            else
            {
                score = value;
            }
            
        }
    }

    private static float health=3;

    public static float Health
    {
        get { return health; }
        set { health = value; }
    }

    private static float volumeEffects=1f;

    public static float VolumeEffects
    {
        get { return volumeEffects; }
        set { volumeEffects = value; }
    }
    private static float volumeMusic = 0.5f;

    public static float VolumeMusic
    {
        get { return volumeMusic; }
        set { volumeMusic = value; }
    }
    private static float sensitivity = 1f;

    public static float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }




    public static void IncreaseScore()
    {
        Score += 1;
    }
    public static void DecreaseHelth()
    {
        Health -= 1;
    }
    public static void IncreaseHelth()
    {
        Health += 1;
    }


}
