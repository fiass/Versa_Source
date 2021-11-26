using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib;
using UnityEngine;
using Versa.F_Output;

namespace Versa.F_Core
{
    internal class ResourceHandler 
    {
        internal static AssetBundle Bundle { get; set; }
        internal static void Start()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Versa.resources");
            var memStream = new MemoryStream((int)stream.Length);
            stream.CopyTo(memStream);
            Bundle = AssetBundle.LoadFromMemory_Internal(memStream.ToArray(), 0);
            Bundle.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            var Assets = Bundle.LoadAllAssetsAsync();
        }

        internal static Sprite LoadSprite(string sprite)
        {
            Sprite sprite2 = Bundle.LoadAsset(sprite, Il2CppType.Of<Sprite>()).Cast<Sprite>();
            sprite2.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            CustomConsole.Console(true, $"Loaded: {sprite}");
            return sprite2;
        }

        internal static GameObject LoadGameobject(string obj)
        {
            GameObject gb = Bundle.LoadAsset(obj, Il2CppType.Of<GameObject>()).Cast<GameObject>();
            gb.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            CustomConsole.Console(true, $"Loaded: {obj}");
            return gb;
        }


        internal static Material LoadMaterial(string name)
        {
            Material clip = Bundle.LoadAsset(name, Il2CppType.Of<Material>()).Cast<Material>();
            clip.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            CustomConsole.Console(true, $"Loaded: {name}");
            return clip;
        }

        internal static AudioClip LoadAudio(string name)
        {
            AudioClip clip = Bundle.LoadAsset(name, Il2CppType.Of<AudioClip>()).Cast<AudioClip>();
            clip.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            CustomConsole.Console(true, $"Loaded: {name}");
            return clip;
        }

        internal static Texture2D LoadTexture(string texture)
        {
            Texture2D texture2D = Bundle.LoadAsset(texture, Il2CppType.Of<Texture2D>()).Cast<Texture2D>();
            texture2D.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            CustomConsole.Console(true,$"Loaded: {texture}");
            return texture2D;
        }
        internal static RenderTexture LoadRenderTexture(string texture)
        {
            RenderTexture renderTexture = Bundle.LoadAsset(texture, Il2CppType.Of<RenderTexture>()).Cast<RenderTexture>();
            renderTexture.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            CustomConsole.Console(true, $"Loaded: {texture}");
            return renderTexture;
        }
       
    }
}
