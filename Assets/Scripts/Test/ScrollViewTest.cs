using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ScrollViewTest : MonoBehaviour ,IBeginDragHandler,IDragHandler,IEndDragHandler
{
	private ScrollRect scrollRect;
	private RectTransform contentRectTrans;

	// Use this for initialization
	void Start () 
	{
		scrollRect = GetComponent<ScrollRect>();

		//关于RectTransform的探究
		contentRectTrans = scrollRect.content;

		//当前UI的世界坐标
		Debug.Log("当前UI的世界坐标:"+ contentRectTrans.position);
		//当前UI的局部坐标
 		Debug.Log("当前UI的局部坐标："+ contentRectTrans.localPosition);
		//当前UI的宽度(从左到右的宽度)
		// Debug.Log("当前UI的宽度："+contentRectTrans.rect.right);
		//提示：这个代码只有在第二帧的时候才会奏效
		Debug.Log("当前UI的宽度："+ contentRectTrans.rect.xMax);
		Debug.Log("当前UI的宽度："+ contentRectTrans.rect.width);

		//当前UI的左坐标
		Debug.Log("当前UI的左坐标："+ contentRectTrans.rect.xMin);
		Debug.Log("当前UI的左坐标："+ contentRectTrans.rect.x);//不是当前UI的x的局部坐标

		//当前UI高度
		Debug.Log("当前UI的左坐标："+ contentRectTrans.rect.height);

		//注意，只表示当前transform的x轴向的方向
		//如同transform.right自身方向的右方
		Debug.Log(contentRectTrans.right);

		//当前UI底部相对于顶部的相对长度，负数为向下延展，同理则反
		Debug.Log(contentRectTrans.rect.y);

		//当前UI的宽高
		Debug.Log(contentRectTrans.sizeDelta);
		Debug.Log(contentRectTrans.sizeDelta.x);
		Debug.Log(contentRectTrans.sizeDelta.y);

		//增加宽度值
		contentRectTrans.sizeDelta  = new Vector2(320,300);

		//水平滚动比例
		scrollRect.horizontalNormalizedPosition  = 0.5f;

		//监听注册
		//scrollRect.onValueChanged.AddListener(PrintValue);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	private void PrintValue(Vector2 vector2)
	{
		Debug.Log("get  the  value :"+vector2);

	}

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("开始滑动");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("滑动中");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("结束滑动");
    }
}
