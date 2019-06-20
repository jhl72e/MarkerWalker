using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public SpriteRenderer spriteBounds;
    public Transform target;
    public float moveSpeed;

    private Vector3 goalPosition;

    private float leftBound, rightBound, bottomBound, topBound;

    void Start()
    {
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        leftBound = (float)(horzExtent - spriteBounds.sprite.bounds.size.x / 2f);
        rightBound = (float)(spriteBounds.sprite.bounds.size.x / 2f - horzExtent);
        bottomBound = (float)(vertExtent - spriteBounds.sprite.bounds.size.y / 2f);
        topBound = (float)(spriteBounds.sprite.bounds.size.y / 2f - vertExtent);
    }

    void Update()
    {
        goalPosition.x = Mathf.Clamp(target.position.x, leftBound, rightBound);
        goalPosition.y = Mathf.Clamp(target.position.y, bottomBound, topBound);
        goalPosition.z = -10f;

        transform.position = Vector3.Lerp(transform.position, goalPosition, moveSpeed * Time.deltaTime);
    }
}
