using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.AddressableAssets;
 
public class SpriteLoader : MonoBehaviour
{
    public static readonly List<string> animationNames =
    new List<string>() { "Parado", "Andando", "Ataque" };
    public static readonly List<char> directions =
    new List<char>() { 'N', 'S', 'L', 'O' };
    public List<Animation2D> animations;
    public float framerate;
    public float delayStart;
    public static Transform holder;
    public Dictionary<string, Animation2D> animationsFinder;
    void Awake()
    {
        if (holder == null)
            holder = this.transform.parent;
    }
    public IEnumerator Load()
    {
        animations = new List<Animation2D>();
        animationsFinder = new Dictionary<string, Animation2D>();
 
        foreach (string anim in animationNames)
        {
            for (int i = 0; i < 4; i++)
            {
                string tempName = transform.name + "/" + anim + directions[i] ;
                //Debug.Log("Loading: " + tempName[0]);
 
                Animation2D tempAnimation2D = new Animation2D();
                tempAnimation2D.frameRate = framerate;
                tempAnimation2D.name = anim + directions[i];
                tempAnimation2D.delayStart = delayStart;
                tempAnimation2D.frames = new List<Sprite>();
                animations.Add(tempAnimation2D);
 
                animationsFinder.Add(tempAnimation2D.name, tempAnimation2D);
                AsyncOperationHandle<IList<Sprite>> handle =
                Addressables.LoadAssetsAsync<Sprite>(tempName, null);
 
                yield return handle;
                WhenFinished(handle);
            }
 
        }
        SortAnimations();
        //Debug.Log(transform.name + " animations loaded");
    }
    void WhenFinished(AsyncOperationHandle<IList<Sprite>> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            foreach (Sprite sprite in handle.Result)
            {
                animations[animations.Count - 1].frames.Add(sprite);
            }
        }
    }
    public Animation2D GetAnimation(string name)
    {
        Animation2D rtv = null;
        animationsFinder.TryGetValue(name, out rtv);
        return rtv;
    }
    void SortAnimations(){
        foreach(Animation2D animation in animations){
            animation.frames.Sort((x, y)=>string.Compare(x.name, y.name));
        }
    }
}