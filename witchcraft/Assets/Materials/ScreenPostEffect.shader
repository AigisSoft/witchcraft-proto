Shader "Custom/ScreenPostEffect" {
	Properties{
		_MainTex("MainTex", 2D) = ""{}
	}

	SubShader{
		Pass{
			CGPROGRAM

			#include "UnityCG.cginc"

			#pragma vertex vert_img
			#pragma fragment frag

			sampler2D _MainTex;

			fixed4 frag(v2f_img i) : COLOR{
				fixed4 c = tex2D(_MainTex, i.uv);
				c.rgb = fixed3(c.r * 2, c.g * 2, c.b * 2);
				return c;
			}

			ENDCG
		}
	}
}