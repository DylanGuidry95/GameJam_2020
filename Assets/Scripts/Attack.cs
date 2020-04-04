using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public string AttackName;

    public float Cooldown;

    private float timer;

    public Color ColorCue;

    public bool IsHold;

    public int PowerLevel;

    public bool IsSpecialAttack;

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

    public virtual void DeActivate()
    {
        timer = 0;
    }

    public virtual void Fuse(Attack other)
    {
        if(other.PowerLevel == PowerLevel && other.AttackName == AttackName)
        {
            PowerLevel++;
        }
        else
        {
            return;
        }
    }

    public static bool operator==(Attack a, Attack b)
    {        
        return b.PowerLevel == a.PowerLevel && b.AttackName == a.AttackName;
    }

    public static bool operator !=(Attack a, Attack b)
    {        
        return b.PowerLevel != a.PowerLevel && b.AttackName != a.AttackName;
    }
}
