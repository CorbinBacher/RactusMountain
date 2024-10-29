using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] public float health;
    public float curHealth;
    private Animator animate;
    [SerializeField] private AudioClip pain;
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
        curHealth = health;

    }

    // Update is called once per frame
    void Update()
    {
        if(health < curHealth)
        {
            curHealth = health;
            AudioManager.instance.PlaySound(pain);
            animate.SetTrigger("Attacked");
        }

        if(health <= 0)
        {
            animate.SetBool("isDead", true);
            GetComponentInParent<EnemyPatrol>().enabled = false;
            GetComponent<MeleeEnemy>().enabled = false;
            Debug.Log("Enemy dead");
        }
    }
}
