Shader "Custom/ShowIfHidden" {
    Properties{
        _MainTex("Texture", 2D) = "white" {}
    }

        SubShader{
            Tags {"Queue" = "Transparent" "RenderType" = "Transparent"}

            Pass {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f {
                    float4 vertex : SV_POSITION;
                    float2 uv : TEXCOORD0;
                    float4 screenPos : TEXCOORD1;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;

                v2f vert(appdata v) {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    o.screenPos = ComputeGrabScreenPos(o.vertex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target {
                   // float depth = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE(_CameraDepthNormalsTexture, i.screenPos.xy).r);
                    float currentDepth = i.screenPos.z / i.screenPos.w;
                    float depthDifference = currentDepth;
                    fixed4 col = tex2D(_MainTex, i.uv);
                    if (depthDifference > 0) {
                        col.a = 0;
                    }
                    return col;
                }
                ENDCG
            }
    }

        FallBack "Diffuse"
}