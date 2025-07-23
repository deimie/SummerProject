using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UIElements;

public class EmployeeCombatBehavior : MonoBehaviour
{

    public EmployeeStat employeeStat;
    public Transform attackPoint;

    //only for projectile employees
    public GameObject projectilePrefab;
    public float projectileSpeed;

    public LayerMask enemyLayers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
