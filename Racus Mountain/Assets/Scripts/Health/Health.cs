using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startHealth;
    public float curHealth { get; private set;}
    private Animator animate;
    private bool isDead;
    [SerializeField] private AudioClip pain;

    private void Awake()
    {
        curHealth = startHealth;
        animate = GetComponent<Animator>();
    }

    public void TakeDamage(float dmg)
    {
        curHealth = Mathf.Clamp(curHealth - dmg, 0, startHealth);

        if(curHealth > 0)
        {
            //Player takes damage
            animate.SetTrigger("hurt");
            AudioManager.instance.PlaySound(pain);
            
        }
        else {
            //Player dies
            if(!isDead)
            {
                animate.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                isDead = true;
            }
        }
    }

    public void AddHealth(float hp)
    {
        curHealth = Mathf.Clamp(curHealth + hp, 0, startHealth);
    }
    


}
