using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    override public void Update()
    {
        base.Update();
    }

    public override void CheckForRequeue()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y > 1)
        {
            this.rb.velocity = new Vector2(0, 0);
            this.transform.position = new Vector3(-100, 0, 0);
            bm.EnqueueBullet(this);
        }
    }
}
