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
    private AudioSource bulletSound;
    private void Start()
    {
        canAttack = false;
    }
    public void ShootBulletForward( float speed, float cooldown)
    {
        if (!canAttack)
        {

            bulletSpeed = speed;
            attackCooldown = cooldown;
            GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
            bulletSound.Play();

            canAttack = true;
            Invoke(nameof(resetAttack), attackCooldown);
        }
    }
    private void resetAttack()
    {
        canAttack = false;
    }

}
