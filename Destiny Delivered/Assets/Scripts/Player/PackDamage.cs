using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackDamage : MonoBehaviour
{
    [SerializeField] HealthBar health_bar;
    private int pack_damage = 2;
   private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag != "Player")
        {
            this.PackageDamage();
        }
   }

   public void PackageDamage(){
        float new_energy = health_bar.GetCurrentHealth() - pack_damage;
        health_bar.SetHealth((int)new_energy);
    }
}
