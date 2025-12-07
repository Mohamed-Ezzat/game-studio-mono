
using UnityEngine;

public class WallObstacle : MonoBehaviour
{
    public GameObject[] wall_parts;
    public GameObject obstacle;
    public TMPro.TextMeshPro text;
    public int number;

    // Start is called before the first frame update
    void Start()
    {
        generate_wall();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            decrease_wall();
        }
    }

    public void generate_wall()
    {

        number = Random.Range(10, 100);
        text.text = number.ToString();

    }


    public void decrease_wall()
    {
        if (number != 1)
        {
            number--;
            text.text = number.ToString();
        }

        else
        {
            text.gameObject.SetActive(false);
            obstacle.SetActive(false);

            //sound
            SoundManager.instance.Play("wall");

            for (int i = 0; i < wall_parts.Length; i++)
            {
                wall_parts[i].GetComponent<Rigidbody>().isKinematic = false;
                Vector3 tmp = new Vector3(Random.Range(-2, 2), Random.Range(1, 2), Random.Range(1, 5));
                wall_parts[i].GetComponent<Rigidbody>().AddForce(tmp * 10, ForceMode.Impulse);
                Destroy(wall_parts[i], 1.5f);
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bullet")
        {
            print("azz");
        }
    }
}
