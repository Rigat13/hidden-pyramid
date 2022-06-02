using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private bool destroyOnHit;
    [SerializeField]
    private float push;

    public Animator animator;

    public ParticleSystem particleSystem;

    private void OnCollisionEnter(Collision collision)
    {
        var reciever = collision.gameObject.GetComponent<ITakeDamage>();
        var movement = collision.gameObject.GetComponent<PlayerMovement>();
        if (reciever != null)
        {
            reciever.TakeDamage(damage);
        }
            
        if (movement != null && push != 0)
        {
            var dir = collision.transform.position - transform.position;
            dir.Scale(transform.right);
            movement.Push(dir.normalized * push);
        }
        if (destroyOnHit)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var reciever = other.gameObject.GetComponent<ITakeDamage>();
        var movement = other.gameObject.GetComponent<PlayerMovement>();
        if (reciever != null)
        {
            reciever.TakeDamage(damage);
            if (destroyOnHit)
        {
            if (particleSystem != null)
            {
                Instantiate(particleSystem, transform.position, transform.rotation, null);
                //if (!particleSystem.isPlaying) particleSystem.Play();
            }
            Destroy(gameObject);
        }
        }
        if (movement != null && push != 0)
        {
            var dir = other.transform.position - transform.position;
            dir.Scale(transform.right);
            movement.Push(dir.normalized * push);
        }
    }
}
