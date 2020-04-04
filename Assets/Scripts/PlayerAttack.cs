using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attacks")]
    public List<Attack> AcquiredAttacks;
    
    [System.Serializable]
    public class BoundAttack
    {
        public string ActivateButton;
        public Attack Attack;
        public bool IsEmpty = true;
    }

    public BoundAttack[] Attacks;

    public GameObject BasicAttackSlot;
    public GameObject SpecialOneSlot;
    public GameObject SpecialTwoSlot;

    private void Awake()
    {
        foreach(var atk in AcquiredAttacks)
        {
            if(!atk.IsSpecialAttack && Attacks[0].IsEmpty)
            {
                var obj = Instantiate(atk);
                Attacks[0].Attack = obj;
                Attacks[0].Attack.transform.position = BasicAttackSlot.transform.position;
                Attacks[0].Attack.transform.rotation = BasicAttackSlot.transform.rotation;
                obj.transform.parent = BasicAttackSlot.transform;
                Attacks[0].IsEmpty = false;
            }
        }
    }

    private void Update()
    {
        foreach(var attack in Attacks)
        {
            if (attack.IsEmpty)
                continue;
            if (attack.Attack.IsHold)
            {
                if (Input.GetButton(attack.ActivateButton))
                    attack.Attack.Activate();
                else
                    attack.Attack.DeActivate();
            }
            else
                if (Input.GetButtonDown(attack.ActivateButton))
                    attack.Attack.Activate();
        }
    }

    private void OnDrawGizmos()
    {
        
    }

    public bool TryAddAttack(Attack other)
    {
        foreach(var atk in Attacks)
        {
            if (atk.Attack == other)
            {
                atk.Attack.Fuse(other);                
                return true;
            }
        }
        return false;
    }
}
