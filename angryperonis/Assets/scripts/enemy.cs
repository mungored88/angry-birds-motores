using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float points, life;
    public GameObject manager;
    public DestroyableComp destroyable;

    // Start is called before the first frame update
    void Start()
    {
        destroyable = this.gameObject.GetComponent<DestroyableComp>();
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if(destroyable.life <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        manager.GetComponent<TurnMananger>().score += points;
        GameObject.Destroy(this.gameObject);
    }
}
