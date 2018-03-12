using UnityEngine;

public class Walking : MonoBehaviour {

    public float horizontalSpeed = 1f;
    public float verticalSpeed = 1f;

    public Animator anim;
    public Rigidbody rbody;

    private float inputH;
    private float inputV;
    private bool run;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        run = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            anim.Play("WALK00_F", -1, 0f);
        }

        if (Input.GetKeyDown("s"))
        {
            anim.Play("WALK00_B", -1, 0f);
        }

        if (Input.GetKeyDown("a"))
        {
            anim.Play("WALK00_L", -1, 0f);
        }

        if (Input.GetKeyDown("d"))
        {
            anim.Play("WALK00_R", -1, 0f);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * horizontalSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * verticalSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;

        rbody.velocity = new Vector3(moveX, 0f, moveZ);

    }
}
