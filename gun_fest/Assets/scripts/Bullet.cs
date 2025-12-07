using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "wall")
        {
            Destroy(gameObject);
            other.transform.parent.gameObject.GetComponent<WallObstacle>().decrease_wall();
        }
        else if (other.tag == "barrell")
        {
            Destroy(gameObject);
            other.transform.parent.gameObject.GetComponent<BarrellObstacle>().decrease_barrell();
        }
        else if (other.tag == "enemy")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Enemy>().enemy_death();
            //other.gameObject.GetComponent<Enemy>().active = false;
        }
        else if (other.tag == "devil")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<DevilEnemy>().enemy_death();
        }
        else if (other.tag == "car")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Car>().decrease_car();
        }


    }
}
