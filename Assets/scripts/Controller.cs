using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Movement))]
public class Controller : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] InputActionMap myMap;
    void Start () {
        myMap.FindAction("Move").performed += (obj) =>
        {
            //movevect = obj.ReadValue<Vector2>();
        };
    }

    // Update is called once per frame
    void Update () {

    }
}

