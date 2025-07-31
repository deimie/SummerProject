using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health = 100; //temp

    //makes the enemy take damage
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


    //NOTE: will add stats for different types of enemies
    //NOTE: will add die function
    //NOTE: will add attacking employees/workers comp system
}
