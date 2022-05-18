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
    /* private void OnCollisionEnter(Collision collision)
    {
        var reciever = collision.gameObject.GetComponent<ITakeDamage>();
        var movement = collision.gameObject.GetComponent<PlayerMovement>();
        if (reciever != null)
        {
            reciever.TakeDamage(damage);
            if (destroyOnHit)
                Destroy(gameObject);
        }
        if (movement != null)
        {
            var dir = collision.transform.position - transform.position;
            dir.Scale(transform.right);
            movement.Push(dir.normalized * push);

        }
    } */
    public void DealDamage(Transform hit)
    {
        var reciever = hit.GetComponent<ITakeDamage>();
        var movement = hit.GetComponent<PlayerMovement>();
        if (reciever != null)
        {
            reciever.TakeDamage(damage);
        }
        if(movement != null)
        {
            var dir = hit.position - transform.position;
            dir.Scale(transform.right);
            movement.Push(dir.normalized * push);
            Debug.Log("pyuum");

        }
        if (destroyOnHit)
            Destroy(gameObject);
    }
}
