using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Obstaculo : MonoBehaviour
{
    [SerializeField]
    private float variacaoDaPosicaoY;
    private UnityEngine.Vector3 posicaoDoAviao;
    private Pontuacao pontuacao;
    private bool pontuei;
    private void Awake (){
        
        this.transform.Translate(UnityEngine.Vector3.up * Random.Range(-variacaoDaPosicaoY,variacaoDaPosicaoY));
    }
    
    private void Start() {
        this.posicaoDoAviao = GameObject.FindObjectOfType<aviao>().transform.position;
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }
    [SerializeField]
    private float velocidade = 0.05f;
    private void Update() {
        this.transform.Translate(UnityEngine.Vector3.left * this.velocidade * Time.deltaTime);
        
        if(!this.pontuei && this.transform.position.x < this.posicaoDoAviao.x) {

            this.pontuei = true;
            this.pontuacao.AdicionarPontos();
            
        }
    }
    private void OnTriggerEnter2D(Collider2D outro) {
        this.Destruir();
    }

    public void Destruir() {
        GameObject.Destroy(this.gameObject);
    }
}


  