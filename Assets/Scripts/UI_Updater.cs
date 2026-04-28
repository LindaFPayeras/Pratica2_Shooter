using UnityEngine;
using TMPro;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private TextMeshProUGUI lifeText;

    void Update()
    {
        lifeText.text = "Vida: " + playerHealth.CurrentLife;
    }
}