using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int level;

    public UnityEvent enemyKilledEvent;

    private Camera mainCamera;

    private void Start()
    {
        enemyKilledEvent ??= new UnityEvent();  // Ensure the event is initialized
        mainCamera = Camera.main;  // Get the main camera reference
    }

    private void Update()
    {
        // Check if the enemy is no longer within the camera's view using WorldToViewportPoint
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);
        
        // If the enemy is out of the camera bounds (not visible)
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            KillEnemy();
        }
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    public int GetLevel()
    {
        return level;
    }

    private void OnDestroy()
    {
        enemyKilledEvent.Invoke();
    }

    private void KillEnemy()
    {
        // This method will handle the logic when an enemy goes off-screen
        Debug.Log("Enemy went off-screen and is considered killed!");
        enemyKilledEvent.Invoke();  // Trigger the death event when the enemy goes off-screen
        Destroy(gameObject);  // Destroy the enemy object when it goes off-screen
    }
}
