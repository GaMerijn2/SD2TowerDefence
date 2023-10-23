using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int BaseHealth { get;  set; }
    // Hello please note, i NEED this Enemy script in my enemy GameObject, cause otherwise the tower won't target the enemy, im not in the mood to fix it as it is 23.55PM, Thank you :)
    // and i dont want to convert the BaseHedalth one to the EnemyBehaviour script and use it as my health. cause game breaks without that fking line of code :/
}
