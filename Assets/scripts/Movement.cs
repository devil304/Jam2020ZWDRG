using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] Volume v;
    [SerializeField] float speed = 10;
    Rigidbody2D myRB2D;
    ColorAdjustments tmp;
    private void Start()
    {
        v.profile.TryGet<ColorAdjustments>(out tmp);
        myRB2D = GetComponent<Rigidbody2D>();
    }
    public void move(CallbackContext cc)
    {
        myRB2D.velocity = cc.ReadValue<Vector2>() * speed;
    }

    private void Update()
    {
        if (tmp)
        {
            tmp.saturation.value += Time.deltaTime * 20;
        }
    }
}
