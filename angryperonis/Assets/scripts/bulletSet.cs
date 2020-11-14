using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSet : MonoBehaviour
{
    public float shootForce;
    float avShoot = 1;
    bool exp = false;
    public Rigidbody2D rb;
    public GameObject explotionRad;
    public GameObject explotionAnim;
    SpriteRenderer bulletSprite;
    public bool thisMolo, canon;
    public GameObject spawn1, spawn2, spawn3;
    public string commandShoot;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bulletSprite = this.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(avShoot > 0)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.up * shootForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);
            avShoot--;
        }
        this.transform.up = rb.velocity.normalized;
        if(!exp && thisMolo == true)
        {
            if (Input.GetButton(commandShoot))
            {
                GameObject newExplotion = GameObject.Instantiate(explotionRad);
                newExplotion.transform.position = spawn1.transform.position;
                newExplotion.GetComponent<Rigidbody2D>().AddForce((transform.up) * shootForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);

                GameObject newExplotion2 = GameObject.Instantiate(explotionRad);
                newExplotion2.transform.position = spawn2.transform.position;
                newExplotion2.GetComponent<Rigidbody2D>().AddForce((transform.up) * shootForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);

                GameObject newExplotion3 = GameObject.Instantiate(explotionRad);
                newExplotion3.transform.position = spawn3.transform.position;
                newExplotion3.GetComponent<Rigidbody2D>().AddForce((transform.up) * shootForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);

                exp = true;
                GameObject.Destroy(this.gameObject);
                GameObject.Destroy(newExplotion.gameObject, 2f);
                GameObject.Destroy(newExplotion2.gameObject, 2f);
                GameObject.Destroy(newExplotion3.gameObject, 2f);
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!exp && thisMolo == false && canon == false)
        {
            bulletSprite.color = new Color(0, 0, 0, 0);

            GameObject newExplotionAnim = GameObject.Instantiate(explotionAnim);
            newExplotionAnim.transform.position = this.transform.position;
            GameObject newExplotion = GameObject.Instantiate(explotionRad);
            newExplotion.transform.position = this.transform.position;
            exp = true;
            GameObject.Destroy(this.gameObject, 0.2f);
            GameObject.Destroy(newExplotion.gameObject, 0.2f);
            GameObject.Destroy(newExplotionAnim.gameObject, 1.5f);
        }
        else if (!exp && thisMolo == true)
        {
            bulletSprite.color = new Color(0, 0, 0, 0);

            //GameObject newExplotionAnim = GameObject.Instantiate(explotionAnim);
            //newExplotionAnim.transform.position = this.transform.position;

            GameObject newExplotion = GameObject.Instantiate(explotionRad);
            newExplotion.transform.position = spawn1.transform.position;

            GameObject newExplotion2 = GameObject.Instantiate(explotionRad);
            newExplotion2.transform.position = spawn2.transform.position;

            GameObject newExplotion3 = GameObject.Instantiate(explotionRad);
            newExplotion3.transform.position = spawn3.transform.position;

            exp = true;
            GameObject.Destroy(this.gameObject, 0.2f);
            GameObject.Destroy(newExplotion.gameObject, 2f);
            GameObject.Destroy(newExplotion2.gameObject, 2f);
            GameObject.Destroy(newExplotion3.gameObject, 2f);
        }
        else if (!exp && canon == true)
        {
            float damage = this.gameObject.GetComponent<DestructorComp>().damage;
            float life = collision.gameObject.GetComponent<DestroyableComp>().life -= damage;
            
            GameObject.Destroy(this.gameObject, 2f);
        }
    }
}
