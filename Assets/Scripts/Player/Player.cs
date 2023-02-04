using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IShopCustomer
{
    public static Player instance { get; private set; }
    public Animator anim;

    private Rigidbody2D rb;
    public float movementSpeed = 10.0f;
    Vector2 movement;

    public bool isFacingRight = true;
    public bool isFacingLeft;
    public bool isFacingUp;
    public bool isFacingDown;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // this needs to be fired for results to show up on UI screen
    public event EventHandler OnFruitAmountChanged;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    public void BoughtItem(ShopItems.ShopItemType shopItemType)
    {
        // if bought, set the item on the player
        if (shopItemType == ShopItems.ShopItemType.SpoonItem)
        {
            anim.SetBool("isSpoon", true);
        }
        else if (shopItemType == ShopItems.ShopItemType.BlenderItem)
        {
            anim.SetBool("isBlender", true);
        }
        else if (shopItemType == ShopItems.ShopItemType.WhiskItem)
        {
            anim.SetBool("isWhisk", true);
           
        }
        else if (shopItemType == ShopItems.ShopItemType.HealthItem)
        {
            // fill up a certain amount of the player or the shop's health
        }
    }

    private void Attack()
    {
        if (anim.GetBool("isSpoon") == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("attackSpoon", true);

                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<EnemyAI>().TakeDamage(attackDamage);
                }
            }
        }
        else if (anim.GetBool("isWhisk") == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("attackWhisk", true);

                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<EnemyAI>().TakeDamage(attackDamage);
                }
            }
        }
        else if (anim.GetBool("isBlender") == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("attackBlender", true);

                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<EnemyAI>().TakeDamage(attackDamage);
                }
            }
        }
    }

    public int GetFruitAmount()
    {
        return 0;
    }

    public int GetFruitType()
    {
        int type = 0;
        return type;
    }

    public bool TrySpendJuiceAmount(int spendJuiceAmount)
    {
      // if you have more gold than what the item is worth, spend it
      return false;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        CheckMovementDirection();
        Attack();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    private void CheckMovementDirection()
    {
        if (isFacingRight && movement.x < 0)
        {

        }
    }

    
}
