using UnityEngine;

public class BlockTarget : MonoBehaviour
{
    Transform wall;
    Transform water;
    Transform fldsmdfr;
    float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        fldsmdfr = gameObject.transform.GetChild(0);
        wall = gameObject.transform.GetChild(1);
        water = gameObject.transform.GetChild(2);

    }

    public void DisableWall()
    {
        wall.gameObject.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BulletP"))
        {
            water.gameObject.SetActive(true);

            Invoke("DisableWall", 2);
        }
    }
}
