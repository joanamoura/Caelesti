﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MovimentoP2 : MonoBehaviour {

	private Rigidbody2D rb;
	private Transform tr;
	private Animator an;
	public Transform verificaChao;
	public Transform verificaParede;

	private bool estaAndando;
	private bool estaNoChao;
	private bool estaNaParede;
	private bool estaVivo;
	private bool viradoParaDireita;

	private float axis;
	public float velocidade;
	public float forcaPulo;
	public float raioValidaChao;
	public float raioValidaParede;

	public LayerMask solido;

	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		tr = GetComponent<Transform> ();
		an = GetComponent<Animator> ();

		estaVivo = true;
		viradoParaDireita = true;
	}

	void Update (){

		estaNoChao = Physics2D.OverlapCircle(verificaChao.position, raioValidaChao,solido);
		estaNaParede = Physics2D.OverlapCircle (verificaParede.position, raioValidaParede,solido);

		if (estaVivo){

			axis = Input.GetAxisRaw ("Horizontal1");

			estaAndando = Mathf.Abs (axis) > 0f;

			if (axis > 0f && !viradoParaDireita)
				Flip();
			else if (axis < 0f && viradoParaDireita)
				Flip();

			if(Input.GetButtonDown ("Jump1") && estaNoChao)
				rb.AddForce (tr.up * forcaPulo);

		}
	}
		
	void FixedUpdate() 
	{

		if (estaAndando && !estaNaParede) {
			if (viradoParaDireita)
				rb.velocity = new Vector2 ( velocidade, rb.velocity.y);
			else 
				rb.velocity = new Vector2 (- velocidade, rb.velocity.y);

		}
	}
		
	void Flip () {
		viradoParaDireita = !viradoParaDireita;
		tr.localScale = new Vector2 ( -tr.localScale.x , tr.localScale.y);


	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;

		Gizmos.DrawWireSphere(verificaChao.position, raioValidaChao);
		Gizmos.DrawWireSphere(verificaParede.position, raioValidaParede);

	}
}


