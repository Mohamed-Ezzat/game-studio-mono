using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrellObstacle : MonoBehaviour
{
    public GameObject[] barrell_parts;
    public GameObject obstacle;
    public TMPro.TextMeshPro text;
    public int number;
    public Material[] mats;
    // Start is called before the first frame update
    void Start()
    {
        generate_barrell();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            decrease_barrell();
        }
    }

    public void generate_barrell()
    {
        obstacle.GetComponent<MeshRenderer>().material = mats[Random.Range(0, mats.Length)];

        number = Random.Range(10, 100);
        text.text = number.ToString();
        
    }

    public void decrease_barrell()
    {
        if (number != 1)
        {
            number--;
            text.text = number.ToString();
        }

        else
        {
            obstacle.SetActive(false);
            text.gameObject.SetActive(false);

            //sound
            SoundManager.instance.Play("barrell");

            for (int i = 0; i < barrell_parts.Length; i++)
            {
                barrell_parts[i].GetComponent<Rigidbody>().isKinematic = false;
                Vector3 tmp = new Vector3(Random.Range(-1, 1), Random.Range(1, 2), Random.Range(-1, 1));
                barrell_parts[i].GetComponent<Rigidbody>().AddForce(tmp * 10 , ForceMode.Impulse);
                Destroy(barrell_parts[i],2f);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            decrease_barrell();
        }
    }
}
