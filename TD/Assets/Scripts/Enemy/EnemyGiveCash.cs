using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyGiveCash : MonoBehaviour
{
    [SerializeField]
    Cash cash;
    [SerializeField]
    public static TextMeshProUGUI MoneyDisplay;
    // Start is called before the first frame update
    void Start()
    {
       // cash = GetComponent<Cash>();
        cash = FindAnyObjectByType<Cash>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Cash.cashAmount +=(50);
            Debug.Log(Cash.cashAmount);
            MoneyDisplay.text = "Money: " + Cash.cashAmount.ToString();
        }
    }
}
