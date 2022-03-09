[![Example](https://img.shields.io/badge/Test-example-blue.svg)](/Assets/CScripts/Examples)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-blue.svg)](/pulls)

# 简介
 Unity游戏引擎, C#原生丶puerts脚本丶xLua脚本性能测试与横向对比

# 测试项目
- [x] 编辑器反射调用
- [x] 编辑器静态代码调用
- [x] IL2CPP打包调用
- [ ] BlittableCopy(puerts)调用

* 调用CSharp方法
    - [x] [Example1](/Assets/CScripts/Examples/Example1.cs): 静态方法, 无参无返回值
    - [x] [Example2](/Assets/CScripts/Examples/Example2.cs): 实例方法, 无参无返回值
    - [x] [Example3](/Assets/CScripts/Examples/Example3.cs): 静态方法, 1个参数无返回值
    - [x] [Example4](/Assets/CScripts/Examples/Example4.cs): 静态方法, 3个参数无返回值
    - [x] [Example5](/Assets/CScripts/Examples/Example5.cs): 静态方法, 3个参数求和返回 
    - [x] [Example6](/Assets/CScripts/Examples/Example6.cs): 静态方法, 无参内部求和返回 
    - [x] [Example7](/Assets/CScripts/Examples/Example7.cs): 静态方法, Transform.Rotate
    - [x] [Example8](/Assets/CScripts/Examples/Example8.cs): 静态方法, Transform.Rotate传参xyz 
    - [x] [Example9](/Assets/CScripts/Examples/Example9.cs): 静态方法, Transform.Rotate传参Vector3 
    
* CSharp调用脚本方法
    - [x] [Example101](/Assets/CScripts/Examples/Example101.cs): 无参无返回值
    - [x] [Example103](/Assets/CScripts/Examples/Example103.cs): 1个参数无返回值
    - [x] [Example104](/Assets/CScripts/Examples/Example104.cs): 3个参数无返回值
    - [x] [Example105](/Assets/CScripts/Examples/Example105.cs): 3个参数求和返回 
    - [x] [Example106](/Assets/CScripts/Examples/Example106.cs): 无参内部求和返回 
    - [x] [Example107](/Assets/CScripts/Examples/Example107.cs): Transform.Rotate
    - [x] [Example108](/Assets/CScripts/Examples/Example108.cs): Transform.Rotate传参xyz 
    - [x] [Example109](/Assets/CScripts/Examples/Example109.cs): Transform.Rotate传参Vector3 

# 测试结果
 * 反射调用: [查看结果](/States/STATES_BY_REFLECTION.md)
 * 静态代码调用: [查看结果](./States/STATES_BY_STATIC_CODE.md)
 * IL2CPP调用: [查看结果](./States/STATES_BY_IL2CPP.md)
