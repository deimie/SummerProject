using UnityEngine;

public class Employee : MonoBehaviour

    //NOTE: need to add save system to save unique employees and stats
{
    public EmployeeStat stats; //holds the employee's stats such as type, dmg, and detection range

    private void Awake()
    {
        //make a new employee with these temp stats (will be modified)
        Initialize(new EmployeeStat("Temp", "ranged", 50, 10, 3));
    }

    //set stats for this employee
    public void Initialize(EmployeeStat newStats)
    {
        stats = newStats;
    }

    //debugging detection range
    void OnDrawGizmosSelected()
    {
        if (stats != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, stats.detectionRange);
        }
    }

}
