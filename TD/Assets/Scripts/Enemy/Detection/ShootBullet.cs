using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private bool canAttack = false;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    public float attackCooldown = 1f;

    [SerializeField]
    private AudioSource[] bulletSounds;

    public void ShootBulletForward( float speed, float cooldown)
    {

    }
}
