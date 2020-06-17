using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerMove : MonoBehaviour
{    
    [SerializeField]
    private float Speed;
    private Rigidbody2D _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Speed = 19;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        //transform.position = transform.position + new Vector3(x * Speed , y * Speed) * Time.deltaTime;

        _rigidbody.MovePosition(transform.position + new Vector3(x * Speed, y * Speed) * Time.deltaTime);
    }
}
