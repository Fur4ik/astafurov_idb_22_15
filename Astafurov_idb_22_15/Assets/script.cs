using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public GameObject CUBE;
    private bool isObjectCreated = false;
    private GameObject deletedCube;

    void Start()
    {
        // Проверка наличия объекта при запуске сцены
        if (CUBE != null)
        {
            isObjectCreated = true;
        }
    }

    public void Button_click()
    {
        if (CUBE != null)
        {
            if (CUBE.transform.localScale == Vector3.one)
            {
                CUBE.transform.localScale = new Vector3(2, 2, 2);
            }
            else
            {
                CUBE.transform.localScale = Vector3.one;
            }
            Debug.Log("Button has been clicked");
        }
        else
        {
            Debug.LogError("CUBE object is not assigned!");
        }
    }

    public void ToggleObjectActivation()
    {
        if (CUBE != null)
        {
            // Проверяем состояние активации объекта и инвертируем его
            CUBE.SetActive(!CUBE.activeSelf);
            
            if (CUBE.activeSelf)
            {
                Debug.Log("Object activated");
            }
            else
            {
                Debug.Log("Object deactivated");
            }
        }
        else
        {
            Debug.LogError("CUBE object is not assigned!");
        }
    }
}
