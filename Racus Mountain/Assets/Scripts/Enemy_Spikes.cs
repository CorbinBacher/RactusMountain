using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spikes : MonoBehaviour
{
    [SerializeField] private float dmg;
    //[SerializeField] private AudioClip pain;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Health>().TakeDamage(dmg);
           // AudioManager.instance.PlaySound(pain);
        }
    }

}
