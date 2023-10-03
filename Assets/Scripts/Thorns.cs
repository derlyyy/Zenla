using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : MonoBehaviour
{
    [SerializeField] private int damage;
    
    [Header("Toxic Settings")]
    [SerializeField] private int toxicDamage;
    [SerializeField] private float toxicDuration; // время действия яда
    [SerializeField] private bool isToxic; // если ядовитые, то будет наносится переодический урон

    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(damage);
        }
    }
}
