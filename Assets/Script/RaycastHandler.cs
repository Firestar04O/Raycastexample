using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    [Header("Raycast properties")]
    [SerializeField] private Transform _origin;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _layermask;

    [Header("Draw Properties")]
    [SerializeField] private Color colorColliding = Color.white;
    [SerializeField] private Color colorNotColliding = Color.white;
    private void Update()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        DoRaycast(_direction);
    }
    public void DoRaycast(Vector2 direction)
    {
        _direction = direction;

        RaycastHit2D hit = Physics2D.Raycast(_origin.position, _direction, _distance, _layermask);

        if (hit.collider != null)
        {
            Debug.DrawRay(_origin.position, _direction * hit.distance, colorColliding);
            Debug.Log("Nombre: " + hit.collider.gameObject.name);
            Debug.Log("Posición: " + hit.collider.gameObject.transform.position);
            Debug.Log("Tag: " + hit.collider.gameObject.tag);
            if(hit.collider.gameObject.tag == "Shape")
            {
                Debug.Log("Se cambiará la forma a: " + hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite);
            }
            else if(hit.collider.gameObject.tag == "Color")
            {
                Debug.Log("Se cambiará el color a: " + hit.collider.gameObject.GetComponent<SpriteRenderer>().color);
            }
        }
        else
        {
            Debug.DrawRay(_origin.position, _direction * _distance, colorNotColliding);
        }
    }
}
