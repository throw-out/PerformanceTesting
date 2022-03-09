
# 软件版本
| Name            | Value             |
| :----           | :----:            |
| Unity           | 2019.4.28f1c1               |
| puerts          | 15               |
| xLua            | 105               |
# 系统环境
| Name            | Value             |
| :----           | :----:            |
| System          | Windows 10  (10.0.19043) 64bit               |
| Memory          | 14188MB             |
| CPU             | AMD Ryzen 5 5600H with Radeon Graphics                |
| CPU-Core        | 12               |
| CPU-Frequency   | 3.294GHz            |
# 数据对照
* Static vs Instance | 	`静态函数 vs 实例函数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 1.0       | 213.0       | 234.3       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 1.0       | 200.3       | 343.3       | `null`           | `null`           | `null`          |
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 1.0       | 213.0       | 234.3       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 230.7       | 255.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 1.0       | 335.4       | 333.5       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 32.2       | 454.9       | 411.6       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 20.5       | 431.3       | 395.3       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 1000       | 0.0       | 4.9       | 5.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 21.7       | 31.7       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 1.0       | 213.0       | 234.3       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 1000       | 0.0       | 5.9       | 5.3       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 10000       | 0.0       | 18.6       | 45.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 1.0       | 200.3       | 343.3       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 1000       | 0.5       | 4.9       | 3.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 22.5       | 25.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 230.7       | 255.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 1000       | 0.0       | 4.9       | 4.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 27.4       | 49.4       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 1.0       | 335.4       | 333.5       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 1000       | 0.0       | 6.9       | 9.4       | 1501500           | 1501500           | 1501500          |
| [#](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 30.3       | 46.9       | 1.500183E+08           | 1.50015E+08           | 150015000          |
| [#](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 2.0       | 336.1       | 369.7       | 1.500022E+10           | 1.500015E+10           | 15000150000          |
| [#](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 1000       | 0.0       | 3.9       | 18.3       | 6000           | 6000           | 6000          |
| [#](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 19.4       | 36.9       | 60000           | 60000           | 60000          |
| [#](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 100000       | 1.0       | 236.8       | 333.7       | 600000           | 600000           | 600000          |
| [#](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 1000       | 2.9       | 25.2       | 16.6       | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)          |
| [#](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 10000       | 2.0       | 32.2       | 31.3       | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [#](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 100000       | 20.9       | 329.3       | 302.3       | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 1000       | 1.0       | 5.9       | 4.9       | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)          |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 10000       | 2.9       | 54.7       | 41.0       | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 32.2       | 454.9       | 411.6       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 1000       | 0.0       | 7.8       | 9.4       | (0.3, 0.5, 0.7, 0.4)           | (0.3, 0.5, 0.7, 0.4)           | (0.3, 0.5, 0.7, 0.4)          |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 10000       | 2.0       | 56.7       | 40.1       | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 20.5       | 431.3       | 395.3       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
| [#](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 7.8       | 3.1       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 2.5       | 0.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 28.5       | 7.8       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 2.9       | 2.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 4.9       | 1.0       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 39.1       | 8.0       | `null`           | `null`           | `null`          |