using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    private bool paused = true;

    public bool Paused {
        get { return paused; }
        private set { paused = value; }
    }

    public void StopGame()
    {
        if (!paused)
        {
            paused = true;
        } else
        {
            paused = false;
        }
    }

}
