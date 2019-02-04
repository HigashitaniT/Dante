Shader "Custom/BlockAlphaShade" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Offset ("offset",float) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Transparent" "Queue"="Transparent"}
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard alpha:fade

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		float _Offset;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		//UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		//UNITY_INSTANCING_BUFFER_END(Props)

		float dist(float2 a, float2 b) {
			return abs( pow( abs(a.x-b.x) * abs(a.x-b.x) + abs(a.y-b.y) * abs(a.y-b.y), 2 ));
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Emission = c.rgb;
			float2 wPos = float2(_WorldSpaceCameraPos.x, _WorldSpaceCameraPos.z);
			float2 myPos = float2(IN.worldPos.x, IN.worldPos.z);
			o.Alpha = lerp(0,1,step(dist(wPos,myPos),_Offset*1000));
		}
		ENDCG
	}
	FallBack "Diffuse"
}
