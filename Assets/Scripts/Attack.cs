using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public string AttackName;

    public float Cooldown;

    private float timer;

    private bool CanActivate
    {
        get
        {
            if (timer >= Cooldown)
            {
                timer = 0;
                return true;
            }
            return false;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public virtual void Activate()
    {
        if (!CanActivate)
            return;
    }
}
