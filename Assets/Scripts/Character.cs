﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected float speed;
    protected Vector2 direction;
    //protected Vector2 directionMouse;
    protected Rigidbody2D myRigidbody;
    protected Animator animator;
    protected bool isAttacking = false;
    protected Coroutine attackRoutine;
   
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        // pega os componentes especificos //
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        direction = Vector2.zero;
        ComputeVelocity(); 
       
        //HandleLayers();
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        // muda a posição do personagem //
        myRigidbody.velocity = new Vector2(direction.x * speed, myRigidbody.velocity.y);
    }
    protected virtual void ComputeVelocity()
    {

    }
  
    public void ActivateLayer(string layerName) // ativa a animação expecifica //
    {
        for (int i = 0;i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }
        animator.SetLayerWeight(animator.GetLayerIndex(layerName), 1);
    }
    public void StopAttack()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            isAttacking = false;
            animator.SetBool("Attack", isAttacking);

        }
    }
    //public Vector2 retornarVetor()
    //{
        //return directionMouse;
    //}
    public Animator retornarAnimator()
    {
        return animator;
    }

    public void TakeDamage(int damage)
    {
        print("ele tomou" + damage);
    }
}

