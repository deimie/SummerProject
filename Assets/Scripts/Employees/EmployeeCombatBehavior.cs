using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UIElements;

public class EmployeeCombatBehavior : MonoBehaviour
{

    public GameObject projectilePrefab; //prefab for the projectile of ranged attackers
    private Employee employee; //reference to associated Employee components
    private float lastAttackTime; //tracks the time of the last attack (enforcing cooldown)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        employee = GetComponent<Employee>();
        lastAttackTime = -employee.stats.cooldown;

    }

    // Update is called once per frame
    void Update()
    {
        //finds all colliders in the enemy layer within employee's detection range using a sphere centered on the employee
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, employee.stats.detectionRange, LayerMask.GetMask("Enemy"));
        if (enemiesInRange.Length > 0 && Time.time >= lastAttackTime + employee.stats.cooldown) //if there are enemies and cooldown is over
        {
            Attack(enemiesInRange[0].transform); //attack the first enemy in range
            lastAttackTime = Time.time;
        }

    }

    //NOTE: THIS IS TEMP FOR TESTING MODIFY THIS LATER

    //executes attack on enemy
    void Attack(Transform enemy)
    {
        if (employee.stats.type == "melee")
        {
            //melee apply damage instantly
            EnemyStats enemyHealth = enemy.GetComponent<EnemyStats>();
            if (enemyHealth != null)
                enemyHealth.TakeDamage(employee.stats.damage);
        }
        else if (employee.stats.type == "ranged")
        {
            //instantiate and shoot projectile
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<ProjectileBehavior>().Launch(enemy, employee.stats.damage);
        }
    }
}
