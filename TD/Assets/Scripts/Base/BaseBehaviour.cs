using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseBehaviour : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private HealthBar healthBar;

    [SerializeField]
    AudioSource loseSound;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        maxHealth = 100;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            this.health -= other.GetComponent<EnemyBehaviour>().health;
            healthBar.SetHealth(this.health);

            if (this.health <= 0)
            {
                loseSound.Play();
                SceneManager.LoadScene("EndMenuScene");
            }
        }
    }

}
