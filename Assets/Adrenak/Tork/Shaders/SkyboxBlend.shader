Shader "Skybox/Blended" {
Properties {
    _Tint ("Tint Color", Color) = (.5, .5, .5, .5)
    _Blend ("Blend", Range(0.0,1.0)) = 0.5
    _FrontTex1 ("Front (+Z)", 2D) = "white" {}
    _BackTex1 ("Back (-Z)", 2D) = "white" {}
    _LeftTex1 ("Left (+X)", 2D) = "white" {}
    _RightTex1 ("Right (-X)", 2D) = "white" {}
    _UpTex1 ("Up (+Y)", 2D) = "white" {}
    _DownTex1 ("Down (-Y)", 2D) = "white" {}
    _FrontTex2("2 Front (+Z)", 2D) = "white" {}
    _BackTex2("2 Back (-Z)", 2D) = "white" {}
    _LeftTex2("2 Left (+X)", 2D) = "white" {}
    _RightTex2("2 Right (-X)", 2D) = "white" {}
    _UpTex2("2 Up (+Y)", 2D) = "white" {}
    _DownTex2("2 Down (-Y)", 2D) = "white" {}
}

SubShader {
    Tags { "Queue" = "Background" }
    Cull Off
    Fog { Mode Off }
    Lighting Off
    Color [_Tint]
    Pass {
        SetTexture [_FrontTex1] { combine texture }
        SetTexture [_FrontTex2] { constantColor (0,0,0,[_Blend]) combine texture lerp(constant) previous }
    }
    Pass {
        SetTexture [_BackTex1] { combine texture }
        SetTexture [_BackTex2] { constantColor (0,0,0,[_Blend]) combine texture lerp(constant) previous }
    }
    Pass {
        SetTexture [_LeftTex1] { combine texture }
        SetTexture [_LeftTex2] { constantColor (0,0,0,[_Blend]) combine texture lerp(constant) previous }
    }
    Pass {
        SetTexture [_RightTex1] { combine texture }
        SetTexture [_RightTex2] { constantColor (0,0,0,[_Blend]) combine texture lerp(constant) previous }
    }
    Pass {
        SetTexture [_UpTex1] { combine texture }
        SetTexture [_UpTex2] { constantColor (0,0,0,[_Blend]) combine texture lerp(constant) previous }
    }
    Pass {
        SetTexture [_DownTex1] { combine texture }
        SetTexture [_DownTex2] { constantColor (0,0,0,[_Blend]) combine texture lerp(constant) previous }
    }
}

Fallback "Skybox/6 Sided", 1
}