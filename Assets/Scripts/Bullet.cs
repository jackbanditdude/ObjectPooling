using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    private protected Rigidbody2D rb;
    private protected BulletManager bm;

    public int bulletSpeed = 1;

    virtual public void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.bm = GameObject.Find("BulletManager").GetComponent<BulletManager>();
    }

    public Bullet FireBullet(Vector3 startPosition)
    {
        this.transform.position = startPosition;
        rb.velocity = new Vector2(0, this.bulletSpeed);
        return this;
    }

    virtual public void Update()
    {
        CheckForRequeue();
    }

    public abstract void CheckForRequeue();
}
