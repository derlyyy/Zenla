using UnityEngine;

[CreateAssetMenu(fileName = "Weapon")]
public class WeaponData : ScriptableObject
{
    public int damage;
    public float fireSpeed;
    public int bullets;
    public int maxBullets;
}
