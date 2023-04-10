using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGame : MonoBehaviour
{
    bool ativado;
    public Vector3 inicio = new Vector3(10, 10, 10);

    [Header("Player Settings")]
    public GameObject jogador;
    public GameObject cam;
    public Transform limiteDir,limiteEsq;
    public static bool blockDir,blockEsq = false;

    [Header("Menu OBJ")]
    public GameObject pause;
    public GameObject book;
    bool activate;

    public void Start()
    {
        book.SetActive(false);
        pause.SetActive(false);
    }


    public void Update()
    {
        float distDir = Vector3.Distance(jogador.transform.position,limiteDir.position);
        float distEsq = Vector3.Distance(jogador.transform.position,limiteEsq.position);
        
        if(distDir <= 3) 
        {
            blockDir = true;
        }
        else
        {
            blockDir = false;
        }

        if(distEsq <= 3)
        {
            blockEsq = true;
        }
        else
        {
            blockEsq = false;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            act(book);
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            act(pause);
        }

    }


    private void act(GameObject obj)
    {
        if(activate == false)
        {
            obj.SetActive(true);
            activate = true;
        }
        else if(activate == true)
        {
            obj.SetActive(false);
            activate = false;
        }
    }
}
