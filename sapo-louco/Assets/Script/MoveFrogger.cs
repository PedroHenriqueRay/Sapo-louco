using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveFrogger : MonoBehaviour
{

    //VARIAVEIS DE MOVIMENTO
    private float hori,verti;
    private float speed;
    private bool coolingDown;
    private Animator playerAn;
    private bool fliped;
    private int backfrog = -1;

    //atributos do sprite
    public GameObject charMesh;
    private SpriteRenderer sr;
    private Animator an;

    int acLife; 

    private void Start()
    {
        an = charMesh.GetComponent<Animator>();
        sr = charMesh.GetComponent<SpriteRenderer>();
        playerAn = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //

        //print(acLife);

        //Declaração das variaveis
        hori = Input.GetAxis("Horizontal");
        verti = Input.GetAxis("Vertical");

        if(coolingDown == false)
        {

            if (Input.GetButtonDown("Horizontal"))
            {
                if(hori>0)
                {
                    // block do canto direito da tela
                    if (ScriptGame.blockDir)
                        return;
                    if (fliped == true)
                    {
                        playerAn.SetTrigger("flipDir");
                    }
                    StartCoroutine(Move(new Vector3(Mathf.Sign(hori) * 5, 0, 0)));

                    fliped = false;
                    backfrog = -1;
                }
                else if (hori<0)
                {
                    // block do canto esquerdo da tela
                    if (ScriptGame.blockEsq)
                        return;
                    if (fliped == false)
                    {
                        playerAn.SetTrigger("flipEsq");
                    }
                    //pulo
                    StartCoroutine(Move(new Vector3(Mathf.Sign(hori) * 5, 0, 0)));

                    fliped = true;

                    backfrog = 1;
                }
            }
            else if (Input.GetButtonDown("Vertical"))
            {
                if (verti>0)
                {
                    if (transform.position.z >= 1)
                        return;
                    StartCoroutine(Move(new Vector3(0, 0, Mathf.Sign(verti) * 3)));
                }
                else if(verti<0)
                {
                    if (transform.position.z <= -1)
                        return;
                    StartCoroutine(Move(new Vector3(0, 0, Mathf.Sign(verti) * 3)));
                }
            }



            if (Input.GetButtonDown("Fire3")) 
            {
                StartCoroutine(Dogde(new Vector3(backfrog * 2, 0,0)));
            }
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {      
        if(collision.gameObject.layer == LayerMask.NameToLayer("Damage"))
        {
        }
    }

    private IEnumerator Dogde(Vector3 delta)
    {
        coolingDown = true;
        var start = transform.position;
        var end = start + delta;
        float time = 0f;
        float cooldown = 0.3f; // quanto menor mais rapido

        while (time < 1f)
        {
            transform.position = Vector3.Lerp(start, end, time);
            time = time + Time.deltaTime / cooldown;
            yield return null;
        }
        transform.position = end;

        coolingDown = false;
    }

    private IEnumerator Move(Vector3 delta)
    {
        coolingDown = true;
        an.SetTrigger("Jump");
        var start = transform.position;
        var end = start + delta;
        float time = 0f;
        float cooldown = 1f; // quanto menor mais rapido

        while ( time < 1f)
        {
            transform.position = Vector3.Lerp(start,end,time);
            time = time + Time.deltaTime / cooldown;
            yield return null;
        }
        transform.position = end;

        coolingDown = false;
    }

}
