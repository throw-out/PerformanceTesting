[![Example](https://img.shields.io/badge/Test-example-blue.svg)](/Assets/CScripts/Examples)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-blue.svg)](https://github.com/throw-out/PerformanceTesting/pulls)

# 简介
 Unity游戏引擎, C#原生丶puerts脚本丶xLua脚本性能测试与横向对比

# 测试平台
 * 基础
 - [x] 反射调用-Editor
 - [x] 反射调用-Windows
 - [x] 反射调用-Androd
 - [x] 静态代码调用-Editor
 - [x] 静态代码调用-Windows
 - [x] 静态代码调用-Android
 - [x] IL2CPP调用-Windows
 - [x] IL2CPP调用-Android

 * 附加
 - [ ] ValueType BlittableCopy unsafe编译

 * 软件版本
 - [x] Unity: 2019.4.28f1c1
 - [x] puerts: [v1.2.4_version_15](https://github.com/Tencent/puerts/releases/tag/Unity_Plugin_1.2.4)
 - [x] xLua: [v2.1.16_newest_luajit](https://github.com/Tencent/xLua/releases/tag/v2.1.16_newest_luajit)

# 测试项目
 * 脚本调用CSharp
    - [x] [Example1](/Assets/CScripts/Examples/Example1.cs): 静态方法, 无参无返回值
    - [x] [Example2](/Assets/CScripts/Examples/Example2.cs): 实例方法, 无参无返回值
    - [x] [Example3](/Assets/CScripts/Examples/Example3.cs): 静态方法, 1个参数无返回值
    - [x] [Example4](/Assets/CScripts/Examples/Example4.cs): 静态方法, 3个参数无返回值
    - [x] [Example5](/Assets/CScripts/Examples/Example5.cs): 静态方法, 3个参数求和返回 
    - [x] [Example6](/Assets/CScripts/Examples/Example6.cs): 静态方法, 无参内部求和返回 
    - [x] [Example7](/Assets/CScripts/Examples/Example7.cs): 静态方法, Transform.Rotate
    - [x] [Example8](/Assets/CScripts/Examples/Example8.cs): 静态方法, Transform.Rotate传参xyz 
    - [x] [Example9](/Assets/CScripts/Examples/Example9.cs): 静态方法, Transform.Rotate传参Vector3 
    
 * CSharp调用脚本
    - [x] [Example101](/Assets/CScripts/Examples/Example101.cs): 无参无返回值
    - [x] [Example103](/Assets/CScripts/Examples/Example103.cs): 1个参数无返回值
    - [x] [Example104](/Assets/CScripts/Examples/Example104.cs): 3个参数无返回值
    - [x] [Example105](/Assets/CScripts/Examples/Example105.cs): 3个参数求和返回 
    - [x] [Example106](/Assets/CScripts/Examples/Example106.cs): 无参内部求和返回 
    - [x] [Example107](/Assets/CScripts/Examples/Example107.cs): Transform.Rotate
    - [x] [Example108](/Assets/CScripts/Examples/Example108.cs): Transform.Rotate传参xyz 
    - [x] [Example109](/Assets/CScripts/Examples/Example109.cs): Transform.Rotate传参Vector3 

# 测试结果
 * [查看结果](/States)

# 结论
 * xLua性能优于puerts，据作者[@John](https://github.com/chexiongsheng)所言，Unity与C++(puerts)相互调用比较与C(xLua)相互调用要慢
 * 使用puerts应尽量避免跨语言调用 `PS:使用任何脚本框架都应该尽量避免跨语言调用`
 * puerts没有脚本fix功能: 推荐使用 [InjectFix](https://github.com/Tencent/InjectFix) + [puerts](https://github.com/Tencent/puerts) 混合开发

# 如何选择
|               | puerts                        | xLua                          |
| :-----        | :-----                        | :-----                        |
| 开发语言       | [typescript](https://www.tslang.cn/)丶javascript        | lua丶haxe(不推荐)              |
| 跨语言效率     |       低                      |           高                    |
| IDE支持        | [vscode](https://code.visualstudio.com/) 丶[rider](https://www.jetbrains.com/rider/) | [EmmyLua](https://github.com/EmmyLua)丶[LuaPanda](https://github.com/Tencent/LuaPanda)丶[LuaPerfect](https://github.com/jiangzheng1986/LuaPerfect)               |
| 代码提示       | 完整类型定义                   |  局部类型推断+手动注释          |
| 代码规范       | eslint丶tslint等              |  人工review                    |
| 第三方库       | 得益于浏览器丶nodejs的普及, [npm](https://www.npmjs.com/)上拥有大量可用es库 | 自行编译丶扩展(有限支持)     |
