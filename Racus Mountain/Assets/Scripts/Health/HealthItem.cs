using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
  [SerializeField] private float numHP;
  [SerializeField] private AudioClip hp;

  public void OnTriggerEnter2D(Collider2D other)
  {
    if(other.tag == "Player")
    {
        other.GetComponent<Health>().AddHealth(numHP);
        AudioManager.instance.PlaySound(hp);
        gameObject.SetActive(false);
    }
  }
}
