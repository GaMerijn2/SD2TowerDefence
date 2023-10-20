using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCash : MonoBehaviour
{
    // if on button, get data.money and remove towerCost from the data.money.
    [SerializeField] private double cashAmount, towerCost;
    private void RemoveCash(double cash, double towercost)
    {
        cashAmount = cash;
        towerCost = towercost;

        cashAmount -= towerCost;
    }

}
