using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootColorChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color transitionColor;
    private Color startingColor;

    [SerializeField] private float transitionSpeed = 1f;
    private float transitionValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        startingColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = Color.Lerp(startingColor, transitionColor, transitionValue);

        transitionValue += transitionSpeed * Time.deltaTime;

        if (transitionValue > 1f)
        {
            spriteRenderer.color = transitionColor;
            this.enabled = false;
        }
    }
}
