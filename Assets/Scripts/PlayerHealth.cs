using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnpoint;
    public int health = 100;
    public int StartingHealth = 100;
    public Sprite[] healthsprites;
    public SpriteRenderer healthbar;
    
    public void TakeDamage(int damage)
    {
        health -= damage;

        StartCoroutine(DamageAnimation());

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        player.transform.position = respawnpoint.transform.position;
        health = StartingHealth;
    }

    IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }
    void Update()
    {

        if (health > 80)

            healthbar.sprite = healthsprites[0];


        else if (health > 60)

            healthbar.sprite = healthsprites[1];


        else if (health > 40)

            healthbar.sprite = healthsprites[2];


        else if (health > 20)

            healthbar.sprite = healthsprites[3];



        else if (health > 1)

            healthbar.sprite = healthsprites[4];

        else
            healthbar.sprite = healthsprites[5];
    }

}