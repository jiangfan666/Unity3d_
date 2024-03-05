using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DoTweenTest : MonoBehaviour {


	private Image maskImage;
	private Tween maskTween;

	// Use this for initialization
	void Start()
	{
		maskImage = GetComponent<Image>();

		////1. doTween的静态方法
		//DOTween.To(() => maskImage.color, toColor => maskImage.color = toColor, new Color(0, 0, 0, 0), 2f);

		////详细分解
		//DOTween.To(
		//	()
		//	=> maskImage.color//想改变的值
		//	, toColor//每次经过doTween计算的结果（当前值到目标值的插值）
		//	=> maskImage.color = toColor, //将计算结果赋值
		//	new Color(0, 0, 0, 0), 2f);//目标值，完成动画时间

		////2.doTween直接作用于transform的方法
		//Tween tween =  transform.DOLocalMoveX(300,2f);

		//3.动画的循环使用
		maskTween = transform.DOLocalMoveX(300, 2f);
		maskTween.SetAutoKill(false);//自动清除动画api，保证性能
		maskTween.Pause();

		//4.动画的事件回调
		Tween tween = transform.DOLocalMoveX(300, 2f);
		tween.OnComplete(CompleteMethod);

		//5.设置动画缓动函数以及循环状态和次数
		tween.SetEase(Ease.InOutBounce);
		tween.SetLoops(-1,LoopType.Restart);
	}
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			//结论：Tween对象的Play()只能播一次（相对于倒播），不能连续倒播
			//maskTween.Play();
			maskTween.PlayForward();
		}
		else if (Input.GetMouseButtonDown(1))
		{
			maskTween.PlayBackwards();//倒播
		}
	}
	private void CompleteMethod()
	{
		DOTween.To(() => maskImage.color, toColor => maskImage.color = toColor, new Color(0, 0, 0, 0), 2f);
	}
}
