using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{
    private Queue<Bullet> bulletPool;
    private List<Bullet> usingPool;

    private Text poolText;
    private Text usingText;

    public PlayerBullet pBullet;
    public EnemyBullet eBullet;

    // Start is called before the first frame update
    void Start()
    {
        this.bulletPool = new Queue<Bullet>();
        this.usingPool = new List<Bullet>();

        this.poolText = GameObject.Find("BulletPoolText").GetComponent<Text>();
        this.usingText = GameObject.Find("BulletUsingText").GetComponent<Text>();

        AddToBulletPool(5);
    }

    private void AddToBulletPool(int v)
    {
        for (int i = 0; i < v; i++)
        {
            // Create a new bullet and add it to list
            this.bulletPool.Enqueue(
                GameObject.Instantiate(
                    pBullet, 
                    new Vector3(-100, 0, 0), 
                    Quaternion.identity
                )
            );

            this.bulletPool.Enqueue(
                GameObject.Instantiate(
                    eBullet,
                    new Vector3(-100, 0, 0),
                    Quaternion.identity
                )
            );
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.poolText.text = "Bullet Pool: " + this.bulletPool.Count;
        this.usingText.text = "Bullets in Use: " + this.usingPool.Count;
    }

    public void DequeueBullet(Vector3 mousePosition)
    {
        if (this.bulletPool.Count > 0)
            this.usingPool.Add(this.bulletPool.Dequeue().FireBullet(mousePosition));
    }

    public void EnqueueBullet(Bullet bullet)
    {
        this.usingPool.Remove(bullet);
        this.bulletPool.Enqueue(bullet);
    }
}
