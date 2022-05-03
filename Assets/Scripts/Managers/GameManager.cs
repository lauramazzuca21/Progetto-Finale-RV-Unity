using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.isEditor)
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("SteamVR"))
                g.SetActive(true);

        _ = StartCoroutine(ActivatePlayerInput());
    }

    private IEnumerator ActivatePlayerInput()
    {
        yield return new WaitForSeconds(1);
        Classes.Message msg1 = new Classes.Message();
        Classes.Message msg2 = new Classes.Message();
        Classes.Message msg3 = new Classes.Message();
        msg1.title = msg2.title = msg3.title = "ALCADESA";
        msg1.message = "¡Buenos días! Gracias por venir a nuestra ciudad, te estaba esperando.\nLos habitantes de este lugar necesitan tu ayuda para completar su trabajo.";
        msg2.message = "Esparcidos entre la basura hay unos cuantos objetos que tendrás que recoger, poner en tu inventario y llevárselos, verás que sabrán agradecértelo.";
        msg3.message = "Intenta también recoger y reciclar la mayor cantidad de basura posible de forma correcta, para que puedas contribuir a embellecer aún más esta ciudad.";

        EventManager.FireDisplayMessageOnPanel(msg1, 4);
        EventManager.FireDisplayMessageOnPanel(msg2, 4);
        EventManager.FireDisplayMessageOnPanel(msg3, 4);

    }
}
