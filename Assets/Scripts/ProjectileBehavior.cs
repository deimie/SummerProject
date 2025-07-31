using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private Transform target; //target the projectile is moving towards
    private int damage; //damage to be applied
    public float speed = 10f; //speed of projectile

    //NOTE: maybe speed of projectile also can be upgraded?


    //initializes projectile with a target and dmg value
    public void Launch(Transform target, int damage)
    {
        this.target = target;
        this.damage = damage;
    }


    //called to move projectile and handle impact
    void Update()
    {
        //destroy projectile if target doesn't exist
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //move projectile towards target
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        //if close to target, apply damage and destroy projectile
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            EnemyStats enemyHealth = target.GetComponent<EnemyStats>();
            if (enemyHealth != null)
                enemyHealth.TakeDamage(damage);

            Destroy(gameObject);
        }
    }

    //NOTE: add particle effects for projectile upon impact, maybe a trail
}
