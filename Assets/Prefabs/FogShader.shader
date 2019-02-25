Shader "Unlit/FogShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Colour("Colour", Color) = (0.0, 0.0, 0.0, 0.0)
		_BackgroundColour("BackgroundColour", Color) = (0.0, 0.0, 0.0, 0.0)
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			#include "Lighting.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;

			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;

				float3 cameraPosition : TEXCOORD2;
				float distance : TEXCOORD3;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Colour;
			float4 _BackgroundColour;

			v2f vert(appdata input)
			{
				v2f output;

				output.vertex = UnityObjectToClipPos(input.vertex);


				output.uv = TRANSFORM_TEX(input.uv, _MainTex);


				output.cameraPosition = float4(_WorldSpaceCameraPos, 1.0);
				float4 worldPosition = mul(unity_ObjectToWorld, input.vertex);
				output.distance = distance(worldPosition, output.cameraPosition);


				return output;
			}

			fixed4 frag(v2f input) : SV_Target
			{
					float density = 0.01f;
					float gradient = 3.0f;

					float visibility = exp(-pow((input.distance * density), -gradient));

					return lerp(tex2D(_MainTex, input.uv), _BackgroundColour, visibility);
		}
		ENDCG
	}
	}
}
