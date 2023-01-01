using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallColorSetter : MonoBehaviour
{
    public Renderer renderer;
    public Color32 currentColor;
    [SerializeField] private List<Color32> colors;
    [SerializeField] private Ball ball;

    private MaterialPropertyBlock propertyBlock;

    private void Start()
    {
        if (ball.BallType != BallType.InstantiatorBall) return;
        Color randomColor = colors[Random.Range(0, colors.Count - 1)];
        currentColor = randomColor;
        SetPropertyColor(currentColor);
    }

    public void SetPropertyColor(Color color)
    {
        propertyBlock ??= new MaterialPropertyBlock();
        propertyBlock.SetColor("_Color", color);
        renderer.SetPropertyBlock(propertyBlock);
    }
}