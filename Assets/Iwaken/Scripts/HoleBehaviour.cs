using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx.Async;

public class HoleBehaviour : MonoBehaviour
{
    [SerializeField] Transform holeRoot;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public async UniTask Initialize() {
        await holeRoot.DOScale(Vector3.zero,0f).GetAwaiter(this.GetCancellationTokenOnDestroy());
        await holeRoot.DOScale(Vector3.one*1.5f,0.5f).GetAwaiter(this.GetCancellationTokenOnDestroy());
        await holeRoot.DOScale(Vector3.one*1f,0.1f).GetAwaiter(this.GetCancellationTokenOnDestroy());
    }
}
