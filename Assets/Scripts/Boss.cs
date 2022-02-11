using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private GameObject[] heart;
    [SerializeField] private GameObject[] emptyHeart;
    [SerializeField] private bool isInvincible;
    [SerializeField] private GameObject bossButton;
    [SerializeField] private Transform bossSpawn;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private float scoreBoss;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void SetHealth(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
        }
        StartCoroutine("Invincible");
        if ( currentHealth < maxHealth && 0<currentHealth)
        {
            heart[currentHealth].SetActive(false);
        }
        else if (currentHealth<1 )
        {
            StartCoroutine("Dead");
        }
        else if(currentHealth == maxHealth)
        {
            foreach (var image in emptyHeart)
            {
                image.SetActive(true);
            }
            foreach (var image in heart)
            {
                image.SetActive(true);
            }
        }
    }

    IEnumerator Dead()
    {
        heart[currentHealth].SetActive(false);
        yield return new WaitForSeconds(1);
        ResetBoss();
        scoreManager.ScoreCount(scoreBoss);

    }

    IEnumerator Invincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(2);
        isInvincible = false;
    }

    public void ResetBoss()
    {
        foreach (var image in emptyHeart)
        {
            image.SetActive(false);
        }

        bossButton.SetActive(true);
        currentHealth = maxHealth;
        transform.position = bossSpawn.position;
    }
    
}
