using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : DatMonoBehaviour
{
    public JunkSpawnCtrl junkCtrl;
    public float randomDelay = 1f;
    public float randomTimer = 0f;
    public float randomLimit = 9f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = GetComponent<JunkSpawnCtrl>();
        Debug.Log(transform.name + ": JunkCtrl", gameObject);

    }

    protected virtual void FixedUpdate()
    {
        JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        
        this.randomTimer += Time.fixedDeltaTime;

        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0f;

        Transform ranPoint = this.junkCtrl.spawnPoints.GetRandom();


        Vector3 pos = ranPoint.position;
        Quaternion ros = transform.rotation;
        Transform ran = JunkSpawner.Instance.GetRandomBullet();
        Transform obj = this.junkCtrl.junkSpawner.Spawn(ran.name,pos,ros);
        obj.gameObject.SetActive(true);
        
    }

    
}
