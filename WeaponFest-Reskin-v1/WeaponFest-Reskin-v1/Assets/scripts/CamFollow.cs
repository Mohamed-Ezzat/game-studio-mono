
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 ofsset;
    public float speed;
    public bool is_active = true, is_final;
    public Transform final_pos;

    private void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ofsset = transform.position - target.position;

    }
    private void LateUpdate()
    {
        if (is_final)
        {
            if (final_pos == null)
                final_pos = GameObject.FindGameObjectWithTag("final_pos").transform;

            transform.position = Vector3.Lerp(transform.position, final_pos.position, 1f * Time.deltaTime);
            Quaternion rotateCam3 = Quaternion.Euler(38f, 0, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateCam3, .5f * Time.deltaTime);
        }
        if (!is_active)
            return;

        Vector3 distance = target.position + ofsset;
        distance.x = 0f;
        transform.position = Vector3.Lerp(transform.position, distance, speed * Time.smoothDeltaTime);
    }
    //private void Update()
    //{
    //    if (is_final)
    //    {
    //        if (final_pos == null)
    //            final_pos = GameObject.FindGameObjectWithTag("final_pos").transform;

    //        transform.position = Vector3.Lerp(transform.position, final_pos.position, 1f * Time.deltaTime);
    //        Quaternion rotateCam3 = Quaternion.Euler(38f, 0, 0);
    //        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateCam3, .5f * Time.deltaTime);
    //    }
    //    if (!is_active)
    //        return;

    //    Vector3 distance = target.position + ofsset;
    //    //distance.x = 0f;
    //    transform.position = Vector3.Lerp(transform.position, distance, speed * Time.deltaTime);
    //}
}
