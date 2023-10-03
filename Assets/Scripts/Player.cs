using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

    public Weapon weapon;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (health <= 0)
        {
            Debug.Log("die(");
        }

        health -= damage;
    }
}
