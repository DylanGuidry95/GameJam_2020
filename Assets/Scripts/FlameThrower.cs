using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : Attack
{
    public float Range;

    public float Damage;

    public ParticleSystem ProjectileParticle;

    private float dmgTimer;
    public float DamgeDelay;

    private void Update()
    {
        var mainSystem = ProjectileParticle.main;
        mainSystem.startLifetime = Range / 2;

        if(ProjectileParticle.isPlaying)
        {
            dmgTimer += Time.deltaTime;
            if (dmgTimer >= DamgeDelay)
            {
                dmgTimer = 0;
                RaycastHit hit;
                if (Physics.Raycast(transform.position + transform.forward, transform.forward, out hit))
                {
                    if (hit.collider.gameObject != null && hit.collider.gameObject != ProjectileParticle.gameObject)
                    {
                        if (hit.collider.GetComponent<Health>())
                            hit.collider.GetComponent<Health>().TakeDamage(Damage);
                    }
                }
            }
        }
    }

    public override void Activate()
    {
        base.Activate();

        ProjectileParticle.Play();
    }

    public override void DeActivate()
    {
        base.DeActivate();

        ProjectileParticle.Stop();
    }

    public override void Fuse(Attack other)
    {
        base.Fuse(other);
        Damage *= PowerLevel;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position + transform.forward, transform.position + (transform.forward * Range));
    }
}
