using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weapon;

    [Header("Stats")]
    public int damage;
    public float fireSpeed;
    private float startBtwShots;
    public int bullets;
    public int maxBullets;

    [Header("Bools")]
    public bool ReloadUI;
    
    [Header("GameObjects")]
    public GameObject bulletPrefab;
    public GameObject shootEffect;
    public Transform firePoint;

    [Header("UI Reload")]
    public GameObject weaponReloadUI;
    private Vector3 startScale;
    private Vector3 targetScale;

    [Header("Recoil")] 
    public float intensity;
    public float speedRecoil;
    
    public Animator animator;

    private void Start()
    {
        damage = weapon.damage;
        fireSpeed = weapon.fireSpeed;
        bullets = weapon.bullets;
        maxBullets = weapon.maxBullets;

        bullets = maxBullets;
        
        startScale = weaponReloadUI.transform.localScale; // Начальный масштаб
        targetScale = new Vector3(0f, startScale.y, startScale.z); // Целевой масштаб
        
        UpdateUI();
    }

    private void Update()
    {
        startBtwShots += Time.deltaTime;

        if (bullets > 0)
        {
            if (Input.GetKey(KeyCode.Mouse0) && fireSpeed <= startBtwShots)
            {
                Shoot();
                startBtwShots = 0;
            
                animator.SetTrigger("Recoil"); // запускаем анимацию отдачи
            }
        }

        if (ReloadUI)
        {
            weaponReloadUI.transform.localScale = Vector3.Lerp(startScale, targetScale, startBtwShots / fireSpeed);
            weaponReloadUI.SetActive(true);
        }
        else
        {
            weaponReloadUI.SetActive(false);
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        GameObject effect = Instantiate(shootEffect, firePoint.position, Quaternion.identity);
        CameraShake.instance.ShakeCamera();
        Vector2 shootDirection = transform.right; // направление выстрела по умолчанию

        if (transform.localScale.x < 0) // если оружие повернуто влево
        {
            shootDirection = -shootDirection; // изменяем направление выстрела
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y,
                bullet.transform.localScale.z);
        }

        bullets--;
        UpdateUI();

        bullet.GetComponent<Bullet>().SetDirection(shootDirection, damage);

        Destroy(effect, 0.2f); // удаляем эффект выстрела через время
    }

    public void UpdateUI()
    {
        UI.instance.curBulletsText.text = bullets + "/" + maxBullets;
    }
}
