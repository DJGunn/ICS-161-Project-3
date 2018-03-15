using UnityEngine;
using System.Collections;

public class CloudScroller : MonoBehaviour {

    public float scrollSpeed;

    private Vector2 originalScale;

    void Start()
    {
        originalScale = transform.localScale;

        transform.position = new Vector2(Random.Range(-9f,9f), Random.Range(0f, 4f));
        scrollSpeed = Random.Range(.5f, 2f);
        transform.localScale = originalScale + new Vector2( Random.Range(-.05f, .05f), Random.Range(-.05f, .05f));
    }

    void Update()
    {
        transform.Translate(Time.deltaTime * scrollSpeed * Vector2.left);

        if (transform.position.x < -13f) resetCloud();
    }


    private void resetCloud()
    {
        transform.position = new Vector2(13, Random.Range(0f, 4f));
        scrollSpeed = Random.Range(.5f, 2f);
        transform.localScale = originalScale + new Vector2(Random.Range(-.05f, .05f), Random.Range(-.05f, .05f));
    }
}
