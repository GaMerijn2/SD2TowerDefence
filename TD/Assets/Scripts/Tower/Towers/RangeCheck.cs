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
        if(targetsInRange.Count > 0)
        {
            Debug.DrawLine(transform.position, currentTarget.transform.position, color: Color.red);
            transform.LookAt(currentTarget.transform.position);
            shootBullet.ShootBulletForward(20, 0.5);
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

    private void HandleTargetDeath()
    {
        currentTarget.OnDeath -= HandleTargetDeath;
        GetCurrentTarget();
    }

    private void GetCurrentTarget()
    {
        if(targetsInRange.Count <=0)
        {
            Debug.Log("No Enemys In Range");
            currentTarget = null;
            return;
        }

        if(currentTarget != null)
        {
            currentTarget.OnDeath -= HandleTargetDeath;
        }

        currentTarget = currentTargetingStyle switch
        {
            TargetingStyle.First => targetsInRange.First(),
            TargetingStyle.Last => targetsInRange.Last(),
            TargetingStyle.Strong => targetsInRange.OrderBy(e => e.BaseHealth).First(),
            TargetingStyle.Weak => targetsInRange.OrderBy(e => e.BaseHealth).Last(),
            _ => targetsInRange.First()

        };

        currentTarget.OnDeath += HandleTargetDeath;
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
