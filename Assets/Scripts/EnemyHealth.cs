using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{

    private Animator anim;

    public int health;

    public void TakeDamage(int damage)
    {
        anim = GetComponent<Animator>();

        health -= damage;

        if (anim.GetBool("Parried") == true)
        {
            anim.SetBool("Parried", false);
        }

        StartCoroutine(DamageAnimation());

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.r = 255;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.r = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }
        }

    