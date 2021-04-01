Shader "Custom/HullOutline"
{
    Properties
    {
        _Color ("Tint", Color) = (0, 0, 0, 1)
	    _MainTex ("Texture", 2D) = "white" {}
	    _Smoothness ("Smoothness", Range(0, 1)) = 0
	    _Metallic ("Metalness", Range(0, 1)) = 0
	    [HDR] _Emission ("Emission", color) = (0,0,0)

        _OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
        _OutlineThickness ("Outline Thickness", Range(0, 1)) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue" = "Geometry"}
        //ZWrite On
        //Lighting On

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        fixed4 _Color;

        half _Smoothness;
        half _Metallic;
        half3 _Emission;

        struct Input
        {
            float2 uv_MainTex;
        }; 

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Smoothness;
            o.Emission = _Emission;
        }
        ENDCG

        // The second pass where w render the outlines
        Pass
        {
            Cull Front

            CGPROGRAM

            // include useful shader functions
            #include "UnityCG.cginc"

            // define vertex and fragment shader
            #pragma vertex vert
            #pragma fragment frag

            // tint of the texture
            fixed4 _OutlineColor;
            float _OutlineThickness;

            // the object data that's put into the vertex shader
            struct appdata
            {
                float4 vertex : POSITION;
                float4 normal : NORMAL;
            };

            // the data that's used to generate fragments and can be read by the fragment shader
            struct v2f
            {
                float4 position : SV_POSITION;
            };

            // the vertex shader
            v2f vert(appdata v)
            {
                v2f o;
                // convert the vertex positions from object space to clip space so they can be rendered
                o.position = UnityObjectToClipPos(v.vertex + normalize(v.normal) * _OutlineThickness);
                return o;
            }

            // the fragment shader
            fixed4 frag(v2f i) : SV_TARGET
            {
                return _OutlineColor;
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}
