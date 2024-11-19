Shader "Unlit/Clouds"
{
   Properties {
        _BaseColor("Base Color", Color) = (1,1,1,1)
        _NoiseTexture("Noise Texture", 2D) = "white" {}
        _FresnelPower("Fresnel Power", Range(0,5)) = 2.0
    }
    SubShader {
        Tags { "RenderType"="Transparent" }
        LOD 300

        Blend SrcAlpha OneMinusSrcAlpha
        CGPROGRAM
        #pragma surface surf Standard alpha:fade

        sampler2D _NoiseTexture;
        fixed4 _BaseColor;
        half _FresnelPower;

        struct Input {
            float3 viewDir;
            float2 uv_NoiseTexture;
        };

        void surf(Input IN, inout SurfaceOutputStandard o) {
            fixed4 noise = tex2D(_NoiseTexture, IN.uv_NoiseTexture);
            float fresnel = pow(1.0 - dot(normalize(IN.viewDir), float3(0, 0, 1)), _FresnelPower);

            o.Albedo = _BaseColor.rgb * noise.r;
            o.Alpha = noise.a * fresnel;
        }
        ENDCG
    }
}