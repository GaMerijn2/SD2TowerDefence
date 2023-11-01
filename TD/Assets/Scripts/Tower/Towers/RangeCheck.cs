using Enums;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RangeCheck : MonoBehaviour
{

    [SerializeField]
    private List<Enemy> targetsInRange = new();

    [SerializeField]
    private Enemy currentTarget;

    [SerializeField]
    private TargetingStyle currentTargetingStyle = TargetingStyle.First;
    private TargetingStyle previousTargetingStyle;

    [SerializeField] ShootBullet shootBullet = new ShootBullet();


    private void Start()
    {
        previousTargetingStyle = currentTargetingStyle;
    }

    private void Update()
    {       
        if(targetsInRange.Count > 0 )
        {
            if(currentTarget != null)
            {
                Debug.DrawLine(transform.position, currentTarget.transform.position, color: Color.red);
                transform.LookAt(currentTarget.transform.position);
                shootBullet.ShootBulletForward(100, shootBullet.attackCooldown);
            }
        }

        if(previousTargetingStyle != currentTargetingStyle)
        {
            HandleTargetStyleSwitch();
        }
    }

    private void HandleTargetStyleSwitch()
    {
        previousTargetingStyle = currentTargetingStyle;
        GetCurrentTarget();
        Debug.Log("Attack Style Switched To " + currentTargetingStyle);
    }

    public void HandleTargetDeath()
    {
        EnemyBehaviour.OnDeath -= HandleTargetDeath;
        GetCurrentTarget();
    }

    public void GetCurrentTarget()
    {
        if(targetsInRange.Count <=0)
        {
            currentTarget = null;
            return;
        }

        if(currentTarget != null)
        {
            EnemyBehaviour.OnDeath -= HandleTargetDeath;
        }

        currentTarget = currentTargetingStyle switch
        {
            TargetingStyle.First => targetsInRange.First(),
            TargetingStyle.Last => targetsInRange.Last(),
            TargetingStyle.Strong => targetsInRange.OrderBy(e => e.BaseHealth).First(),
            TargetingStyle.Weak => targetsInRange.OrderBy(e => e.BaseHealth).Last(),
            _ => targetsInRange.First()

        };

        EnemyBehaviour.OnDeath += HandleTargetDeath;
    }
    public void AddTargetToInRangeList(Enemy target)
    {
        targetsInRange.Add(target);
        GetCurrentTarget();
    }

    public void RemoveTargetFromInRangeList(Enemy target)
    {
        targetsInRange.Remove(target);
        GetCurrentTarget();
    }
}
