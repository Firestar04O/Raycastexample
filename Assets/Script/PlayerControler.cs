using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    
    SpriteRenderer _myspriterenderer;
    Rigidbody2D _rigidbody;

    [Header("Movement Components")]
    [SerializeField] public Vector2 _movementdirection;
    [SerializeField] private float speed;

    [Header("Other components")]
    [SerializeField]private RaycastHandler raycasthandler;
    
    float Horizontal;
    float Vertical;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _myspriterenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        _movementdirection = new Vector2(Horizontal, Vertical);
        _rigidbody.velocity = _movementdirection * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Shape")
        {
            _myspriterenderer.sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
        }
        if (collision.tag == "Color")
        {
            _myspriterenderer.color = collision.gameObject.GetComponent<SpriteRenderer>().color;
        }
    }
}
