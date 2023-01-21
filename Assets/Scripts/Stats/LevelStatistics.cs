using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStatistics
{
    [SerializeField] private int m_amountOfEnemy;
    public int AmountOfEnemy => m_amountOfEnemy;

    [SerializeField] private int m_amountOfAddedAmmo;
    public int AmountOfAddedAmmo => m_amountOfAddedAmmo;

    [SerializeField] private int m_amountOfAmmoBoost;
    public int AmountOfAmmoBoost => m_amountOfAmmoBoost;

    [SerializeField] private int m_amountOfHpAdded;
    public int AmountOfHpAdded => m_amountOfHpAdded;

    [SerializeField] private int m_amountOfSpeedBoost;
    private int AmountOfSpeedBoost => m_amountOfSpeedBoost;
}
