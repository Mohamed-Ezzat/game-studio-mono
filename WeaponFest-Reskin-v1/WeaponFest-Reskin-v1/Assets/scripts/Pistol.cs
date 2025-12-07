using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Transform pos_bullet;
    public float speed_bullet;
    public GameObject bullet_pref;
    Player pl;

    float counter , cnt;
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        counter = Random.Range(.1f, .4f);

        pl = FindObjectOfType<Player>();
        //StartCoroutine(shoot_bullet());

        //GameObject go = new GameObject();
        //go.name = "pos";

        //go.transform.parent = transform;
        //go.transform.localPosition = new Vector3(0,.72f,.77f);
        //pos_bullet = go.transform;
    }

    private void Update()
    {
        if(pl.gamerun)
        {
            if (cnt >= counter)
            {
                cnt = 0;
                counter = Random.Range(.1f, .4f);
                if (active)
                {

                    GameObject go = Instantiate(bullet_pref, pos_bullet.position, pos_bullet.transform.rotation);

                    go.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed_bullet, ForceMode.Impulse);
                }
            }
            else
            {
                cnt += Time.deltaTime;
            }
        }
            
    }



    //public IEnumerator shoot_bullet()
    //{
    //    while (pl.gamerun)
    //    {
    //        float tm = Random.Range(.1f, .4f);
    //        yield return new WaitForSeconds(tm);
    //        if (active)
    //        {
    //            print(gameObject.name);
                
    //            GameObject go = Instantiate(bullet_pref, pos_bullet.position, pos_bullet.transform.rotation);

    //            go.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed_bullet, ForceMode.Impulse);
    //        }
            
    //    }
    //}
}
