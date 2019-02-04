Shader "Custom/EnemyEyeShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_Offset ("offset",float) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Transparent" "Queue"="Transparent"}
		LOD 200
        pass{
            ZWrite on
            ColorMask 0
        }
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard alpha:fade

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		float _Offset;

		struct Input {
			float3 worldPos;
		};

		fixed4 _Color;

		float dist(float2 a, float2 b) {
			return abs( pow( abs(a.x-b.x) * abs(a.x-b.x) + abs(a.y-b.y) * abs(a.y-b.y), 2 ));
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			o.Emission = _Color;
			float2 wPos = float2(_WorldSpaceCameraPos.x, _WorldSpaceCameraPos.z);
			float2 myPos = float2(IN.worldPos.x, IN.worldPos.z);
			o.Alpha = lerp(1,0,step(dist(wPos,myPos),_Offset*1000));
		}
		ENDCG
	}
	FallBack "Diffuse"
}
