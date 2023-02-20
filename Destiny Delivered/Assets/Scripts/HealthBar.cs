using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   Slider healthSlider;
   [SerializeField] Slider objectSlider;

    private void Start() {
        healthSlider = GetComponent<Slider>();
        if(healthSlider == null){
              healthSlider =  objectSlider;
        }
    }
   public void SetMaxHealth(int max_health)
   {
        healthSlider.maxValue = max_health;
        healthSlider.value = max_health;
   }

   
   public void SetHealth(int health)
   {
        healthSlider.value = health;

   }

   public float GetCurrentHealth(){
        return healthSlider.value;
   }
}
