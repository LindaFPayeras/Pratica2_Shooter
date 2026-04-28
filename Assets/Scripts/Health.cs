using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int life = 100;

    public void TakeDamage(int amount)
    {
        life -= amount;

        Debug.Log(gameObject.name + " tiene " + life + " de vida");

        if (life <= 0)
        {
            Die();
        }
    }
 

    private void Die()
    {
        // Llama a OnDeath si existe en el objeto
        SendMessage("OnDeath", SendMessageOptions.DontRequireReceiver);
    }

    public int CurrentLife => life;
}