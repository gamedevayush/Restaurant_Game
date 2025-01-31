Shader "UI/BlurWithHole"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _BlurSize("Blur Size", Range(0, 10)) = 2
        _ClearArea("Clear Area", Vector) = (0, 0, 1, 1)
        _Alpha("Alpha", Range(0, 1)) = 1 // Alpha control for overall transparency
    }
        SubShader
        {
            Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
            LOD 100

            Pass
            {
                ZWrite Off
                Blend SrcAlpha OneMinusSrcAlpha
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float _BlurSize;
                float4 _ClearArea;
                float _Alpha; // Overall alpha control

                struct appdata_t
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    float2 uv = i.uv;

                    // Check if UV is inside the clear area
                    if (uv.x > _ClearArea.x && uv.x < _ClearArea.z && uv.y > _ClearArea.y && uv.y < _ClearArea.w)
                    {
                        return fixed4(0, 0, 0, 0); // Fully transparent in the clear area
                    }

                    // Apply blur effect outside the clear area
                    float2 offset = float2(_BlurSize / _ScreenParams.x, _BlurSize / _ScreenParams.y);
                    fixed4 color = fixed4(1,1,1,1);
                    color += tex2D(_MainTex, uv + offset * float2(-1, -1)) * 0.0625;
                    color += tex2D(_MainTex, uv + offset * float2(-1,  0)) * 0.125;
                    color += tex2D(_MainTex, uv + offset * float2(-1,  1)) * 0.0625;
                    color += tex2D(_MainTex, uv + offset * float2(0, -1)) * 0.125;
                    color += tex2D(_MainTex, uv + offset * float2(0,  0)) * 0.25;
                    color += tex2D(_MainTex, uv + offset * float2(0,  1)) * 0.125;
                    color += tex2D(_MainTex, uv + offset * float2(1, -1)) * 0.0625;
                    color += tex2D(_MainTex, uv + offset * float2(1,  0)) * 0.125;
                    color += tex2D(_MainTex, uv + offset * float2(1,  1)) * 0.0625;

                    color.a *= _Alpha;
                    color.r *= 0;
                    color.g *= 0;
                    color.b *= 0;


                    return color;
                }
                ENDCG
            }
        }
}
