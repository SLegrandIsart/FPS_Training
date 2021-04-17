using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponMode
{
    SEMI_AUTO,
    AUTO,
    RAFALE
}

public abstract class Weapon : MonoBehaviour
{
    [Header("Parameters")]
    // Amount of bullets per seconds
    [SerializeField] private float m_fireRate = 2f;

    [Header("Bullets")]
    [SerializeField] private int chargerSize = 20;
    [SerializeField] private int maxInventoryBullets = 200;
    [SerializeField] private float m_reloadTime = 1f;

    private int bulletAmount = 40;
    private int bulletInCharger = 20;

    private bool m_isShooting = true;
    private float m_timeBetweenShoots = 0f;

    // Start is called before the first frame update
    void Start()
    {
        bulletInCharger = chargerSize;
        m_timeBetweenShoots = 1f / m_fireRate;
    }

    private void Reload()
    {
        int amountBulletToReload = chargerSize - bulletInCharger;

        if (bulletAmount < chargerSize)
            amountBulletToReload = bulletAmount - bulletInCharger;

        bulletAmount -= amountBulletToReload;
        bulletInCharger += amountBulletToReload;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
