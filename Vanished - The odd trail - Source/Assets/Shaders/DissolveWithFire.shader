Shader "GameShaders/DissolveWithFire"
{
	Properties{
		_Color("Color", Color) = (0,1,1,1)
		_MainTex("Texture", 2D) = "white" {}
		_NoiseTex("Noise Texture", 2D) = "gray" {}
		_DissolveThreshold("Dissolve Threshold", Range(0, 1)) = 1

		_BurnSize("Burn Size", Range(0.0, 1.0)) = 0.15
		_BurnText("Burn Ramp (RGB)", 2D) = "white" {}
	}
		SubShader{
			Pass{
				CGPROGRAM
				#pragma vertex MyVertexProgram
				#pragma fragment MyFragmentProgram

				#include "UnityCG.cginc"

				struct VertexData {
					float4 position : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct VertexToFragment {
					float4 position : SV_POSITION;
					float2 uv : TEXCOORD0;
					float2 uvNoise : TEXCOORD1;
				};

				float4 _Color;
				sampler2D _MainTex, _NoiseTex, _BurnText;
				float4 _MainTex_ST, _NoiseTex_ST;
				float _DissolveThreshold, _BurnSize;

				VertexToFragment MyVertexProgram(VertexData vertex)
				{
					VertexToFragment v2f;
					v2f.position = UnityObjectToClipPos(vertex.position);
					v2f.uv = vertex.uv * _MainTex_ST.xy + _MainTex_ST.zw;
					v2f.uvNoise = vertex.uv * _NoiseTex_ST.xy + _NoiseTex_ST.zw;
					return v2f;
				}

				float4 MyFragmentProgram(VertexToFragment v2f) : SV_TARGET
				{
					float4 colorValue = tex2D(_MainTex, v2f.uv);

					float4 noiseColorValue = tex2D(_NoiseTex, v2f.uvNoise);
					clip(noiseColorValue.rgb - _DissolveThreshold);

					half test = tex2D(_NoiseTex, v2f.uv).rgb - _DissolveThreshold;
					
					if (test < _BurnSize && _DissolveThreshold > 0 && _DissolveThreshold < 1) {
						float4 burnColorValue = tex2D(_BurnText, float2(test * (1 / _BurnSize), 0));
						colorValue *= burnColorValue;
					}
					return colorValue * _Color;
				}
				ENDCG
			}
		}
}
