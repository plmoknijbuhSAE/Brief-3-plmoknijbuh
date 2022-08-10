using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // This script is applied to each new bullet that is instantiated so that each bullet can act independently of the other
    private Rigidbody rb;
    private Transform pos;
    public GameObject explosion;
    private float shellLife;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = GetComponent<Transform>();       
        BulletSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        BulletDeclutter();
    }
    public void OnCollisionEnter(Collision collision)
    {
        // Spawns a ShellExplosion prefab at the position of the bullet and deletes the bullet
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Enemy")
        {
            Instantiate(explosion, pos.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().healthPoints --;
            Instantiate(explosion, pos.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Physics.IgnoreCollision(pos.GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Collider>());
        }
    }

    private void BulletSpawn()
    {
        // When a bullet is spawned the bullet is rotated and its position is set so that it looks like its coming out of the tank's barrel
        // Force impulse is applied to give the shell an arc and Torque impulse is applied to allow the bullet to rotate during it's arc
        pos.Rotate(Vector3.left, 15);
        rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);

        if (pos.rotation.eulerAngles.y == 90)
        {
            pos.position = new Vector3(pos.position.x + 1.1f, pos.position.y + 0.6f, pos.position.z);
            rb.AddTorque(new Vector3(0, 0, -0.03f), ForceMode.Impulse);
            rb.AddForce(new Vector3(15, 0, 0), ForceMode.Impulse);
        }
        if (pos.rotation.eulerAngles.y == 180)
        {
            pos.position = new Vector3(pos.position.x, pos.position.y + 0.6f, pos.position.z - 1.1f);
            rb.AddTorque(new Vector3(-0.03f, 0, 0), ForceMode.Impulse);
            rb.AddForce(new Vector3(0, 0, -5), ForceMode.Impulse);
        }
        if (pos.rotation.eulerAngles.y == 270)
        {
            pos.position = new Vector3(pos.position.x - 1.1f, pos.position.y + 0.6f, pos.position.z);
            rb.AddTorque(new Vector3(0, 0, 0.03f), ForceMode.Impulse);
            rb.AddForce(new Vector3(-15, 0, 0), ForceMode.Impulse);
        }
    }

    private void BulletDeclutter()
    {
        // To ensure bullets that somehow bug out and don't trigger a collide will still get removed
        shellLife += Time.deltaTime;
        
        if (shellLife > 5)
        {
            Destroy(gameObject);
        }
    }
}
