using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageableComponent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject healthBarObj;
    public int health;
    int remainHealth;

    private void Start()
    {
        remainHealth = health;
        if (healthBarObj != null)
        {
            var healthBar = healthBarObj.GetComponent<HealthPreview>();
            healthBar.setHealth(remainHealth, health);
        }
    }

    public void Damage(int damage, float delay = 0f)
    {
        remainHealth-=damage;
        if (healthBarObj != null)
        {
            var healthBar = healthBarObj.GetComponent<HealthPreview>();
            healthBar.setHealth(remainHealth, health);
        }
        if (remainHealth <= 0)
        {
            remainHealth = 0;
            DestroyElement(delay);
        }
    }

    public abstract void DestroyElement(float delay = 0f);

   
}
