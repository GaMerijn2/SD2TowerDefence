using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    bool canAttack = true;

    [SerializeField]
    float bulletSpeed;

    [SerializeField]
    float attackCooldown;

    public void ShootBulletForward( float speed, float attackCooldown)
    {
        if (canAttack)
        {
            bulletSpeed = speed;
            GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);


            currentBullet.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 0) * bulletSpeed, ForceMode.Impulse);
            Invoke(nameof(resetAttack), attackCooldown);
        }
    }
    private void resetAttack()
    {
        canAttack = true;
    }
}
