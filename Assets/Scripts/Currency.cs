using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public static int currency; // валюта
    
    public void GiveMoney(int value)
    {
        currency += value;
    }

    public void TakeMoney(int value)
    {
        currency -= value;
    }
}
