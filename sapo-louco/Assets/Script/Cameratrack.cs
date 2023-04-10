using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cameratrack : MonoBehaviour
{
    public GameObject alvo;
    public float velocidade;

    void Update()
    {
        
        Vector3 posicaoAlvo = new Vector3(alvo.transform.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, posicaoAlvo, velocidade * Time.deltaTime);

    }
}
