using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPickUp : MonoBehaviour
{
    public Attack AttackPrefab;
    

    public TextMesh PowerLevelIndicator;

    private void Awake()
    {
        GetComponent<MeshRenderer>().material.color = AttackPrefab.ColorCue;
        PowerLevelIndicator.text = AttackPrefab.PowerLevel.ToString();
    }

    private void Update()
    {        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerAttack>())
        {
            if (other.GetComponent<PlayerAttack>().TryAddAttack(AttackPrefab))
                Destroy(this.gameObject);
        }
    }
}
