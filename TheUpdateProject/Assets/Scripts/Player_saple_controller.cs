using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_saple_controller : MonoBehaviour
{

    public CharacterController PlayerCharController;

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

        if(Direction.magnitude >= 0.1f)
        {
            float DirAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, DirAngle, ref TurnSmoothVelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            PlayerCharController.Move(Direction * speed * Time.deltaTime);
        }
       
    }

    
}
