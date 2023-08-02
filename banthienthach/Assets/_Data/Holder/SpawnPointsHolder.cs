using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsHolder : DatMonoBehaviour
{
    public Transform target;
    public float speed = 10f;


    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.target = GameObject.Find("CameraHolder").transform;
    }

    protected virtual void Following()
    {
        if (this.target == null) return;

        transform.position = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * this.speed);
    }
}
