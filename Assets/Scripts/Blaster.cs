using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : Attack
{
    public float Range;

    public int Damage;

    public ParticleSystem ProjectileParticle;

    public ParticleSystem.Particle[] ActiveParticles;
    
    public override void Activate()
    {
        base.Activate();

        ProjectileParticle.Play();

        RaycastHit hit;
        if (Physics.Raycast(transform.position + transform.forward, transform.forward, out hit))
        {
            if (hit.collider.gameObject != null && hit.collider.gameObject != ProjectileParticle.gameObject)
            {
                Debug.Log("hit");
                if (hit.collider.GetComponent<Health>())
                    hit.collider.GetComponent<Health>().TakeDamage(Damage);
            }
        }
    }

    private void Update()
    {
        var mainSystem = ProjectileParticle.main;        
        mainSystem.startLifetime = Range / 50;        
    }

    [ContextMenu("a")]
    void test()
    {
        ProjectileParticle.Play();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position + transform.forward, transform.position + (transform.forward * Range));
    }
}
