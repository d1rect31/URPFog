using UnityEditor;
using UnityEditor.Rendering;

namespace Meryuhi.Rendering
{
    [CustomEditor(typeof(FullScreenFog))]
    sealed class FullScreenFogEditor : VolumeComponentEditor
    {
        SerializedDataParameter _mode;
        SerializedDataParameter _intensity;
        SerializedDataParameter _color;
        SerializedDataParameter _densityMode;
        SerializedDataParameter _startDistance;
        SerializedDataParameter _startHeight;
        SerializedDataParameter _density;
        SerializedDataParameter _heightFalloff;
        SerializedDataParameter _depthFalloff;

        SerializedDataParameter _noiseMode;
        SerializedDataParameter _noiseTexture;
        SerializedDataParameter _noiseIntensity;
        SerializedDataParameter _noiseScale;
        SerializedDataParameter _noiseScrollSpeed;


        public override void OnEnable()
        {
            var o = new PropertyFetcher<FullScreenFog>(serializedObject);

            _mode = Unpack(o.Find(x => x.mode));
            _intensity = Unpack(o.Find(x => x.intensity));
            _color = Unpack(o.Find(x => x.color));
            _densityMode = Unpack(o.Find(x => x.densityMode));
            _startDistance = Unpack(o.Find(x => x.startDistance));
            _startHeight = Unpack(o.Find(x => x.startHeight));
            _density = Unpack(o.Find(x => x.density));
            _heightFalloff = Unpack(o.Find(x => x.heightFalloff));
            _depthFalloff = Unpack(o.Find(x => x.depthFalloff));

            _noiseMode = Unpack(o.Find(x => x.noiseMode));
            _noiseTexture = Unpack(o.Find(x => x.noiseTexture));
            _noiseIntensity = Unpack(o.Find(x => x.noiseIntensity));
            _noiseScale = Unpack(o.Find(x => x.noiseScale));
            _noiseScrollSpeed = Unpack(o.Find(x => x.noiseScrollSpeed));
        }

        public override void OnInspectorGUI()
        {
            var mode = (FullScreenFogMode)_mode.value.intValue;
            PropertyField(_mode);

            PropertyField(_intensity);

            PropertyField(_color);

            var densityMode = (FullScreenFogDensityMode)_densityMode.value.intValue;
            PropertyField(_densityMode);

            if (FullScreenFog.UseStartDistance(mode))
            {
                PropertyField(_startDistance);
            }
            if (FullScreenFog.UseStartHeight(mode))
            {
                PropertyField(_startHeight);
            }
            if (FullScreenFog.UseIntensity(densityMode))
            {
                PropertyField(_density);
            }

            if (mode == FullScreenFogMode.Depth || mode == FullScreenFogMode.Distance || mode == FullScreenFogMode.HeightDistance)
            {
                PropertyField(_depthFalloff);
            }
            if (mode == FullScreenFogMode.Height || mode == FullScreenFogMode.HeightDistance)
            {
                PropertyField(_heightFalloff);
            }

            var noiseMode = (FullScreenFogNoiseMode)_noiseMode.value.intValue;
            PropertyField(_noiseMode);

            if (FullScreenFog.UseNoiseTex(noiseMode))
            {
                PropertyField(_noiseTexture);
            }
            if (FullScreenFog.UseNoiseIntensity(noiseMode))
            {
                PropertyField(_noiseIntensity);
                PropertyField(_noiseScale);
                PropertyField(_noiseScrollSpeed);
            }
        }
    }
}
