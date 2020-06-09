using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using DG.Tweening;

public static class DoTweenExtention
{
    // TweenのAwaiter
    public struct TweenAwaiter : System.Runtime.CompilerServices.ICriticalNotifyCompletion
    {
        Tween tween;
        CancellationToken cancellationToken;

        public TweenAwaiter(Tween tween, CancellationToken cancellationToken)
        {
            this.tween = tween;
            this.cancellationToken = cancellationToken;
        }

        public bool IsCompleted => !tween.IsPlaying();

        public void GetResult() => cancellationToken.ThrowIfCancellationRequested();

        public void OnCompleted(Action continuation) => UnsafeOnCompleted(continuation);

        public void UnsafeOnCompleted(Action continuation)
        {
            CancellationTokenRegistration regist = new CancellationTokenRegistration();
            var tween = this.tween;

            // Tweenが死んだら続きを実行
            tween.OnKill(() =>
            {
                regist.Dispose(); // CancellationTokenRegistrationを破棄する
                continuation(); // 続きを実行
            });

            // tokenが発火したらTweenをKillする
            regist = cancellationToken.Register(()=> {
                tween.Kill(true);
            });
        }

        public TweenAwaiter GetAwaiter() => this;
    }

    // Tweenに対する拡張メソッド
    public static TweenAwaiter GetAwaiter(this Tween self,CancellationToken cancellationToken = default)
    {
        return new TweenAwaiter(self,cancellationToken);
    }
}
