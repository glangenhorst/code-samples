﻿Shader "Dreamension/Waterfall"
{
	// I actually wrote this one without a tutorial, but I got a lot of the logic from various "waterfall in unity" concepts online.
	// Works with the WaterfallBehavior.cs to react to Colliders.
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Cutoff("Alpha Cutoff", Range(0.0, 1.0)) = 0.5
	}
		SubShader
	{
		Tags
		{
		"Queue" = "Geometry"
		}
		Pass
	{
		Blend SrcAlpha OneMinusSrcAlpha

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
		};
	v2f vert(appdata v) {
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.uv = v.uv;
		return o;
		}

	sampler2D _MainTex;
	float _Cutoff;
	float4 frag(v2f i) : SV_Target {
		float2 distuv = float2(i.uv.x, i.uv.y + _Time.x * 8);
		float4 color = tex2D(_MainTex, distuv);
		// Alpha cutoff is here, connects to WaterfallBehavior.cs
		color.a = step(0.0, i.uv.y - _Cutoff);

		return color;
	}
	ENDCG
		}
	}
}
