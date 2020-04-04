using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attacks")]
    public List<Attack> AcquiredSpecials;
    
    [System.Serializable]
    public class BoundAttack
    {
        public string ActivateButton;
        public Attack Attack;
    }

    public BoundAttack SpecialAttackOne;
    public BoundAttack SpecialAttackTwo;

    [Header("Controls")]
    public string BasicAttackButton = "Fire1";
    public Attack BasicAttack;

    private void Update()
    {        
        if(Input.GetButtonDown(BasicAttackButton))
        {
            BasicAttack.Activate();
        }

        
    }

    private void OnDrawGizmos()
    {
        
    }
}
