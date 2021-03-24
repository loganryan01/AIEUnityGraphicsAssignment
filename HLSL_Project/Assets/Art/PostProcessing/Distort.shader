Shader "PostProcessing/Distort"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _A("A", Range(1.0,20.0)) = 5.0
        _B("B", Range(1.0,20.0)) = 5.0
    }
    SubShader
    {
        Cull Off
        
        Pass
        {
            

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #include "UnityCG.cginc"

            // Properties
            sampler2D _MainTex;
            float A, B;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;

                return o;
            }

            

            float4 frag (v2f i) : COLOR
            {
                float2 uv = i.uv.xy;
                uv.y += cos(uv.x * A + _Time.g) / B;
                
                return tex2D(_MainTex, i.uv);
            }
            ENDCG
        }
    }
}
