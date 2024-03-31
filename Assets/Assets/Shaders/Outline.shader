Shader "Custom/OutlineShader"
{
    Properties
    {
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _Outline ("Outline width", Range (0.002, 0.03)) = 0.005
    }

CGINCLUDE
#include "UnityCG.cginc"
    ENDCG

    SubShader
    {
        Tags {"Queue"="Overlay" }
        Pass
        {
Cull Front

ZWrite On

ZTest LEqual

ColorMask RGB

Blend SrcAlpha
OneMinusSrcAlpha
            BlendOp
ReverseSubtract

            // Set up blending and draw the object's outline
            ColorMask
RGB
            Blend
SrcAlpha One

BlendOp Add

            // Draw the outline
            SetTexture[_MainTex]
            {
combine primary
            }

            SetTexture[_MainTex]
            {
combine add
                constantColor[_OutlineColor]
            }
        }
    }

    SubShader
    {
        Tags {"Queue"="Overlay" }
LOD100

        // Standard shader passes go here
    }
}