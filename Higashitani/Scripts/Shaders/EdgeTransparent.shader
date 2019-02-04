Shader "Unlit/EdgeTransparent"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
        _EdgeDistanceX("EdgeDistanceX", Range(0,1)) = 0.0
        _EdgeDistanceY("EdgeDistanceY", Range(0,1)) = 0.0
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "IgnoreProjector"="True" "Queue" = "Transparent"}
		LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
            float _EdgeDistanceX;
            float _EdgeDistanceY;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
            float transparent(float val, float edVal) {
                float ret = 0;
                ret = lerp( 
                          lerp(0, 1, clamp( abs(abs(val-0.5)-0.5)*2 / edVal, 0, 1)
                        ), 1, step( abs(val-0.5)*1000 , edVal )  );
                return ret;
            }

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
                col.a = transparent(i.uv.x, _EdgeDistanceX);
                col.a *= transparent(i.uv.y, _EdgeDistanceY);
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
