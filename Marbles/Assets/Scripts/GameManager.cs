using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private int previousLevel;
    public int[] finishedLevels = new int[10];
    


    public void PrepFinishedLevels()
    {
        // Main Menu
        finishedLevels[0] = 0;
        // Level Select
        finishedLevels[1] = 1;
        
    }

    public void SetCurrentLevel(int currentLevel)
    {
        previousLevel = currentLevel;
    }

    // lisää läpäistyjen levelien listaan
    public void AddFinishedLevels(int finishedLevel)
    {
        
        finishedLevels[finishedLevel] = finishedLevel;

        for(int i = 0; i < finishedLevels.Length; i++)
        {
            Debug.Log(finishedLevels[i]);
        }
    }
    
}
