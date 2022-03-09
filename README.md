# 简介
 Unity游戏引擎, C#原生丶puerts脚本丶xLua脚本性能测试与横向对比

# 测试项目

* 调用CSharp方法
    - [x] [Example1](/Assets/Examples/Example1.cs): 静态方法, 无参无返回值
    - [x] [Example2](/Assets/Examples/Example2.cs): 实例方法, 无参无返回值
    - [x] [Example3](/Assets/Examples/Example3.cs): 静态方法, 1个参数无返回值
    - [x] [Example4](/Assets/Examples/Example4.cs): 静态方法, 3个参数无返回值
    - [x] [Example5](/Assets/Examples/Example5.cs): 静态方法, 3个参数求和返回 
    - [x] [Example6](/Assets/Examples/Example6.cs): 静态方法, 无参内部求和返回 
    - [x] [Example7](/Assets/Examples/Example7.cs): 静态方法, Transform.Rotate
    - [x] [Example8](/Assets/Examples/Example8.cs): 静态方法, Transform.Rotate传参xyz 
    - [x] [Example9](/Assets/Examples/Example9.cs): 静态方法, Transform.Rotate传参Vector3 
    
* CSharp调用脚本方法
    - [x] [Example101](/Assets/Examples/Example101.cs): 无参无返回值
    - [x] [Example103](/Assets/Examples/Example103.cs): 1个参数无返回值
    - [x] [Example104](/Assets/Examples/Example104.cs): 3个参数无返回值
    - [x] [Example105](/Assets/Examples/Example105.cs): 3个参数求和返回 
    - [x] [Example106](/Assets/Examples/Example106.cs): 无参内部求和返回 
    - [x] [Example107](/Assets/Examples/Example107.cs): Transform.Rotate
    - [x] [Example108](/Assets/Examples/Example108.cs): Transform.Rotate传参xyz 
    - [x] [Example109](/Assets/Examples/Example109.cs): Transform.Rotate传参Vector3 

# 性能测试
 * 反射调用: [查看结果](/States/STATES_BY_REFLECTION.md)
 * 静态代码调用: [查看结果](./States/STATES_BY_STATIC_CODE.md)
 * IL2CPP调用: [查看结果](./States/STATES_BY_IL2CPP.md)
