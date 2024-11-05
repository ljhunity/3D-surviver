using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagelbe
{
    void TakePhyicaIDamagelbe(int damage);
}

public class PlayerCondition : MonoBehaviour,IDamagelbe
{

    public UiCondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition hunger { get { return uiCondition.hunger; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public float NoHungerHealthDecay;

    public event Action OnTakedamage;
        
     // Update is called once per frame
    void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (hunger.curValue < 0f)
        {
            health.Subtract(NoHungerHealthDecay * Time.deltaTime);
        }
        if (health.curValue < 0f)
        {
            Die();
        }
    }

    public void Heal(float amout)
    {
        health.Add(amout);
    }

    public void Eat(float amout)
    {
        hunger.Add(amout);
    }
    public void Die()
    {
        Debug.Log("죽었다");
    }

    public void TakePhyicalDamagelbe(int damage)
    {
        health.Subtract(damage);
        OnTakedamage?.Invoke();
    }

    public void TakePhyicaIDamagelbe(int damage)
    {
        throw new NotImplementedException();
    }
}
