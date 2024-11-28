using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    private TextMeshProUGUI healthText;
    private HealthComponent healthComponent;

    void Start()
    {
        // Find the HealthComponent on the Player
        healthComponent = Player.Instance.GetComponent<HealthComponent>();
        // Find the UI Text element to display health
        healthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Update health text every frame
        healthText.text = "Health: " + healthComponent.Health.ToString();
    }
}
