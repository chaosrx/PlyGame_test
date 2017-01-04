#if UNITY_4_6 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using plyCommon;
using plyBloxKit;
using plyGame;

// OnClickTriggerBloxEvent_v3
// by RaiuLyn
// https://twitter.com/RaiuLyn
// http://raiulyn.wordpress.com 
// http://forum.plyoung.com/users/raiulyn
// ============================================================================================================
namespace Lyn
{
    [AddComponentMenu("plyGame/Misc/OnClick Trigger BloxEvent")]
    public class OnClickTriggerBloxEvent : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
    {
        public HandlerType type = HandlerType.OnClick;
        public PointerEventData.InputButton mouseInput;
        public plyBlox blox;
        public string eventName;
        public plyEvent bloxEvent;

        public List<EventParam> Params;

        private bool isActive = false;
        private bool isPressed = false;
        private Item i;

        public void OnPointerClick(PointerEventData eventData)
        {
            if(isActive)
            {
                if (type == HandlerType.OnClick)
                {
                    if (eventData.button == mouseInput)
                    {
                        Click();
                    }
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(isActive)
            {
                if (type == HandlerType.OnClickDown)
                {
                    if (eventData.button == mouseInput)
                    {
                        Click();
                    }
                }
                if (type == HandlerType.OnClickHold)
                {
                    if (eventData.button == mouseInput)
                    {
                        isPressed = true;
                    }
                }
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(isActive)
            {
                if (type == HandlerType.OnClickEnter)
                {
                    if (eventData.button == mouseInput)
                    {
                        Click();
                    }
                }
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if(isActive)
            {
                if (type == HandlerType.OnClickExit)
                {
                    if (eventData.button == mouseInput)
                    {
                        Click();
                    }
                }
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if(isActive)
            {
                if (type == HandlerType.OnClickUp)
                {
                    if (eventData.button == mouseInput)
                    {
                        Click();
                    }
                }
                if (type == HandlerType.OnClickHold)
                {
                    if (eventData.button == mouseInput)
                    {
                        isPressed = false;
                    }
                }
            }
        }

        //=====================================================================
        void Start()
        {
            if (blox != null)
            {
                bloxEvent = blox.GetEvent(eventName);
                isActive = true;
            }
        }

        void Update()
        {
            if (isActive && isPressed)
            {
                Click();
            }
        }

        public void Click()
        {
            if(isActive)
            {
                foreach (EventParam Param in Params.ToArray())
                {
                    switch (Param._type)
                    {
                        case ParamType.String:
                            switch (Param._scope)
                            {
                                case ParamScope.Temp:
                                    bloxEvent.SetTempVarValue(Param.ParamName, Param.str_value);
                                    break;
                                case ParamScope.Local:
                                    blox.SetLocalVarValue(Param.ParamName, Param.str_value);
                                    break;
                                case ParamScope.Global:
                                    blox.SetGlobalVarValue(Param.ParamName, Param.str_value);
                                    break;
                            }
                            break;
                        case ParamType.Int:
                            switch (Param._scope)
                            {
                                case ParamScope.Temp:
                                    bloxEvent.SetTempVarValue(Param.ParamName, Param.int_value);
                                    break;
                                case ParamScope.Local:
                                    blox.SetLocalVarValue(Param.ParamName, Param.int_value);
                                    break;
                                case ParamScope.Global:
                                    blox.SetGlobalVarValue(Param.ParamName, Param.int_value);
                                    break;
                            }
                            break;
                        case ParamType.Float:
                            switch (Param._scope)
                            {
                                case ParamScope.Temp:
                                    bloxEvent.SetTempVarValue(Param.ParamName, Param.float_value);
                                    break;
                                case ParamScope.Local:
                                    blox.SetLocalVarValue(Param.ParamName, Param.float_value);
                                    break;
                                case ParamScope.Global:
                                    blox.SetGlobalVarValue(Param.ParamName, Param.float_value);
                                    break;
                            }
                            break;
                        case ParamType.Bool:
                            switch (Param._scope)
                            {
                                case ParamScope.Temp:
                                    bloxEvent.SetTempVarValue(Param.ParamName, Param.bool_value);
                                    break;
                                case ParamScope.Local:
                                    blox.SetLocalVarValue(Param.ParamName, Param.bool_value);
                                    break;
                                case ParamScope.Global:
                                    blox.SetGlobalVarValue(Param.ParamName, Param.bool_value);
                                    break;
                            }
                            break;
                        case ParamType.Vector3:
                            switch (Param._scope)
                            {
                                case ParamScope.Temp:
                                    bloxEvent.SetTempVarValue(Param.ParamName, Param.vector3_value);
                                    break;
                                case ParamScope.Local:
                                    blox.SetLocalVarValue(Param.ParamName, Param.vector3_value);
                                    break;
                                case ParamScope.Global:
                                    blox.SetGlobalVarValue(Param.ParamName, Param.vector3_value);
                                    break;
                            }
                            break;
                        case ParamType.Vector2:
                            switch (Param._scope)
                            {
                                case ParamScope.Temp:
                                    bloxEvent.SetTempVarValue(Param.ParamName, Param.vector2_value);
                                    break;
                                case ParamScope.Local:
                                    blox.SetLocalVarValue(Param.ParamName, Param.vector2_value);
                                    break;
                                case ParamScope.Global:
                                    blox.SetGlobalVarValue(Param.ParamName, Param.vector2_value);
                                    break;
                            }
                            break;
                        case ParamType.GameObject:
                            switch (Param._scope)
                            {
                                case ParamScope.Temp:
                                    bloxEvent.SetTempVarValue(Param.ParamName, Param.gameobject_value);
                                    break;
                                case ParamScope.Local:
                                    blox.SetLocalVarValue(Param.ParamName, Param.gameobject_value);
                                    break;
                                case ParamScope.Global:
                                    blox.SetGlobalVarValue(Param.ParamName, Param.gameobject_value);
                                    break;
                            }
                            break;
                        case ParamType.Component:
                            switch (Param._scope)
                            {
                                case ParamScope.Temp:
                                    bloxEvent.SetTempVarValue(Param.ParamName, Param.component_value);
                                    break;
                                case ParamScope.Local:
                                    blox.SetLocalVarValue(Param.ParamName, Param.component_value);
                                    break;
                                case ParamScope.Global:
                                    blox.SetGlobalVarValue(Param.ParamName, Param.component_value);
                                    break;
                            }
                            break;
                        case ParamType.Object:
                            switch (Param._scope)
                            {
                                case ParamScope.Temp:
                                    bloxEvent.SetTempVarValue(Param.ParamName, Param.object_value);
                                    break;
                                case ParamScope.Local:
                                    blox.SetLocalVarValue(Param.ParamName, Param.object_value);
                                    break;
                                case ParamScope.Global:
                                    blox.SetGlobalVarValue(Param.ParamName, Param.object_value);
                                    break;
                            }
                            break;
                        case ParamType.Item:
                            switch (Param.item_search)
                            {
                                case SearchItemBy.ScreenName:
                                    i = ItemsAsset.Instance.GetDefinition(Param.item_value, plyGameObjectIdentifyingType.screenName);
                                    break;
                                case SearchItemBy.Ident:
                                    i = ItemsAsset.Instance.GetDefinition(Param.item_value, plyGameObjectIdentifyingType.ident);
                                    break;
                                case SearchItemBy.ShortName:
                                    i = ItemsAsset.Instance.GetDefinition(Param.item_value, plyGameObjectIdentifyingType.shortName);
                                    break;
                                case SearchItemBy.Meta:
                                    i = ItemsAsset.Instance.GetDefinition(Param.item_value, plyGameObjectIdentifyingType.meta);
                                    break;
                            }
                            if (i == null)
                            {
                                Debug.LogError("(OnClickTriggerBloxEvent) Item does not exist");
                                return;
                            }
                            switch (Param._scope)
                            {
                                case ParamScope.Temp:
                                    bloxEvent.SetTempVarValue(Param.ParamName, i);
                                    break;
                                case ParamScope.Local:
                                    blox.SetLocalVarValue(Param.ParamName, i);
                                    break;
                                case ParamScope.Global:
                                    blox.SetGlobalVarValue(Param.ParamName, i);
                                    break;
                            }
                            break;
                    }
                }
                if (Params.Count > 0)
                {
                    blox.RunEvent(bloxEvent);
                }
            }
        }

        public void Click(plyBlox bloxDefined, string eventDefined, List<EventParam> ParamsDefined)
        {
            plyEvent ev = bloxDefined.GetEvent(eventDefined);

            foreach (EventParam par in ParamsDefined.ToArray())
            {
                switch (par._scope)
                {
                    case ParamScope.Temp:
                        ev.SetTempVarValue(par.ParamName, par.systemobject_value);
                        break;
                    case ParamScope.Local:
                        bloxDefined.SetLocalVarValue(par.ParamName, par.systemobject_value);
                        break;
                    case ParamScope.Global:
                        bloxDefined.SetGlobalVarValue(par.ParamName, par.systemobject_value);
                        break;
                }
            }
            bloxDefined.RunEvent(ev);
        }
    }
    [System.Serializable]
    public class EventParam
    {
        public object systemobject_value;
        public EventParam(string paramName, ParamScope paramScope, object value)
        {
            ParamName = paramName;
            _scope = paramScope;
            systemobject_value = value;
        }
        public EventParam(string paramName, ParamScope paramScope, string FindItem, plyGameObjectIdentifyingType FindbyType)
        {
            ParamName = paramName;
            _scope = paramScope;
            systemobject_value = ItemsAsset.Instance.GetDefinition(FindItem, FindbyType);
        }

        public string ParamName;
        public ParamScope _scope;
        public ParamType _type;
        public string str_value;
        public int int_value;
        public float float_value;
        public bool bool_value;
        public Vector3 vector3_value;
        public Vector2 vector2_value;
        public GameObject gameobject_value;
        public Component component_value;
        public Object object_value;
        public string item_value;
        public SearchItemBy item_search;
    }

    public enum ParamScope
    {
        Temp,
        Local,
        Global
    }

    public enum ParamType
    {
        String,
        Int,
        Float,
        Bool,
        Vector3,
        Vector2,
        GameObject,
        Component,
        Object,
        Item
    }

    public enum SearchItemBy
    {
        ScreenName,
        ShortName,
        Ident,
        Meta
    }

    public enum HandlerType
    {
        OnClick,
        OnClickDown,
        OnClickUp,
        OnClickEnter,
        OnClickExit,
        OnClickHold
    }
}

#endif