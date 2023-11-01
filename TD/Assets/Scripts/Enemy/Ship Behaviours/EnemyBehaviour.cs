using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.UIElements;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] public int health = 100;
    [SerializeField] RangeCheck[] rangeChecks;
    [SerializeField] private Animator animator;
    [SerializeField] public GameObject Explo;

    public static event Action OnDeath;

    private void Update()
    {
        rangeChecks = FindObjectsOfType<RangeCheck>();

        if (health <= 0)
        {
            OnDeath?.Invoke();
            Instantiate(Explo, transform.position + new Vector3(0,40,0), Quaternion.identity);
            animator.Play("Explosion");
            //animator.Play("Sinking");
            float currInfo = animator.GetCurrentAnimatorStateInfo(0).length;
            Debug.Log(currInfo);
           Invoke(nameof(KillEnemy),0f);

            for (int i = 0; i < rangeChecks.Length; ++i)
            {
                rangeChecks[i].RemoveTargetFromInRangeList(GetComponent<Enemy>());
                rangeChecks[i].GetCurrentTarget();
            }
        }
    }
    private void KillEnemy()
    {
        Destroy(this.gameObject);

    }
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name == "BulletObj")
        {
            health -= 10;
        }
        if (trigger.gameObject.name == "FastBulletObj")
        {
            health -= 3;
        }
        if (trigger.gameObject.name == "EndPoint")
        {
            health -= 100;
        }
    }
}
