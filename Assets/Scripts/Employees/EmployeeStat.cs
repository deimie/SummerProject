using UnityEngine;

public class EmployeeStat
{
    public string name;
    public string type;
    public int damage;
    public float detectionRange;
    public int cooldown;

    public EmployeeStat(string name, string type,  int damage, float detectionRange, int cooldown)
    {
        this.name = name;
        this.type = type;
        this.damage = damage;
        this.detectionRange = detectionRange;
        this.cooldown = cooldown;
    }

    public void Upgrade(int newDamage, float newDetectionRange, int newCooldown)
    {
        damage = newDamage;
        detectionRange = newDetectionRange;
        cooldown = newCooldown;

    }

}
