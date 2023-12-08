using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class Move_main : MonoBehaviour
{
    public float MoveSpeedWalk = 5f;
    public float MoveSpeedRun = 5f;
    public bool CanJump = true;
    public float JumpForce = 7f;
    public bool IsGround;
    public Transform GroundCheck;
    public float CheckRadius = 0.5f;
    public LayerMask Ground;
    

    private Camera MainCamera;

    private Animator Animator;
    public Animator Anim;
    public bool CanRun = true;
    public bool IsRolling = false;
    public bool IsMove = true; 
    public float waitsecondRoll = 2f;
    TestAttackscript comboAttack;
    StaminaBar stamina;
    Rigidbody rb;


    void Start()
    {

        MainCamera = Camera.main;
        Animator = GetComponent<Animator>();
        Anim = gameObject.GetComponent<Animator>();
        comboAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<TestAttackscript>();
        stamina = GameObject.FindGameObjectWithTag("Player").GetComponent<StaminaBar>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {


        if (IsMove)
        {
            Move();
            stamina.IncreasedStamina(0.1f);
        }

        if (!IsRolling && Input.GetKeyDown(KeyCode.Space))
        {
            // Запустите Roll переката
            //isMove = false;
            stamina.DecreasedStamina(15f);
            StartCoroutine(Roll());
        }

        Jump();
        
    }


    public void Move()
    {

        // Получаем вектор направления относительно камеры
        Vector3 cameraForward = MainCamera.transform.forward;
        Vector3 cameraRight = MainCamera.transform.right;

        // Игнорируем y-компоненты, чтобы движение было только по горизонтали
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Получаем ввод от пользователя
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Вычисляем направление движения на основе ввода и направления камеры
        Vector3 moveDirection = cameraForward * verticalInput + cameraRight * horizontalInput;
        if (moveDirection.magnitude > Mathf.Abs(0.01f)) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * 500f);
        // Нормализуем направление движения, чтобы избежать ускорения при движении по диагонали
        moveDirection.Normalize();

        // Перемещаем персонаж в заданном направлении
        Animator.SetFloat("speed", Vector3.ClampMagnitude(moveDirection, 0.2f).magnitude);
        transform.Translate(moveDirection * MoveSpeedWalk * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.LeftControl) && CanRun)
        {
            stamina.DecreasedStamina(0.2f);
            Animator.SetFloat("speed", Vector3.ClampMagnitude(moveDirection, 1).magnitude);
            transform.Translate(moveDirection * (MoveSpeedWalk + MoveSpeedRun) * Time.deltaTime, Space.World);


        }
    }


    IEnumerator Roll()
    {
        IsRolling = true;
        gameObject.GetComponent<Animator>().SetTrigger("Rolls");

        yield return new WaitForSeconds(waitsecondRoll); // Подождите 1 секунду (время анимации)

        IsRolling = false; // Снимаем флаг после окончания анимаци



    }

    public void Jump()
    {
        CheckingGround();

        if (Input.GetKeyDown(KeyCode.LeftShift)&& IsGround && CanJump)
        {
           
            Anim.SetTrigger("OnGround");
            //anim.SetBool("OnGroundB", true);
            //rb.velocity = new Vector3(rb.velocity.y, jumpForce);
            rb.AddForce(Vector3.up * JumpForce);
            print(rb.position);
        }
    }

    public float rayLength = 100f;
    public float capsuleHeight = 0.1f; // Высота капсулы
    public float capsuleRadius = 0.5f; // Радиус капсулы
    public LayerMask groundedLayer;
    public void CheckingGround() 

    {

        Vector3 rayStart = transform.position;
        Vector3 rayDirection = Vector3.down;
         
        RaycastHit hit;
        if (Physics.Raycast(rayStart, rayDirection, out hit, rayLength, groundedLayer))
        {
            IsGround = true;
            
        }
        else
        {

            IsGround = false;
          
        }
    }
}
    