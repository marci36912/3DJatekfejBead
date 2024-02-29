using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool w, a, s, d, scrollwheel;
    private Vector3 rotation;
    void Start()
    {
        rotation = new Vector3(0,0,0);
    }

    void Update()
    {
        getmovement();        
    }

    void FixedUpdate()
    {
        move();
    }

    private void getmovement()
    {
        w = Input.GetKey(KeyCode.W);
        a = Input.GetKey(KeyCode.A);
        s = Input.GetKey(KeyCode.S);
        d = Input.GetKey(KeyCode.D);
        scrollwheel = Input.GetKey(KeyCode.Mouse2);
    }

    private void move()
    {
        if(w)
        {
            transform.position += (transform.forward * speed);
        }
        if(s)
        {
            transform.position += (-transform.forward * speed);
        }
        if(a)
        {
            transform.position += (-transform.right * speed);
        }
        if(d)
        {
            transform.position += (transform.right * speed);
        }

        if(scrollwheel)
        {
            rotation.y = Input.GetAxis("Mouse X");
            transform.Rotate(rotation);
        }
    }
}
