/****************************************************************************
 * Copyright (c) 2017 liangxie
 * 
 * http://liangxiegame.com
 * https://github.com/liangxiegame/QFramework
 * https://github.com/liangxiegame/QSingleton
 * https://github.com/liangxiegame/QChain
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 ****************************************************************************/

using UnityEngine.EventSystems;

namespace QFramework
{
    using UnityEngine.UI;
    using UnityEngine.Events;

    public static class ButtonUtil
    {
        /// <summary>
        /// Simple wrapper for onclick event
        /// </summary>
        /// <param name="selfBtn"></param>
        /// <param name="onClickEvent"></param>
        public static void RegOnClickEvent(this Button selfBtn, UnityAction onClickEvent,
            UnityAction onBeforeClickEvent = null,UnityAction onPointerUpEvent = null)
        {
            if (null != onBeforeClickEvent)
            {
                UIPointerDownEventListener.Get(selfBtn.gameObject).OnPointerDownEvent += delegate(PointerEventData arg0)
                {
                    onBeforeClickEvent.InvokeGracefully();
                    ExecuteEvents.Execute<Button>(selfBtn.gameObject, arg0,
                        delegate(Button handler, BaseEventData data)
                        {
                            handler.OnPointerDown(data as PointerEventData);
                        });
                };
            }
            
            
            if (null != onPointerUpEvent)
            {
                UIPointerUpEventListener.Get(selfBtn.gameObject).OnPointerUpEvent += delegate(PointerEventData arg0)
                {
                    onPointerUpEvent.InvokeGracefully();
                    ExecuteEvents.Execute<Button>(selfBtn.gameObject, arg0,
                        delegate(Button handler, BaseEventData data)
                        {
                            handler.OnPointerUp(data as PointerEventData);
                        });
                };
            }
 
            selfBtn.onClick.AddListener(onClickEvent);
        }
    }
}