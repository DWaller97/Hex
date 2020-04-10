Shader "Hex"
{
    Properties
    {
        _Height("Height", Float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                fixed4 colour : COLOR;
            };

            fixed _Height;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.colour.rgba = 0, 0, 0, 1;
                if(_Height == 0)
                    o.colour.r = 1;
                if(_Height == 1)
                    o.colour.g = 1;
                if(_Height == 2)
                    o.colour.b = 1;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return i.colour;
            }
            ENDCG
        }
    }
}
