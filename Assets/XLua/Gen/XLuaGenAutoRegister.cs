#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;
using System.Collections.Generic;
using System.Reflection;


namespace XLua.CSObjectWrap
{
    public class XLua_Gen_Initer_Register__
	{
        
        
        static void wrapInit0(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(Example1), Example1Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Example2), Example2Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Example3), Example3Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Example4), Example4Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Example5), Example5Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Example6), Example6Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Example7), Example7Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Example8), Example8Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Example9), Example9Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Example101), Example101Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Example103), Example103Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Example104), Example104Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Example105), Example105Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Example106), Example106Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Example107), Example107Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Example108), Example108Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Example109), Example109Wrap.__Register);
        
        
        
        }
        
        static void Init(LuaEnv luaenv, ObjectTranslator translator)
        {
            
            wrapInit0(luaenv, translator);
            
            
        }
        
	    static XLua_Gen_Initer_Register__()
        {
		    XLua.LuaEnv.AddIniter(Init);
		}
		
		
	}
	
}
namespace XLua
{
	public partial class ObjectTranslator
	{
		static XLua.CSObjectWrap.XLua_Gen_Initer_Register__ s_gen_reg_dumb_obj = new XLua.CSObjectWrap.XLua_Gen_Initer_Register__();
		static XLua.CSObjectWrap.XLua_Gen_Initer_Register__ gen_reg_dumb_obj {get{return s_gen_reg_dumb_obj;}}
	}
	
	internal partial class InternalGlobals
    {
	    
	    static InternalGlobals()
		{
		    extensionMethodMap = new Dictionary<Type, IEnumerable<MethodInfo>>()
			{
			    
			};
			
			genTryArrayGetPtr = StaticLuaCallbacks.__tryArrayGet;
            genTryArraySetPtr = StaticLuaCallbacks.__tryArraySet;
		}
	}
}
