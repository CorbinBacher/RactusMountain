using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoints : MonoBehaviour
{
 [SerializeField] private Health playerHealth;
 [SerializeField] private Image totalHP;
 [SerializeField] private Image currentHP;

 private void Start()
 {
    totalHP.fillAmount = playerHealth.curHealth / 3;
 }

 private void Update()
 {
    if(playerHealth.curHealth == 3)
    {
        currentHP.fillAmount = 1;
    }
    else if(playerHealth.curHealth == 2)
    {
        currentHP.fillAmount = 0.75f;
    }
    else if(playerHealth.curHealth == 1)
    {
        currentHP.fillAmount = 0.5f;
    }
    else{
        currentHP.fillAmount = 0;
    }
    
 }
}
