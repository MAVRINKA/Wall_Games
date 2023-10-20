using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsGame : MonoBehaviour
{
    public int speedGame;

    private void Start()
    {
        DropDownSample(0);
    }

    public void DropDownSample(int index)
    {
        switch (index)
        {
            case 0:
                speedGame = 5;
                break;

            case 1:
                speedGame = 10;
                break;

            case 2:
                speedGame = 15;
                break;

            case 3:
                speedGame = 20;
                break;

            case 4:
                speedGame = 25;
                break;
        }
    }
}
