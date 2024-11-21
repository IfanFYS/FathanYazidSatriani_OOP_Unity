using UnityEngine;

public class Enemy : MonoBehaviour
{
    private CombatManager combatManager;

    private void Start()
    {
        combatManager = FindObjectOfType<CombatManager>();
    }

    public void OnDefeated()
    {
        combatManager.EnemyDefeated();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            OnDefeated();
        }
    }
}
