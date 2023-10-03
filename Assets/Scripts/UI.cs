using System;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI instance;

    [Header("UI")] 
    public TextMeshProUGUI curBulletsText;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        
    }
}
