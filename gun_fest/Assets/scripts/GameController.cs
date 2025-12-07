using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject start_module;
    public GameObject devil;
    public GameObject[] modules;
    public int distance;
    public int increase;

    public Material[] mat;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = mat[Random.Range(0, mat.Length)];
        generate_level();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generate_level()
    {
        // instantiate start module
        Vector3 tmp = Vector3.zero;
        tmp.y = start_module.transform.position.y;
        tmp.z = distance;

        distance += increase;

        Instantiate(start_module, tmp, start_module.transform.rotation);

        // instantiate modules and devil

        for (int i = 0; i < 4; i++)
        {

            if(i != 3)
            {
                int rdm = Random.Range(0, modules.Length);
                tmp.y = modules[rdm].transform.position.y;
                tmp.z = distance;

                GameObject go =  Instantiate(modules[rdm], tmp, modules[rdm].transform.rotation);

                for (int j = 0; j < go.transform.childCount; j++)
                {
                    

                    Vector3 tmp2 = go.transform.GetChild(j).transform.position;
                    tmp2.z = distance;
                    go.transform.GetChild(j).transform.position = tmp2;

                    distance += increase;
                }
            }
            else
            {
                if(GameManager.instance.get_devil_count() >= 4)
                {
                    GameManager.instance.set_devil_count(0);

                    tmp.y = devil.transform.position.y;
                    tmp.z = distance + 50;

                    Instantiate(devil, tmp, devil.transform.rotation);
                }
                else
                {
                    GameManager.instance.set_devil_count(GameManager.instance.get_devil_count() + 1);

                    int rdm = Random.Range(0, modules.Length);
                    tmp.y = modules[rdm].transform.position.y;
                    tmp.z = distance;

                    GameObject go = Instantiate(modules[rdm], tmp, modules[rdm].transform.rotation);

                    for (int j = 0; j < go.transform.childCount; j++)
                    {


                        Vector3 tmp2 = go.transform.GetChild(j).transform.position;
                        tmp2.z = distance;
                        go.transform.GetChild(j).transform.position = tmp2;

                        distance += increase;
                    }
                }
            }
        }
    }
}
