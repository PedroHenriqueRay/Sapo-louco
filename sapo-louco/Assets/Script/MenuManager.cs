using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class MenuManager : MonoBehaviour
{
    private int seletor;
    private float duration = 0.5f;

    public GameObject[] marquer;
    public GameObject[] books;

    private void Start()
    {
        seletor = 1;
        print("lll");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Left")) 
        {
            if (seletor == 1)
                return;
            seletor--;
        }
        else if(Input.GetButtonDown("Right"))
        {
            if (seletor == 4)
                return;
            seletor++;
        }


        //activate menus 
        switch (seletor)
        {
            case 1:
                SubirMarquer(marquer[0], marquer[1], marquer[3]);
                booksActivate(books[0], books[1], books[2], books[3]);
                break;
            case 2:
                SubirMarquer(marquer[1], marquer[2], marquer[0]);
                booksActivate(books[1], books[0], books[2], books[3]);
                break;
            case 3:
                SubirMarquer(marquer[2], marquer[3], marquer[1]);
                booksActivate(books[2], books[1], books[0], books[3]);
                break;
            case 4:
                SubirMarquer(marquer[3], marquer[2], marquer[1]);
                booksActivate(books[3], books[1], books[2], books[0]);
                break;
        }
    }

    public void SubirMarquer(GameObject go,GameObject in1, GameObject in2)
    {
        go.transform.DOLocalMoveY(470, duration);
        in1.transform.DOLocalMoveY(435, duration);
        in2.transform.DOLocalMoveY(435, duration);
    }

    public void booksActivate(GameObject on,GameObject off1,GameObject off2,GameObject off3)
    {
        on.SetActive (true);
        off1.SetActive (false);
        off2.SetActive(false);
        off3.SetActive(false);
    }
}
