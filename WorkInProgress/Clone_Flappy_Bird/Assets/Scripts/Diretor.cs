using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Diretor : MonoBehaviour
{
    [SerializeField]
    private GameObject  imagemGameOver;
    private aviao aviao;
    private Pontuacao pontuacao;
    private AudioSource audioGameOver;
    private float tempoParaAcelerar;

private void Awake() {
    this.audioGameOver = this.GetComponent<AudioSource>();
    this.tempoParaAcelerar = 6;

}
    private void Start(){
        this.aviao = GameObject.FindObjectOfType<aviao>();  
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    private void Update() {
        this.tempoParaAcelerar -= Time.deltaTime;
        if (this.tempoParaAcelerar < 0) {
            Time.timeScale += 0.1f;
            Debug.Log(Time.timeScale);
            this.tempoParaAcelerar = 6;
        };
    }
   public void FinalizarJogo() {
        Time.timeScale = 0;
        this.imagemGameOver.SetActive(true);
        this.audioGameOver.Play();
   }

   public void ReiniciarJogo() {

        this.imagemGameOver.SetActive(false);
        Time.timeScale = 1;
        this.aviao.Reiniciar();
        this.destruirObstaculos();
        this.pontuacao.Reiniciar();
   }

   private void destruirObstaculos() {
       Obstaculo[] obstaculos = GameObject.FindObjectsOfType<Obstaculo>();
       foreach(Obstaculo obstaculo in obstaculos) {
            obstaculo.Destruir();
       }
   }

   
}
