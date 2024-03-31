using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackPackInventory : MonoBehaviour
{
    public List<GameObject> BackPack = new List<GameObject>();
    public GameObject selector;
    public int ID;
    public Button useButton;
    public userController statesController;
    public int cantSandwiches = 3;
    public int cantBaterias = 1;
    public int cantAgua = 1;
    public int cantHojaCoca = 5;
    public int cantCerillos = 2;
    public int cantBengalas = 1;

   
    // Start is called before the first frame update
    void Start()
    {
        statesController = FindObjectOfType<userController>();
        useButton.onClick.AddListener(inventory);
    }


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

    

    void inventory()
    {
        if (ID == 0 && cantSandwiches != 0)//Comida
        {
            statesController.hambreActual -= 30;
            cantSandwiches--;
        }
        if (ID == 1 && cantBaterias != 0)//Bateria
        {
            if(statesController.bateriaActual > 0)
            {
                Debug.Log("Debes agotar tus baterías al 100 para poder recargarlas ");
            }
            if(statesController.bateriaActual == 0)
            {
                statesController.bateriaActual += 100;
                cantBaterias--;
            }
            
        }
        if (ID == 2 && cantAgua != 0)//Agua
        {
            statesController.hambreActual -= 20;
            cantAgua--;
        }
        if (ID == 3 && cantHojaCoca != 0)//Hoja coca
        {
            statesController.alturaActual -= 20;
            cantHojaCoca--;
        }
        if (ID == 4 && cantCerillos != 0)//Cerillos
        {
            cantCerillos--;
        }
        if (ID == 5 && cantBengalas != 0)//Bengala
        {
            cantBengalas--;
        }

        else
        {
            Debug.Log("No hay suficientes recursos");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Navegar();
    }
}
