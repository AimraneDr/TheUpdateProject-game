using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_saple_controller : MonoBehaviour
{

    public CharacterController PlayerCharController;
    public Transform cam;
    #region movement properties
    public float speed = 6;
    public float TurnSmoothTime = 0.1f;
    float TurnSmoothVelocity;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalValue = Input.GetAxisRaw("Horizontal");
        float VerticalValue = Input.GetAxisRaw("Vertical");
        Vector3 Direction = new Vector3(HorizontalValue, 0, VerticalValue).normalized;

        if (Direction.magnitude >= 0.1f)
        {
            float DirAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, DirAngle, ref TurnSmoothVelocity, TurnSmoothTime);
            Vector3 moveDir = Quaternion.Euler(0f, DirAngle, 0f) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            PlayerCharController.Move(moveDir.normalized * speed * Time.deltaTime);
        }
       
    }

    
}
