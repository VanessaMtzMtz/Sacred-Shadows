using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPackInventory : MonoBehaviour
{
    public List<GameObject> BackPack = new List<GameObject>();
    public GameObject selector;
    public int ID;

    public void Navegar()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && ID < BackPack.Count - 1)
        {
            ID++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && ID > 0)
        {
            ID--;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && ID >= 3)
        {
            ID -= 3;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && ID < 3)
        {
            ID += 3;
        }
        selector.transform.position = BackPack[ID].transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Navegar();
    }
}
