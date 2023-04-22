using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   public float moveSpeed = 5.0f; // 이동 속도
    public FixedJoystick joystick; // 가상 조이스틱 참조

    public SpriteRenderer playerSprite;
    public GameObject endUI;
    private void Update()
    {
        // 이동 처리
        float horizontalMovement = joystick.Horizontal * moveSpeed * Time.deltaTime;
        transform.Translate(horizontalMovement, 0, 0);

        playerSprite.flipX = joystick.Horizontal >= 0 ? false : true;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(!other.CompareTag("Capsule"))
          return;

        endUI.SetActive(true);
        other.gameObject.SetActive(false);
    }
}
