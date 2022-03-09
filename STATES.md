
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
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 1.0       | 209.3       | 293.5       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 218.9       | 341.6       | `null`           | `null`           | `null`          |
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 1.0       | 209.3       | 293.5       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 1.0       | 229.6       | 258.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 308.8       | 350.4       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 31.3       | 478.3       | 410.4       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 19.5       | 426.0       | 404.1       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 1000       | 0.0       | 3.9       | 5.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 33.2       | 22.5       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 1.0       | 209.3       | 293.5       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 1000       | 0.0       | 6.4       | 8.8       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 10000       | 0.0       | 20.5       | 37.5       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 218.9       | 341.6       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 1000       | 0.0       | 6.8       | 4.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 20.9       | 28.0       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 1.0       | 229.6       | 258.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 1000       | 0.0       | 4.9       | 4.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 26.6       | 33.2       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 308.8       | 350.4       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 1000       | 1.0       | 6.8       | 6.8       | 1501500           | 1501500           | 1501500          |
| [#](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 44.5       | 32.6       | 1.500183E+08           | 1.50015E+08           | 150015000          |
| [#](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 2.0       | 329.6       | 367.5       | 1.500022E+10           | 1.500015E+10           | 15000150000          |
| [#](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 1000       | 0.0       | 2.9       | 3.4       | 6000           | 6000           | 6000          |
| [#](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 17.6       | 25.4       | 60000           | 60000           | 60000          |
| [#](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 100000       | 1.0       | 206.2       | 267.5       | 600000           | 600000           | 600000          |
| [#](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 1000       | 2.0       | 20.5       | 15.6       | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)          |
| [#](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 10000       | 2.0       | 44.0       | 30.3       | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [#](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 100000       | 21.5       | 356.1       | 315.0       | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 1000       | 1.1       | 6.8       | 6.8       | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)          |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 10000       | 3.9       | 47.9       | 49.7       | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 31.3       | 478.3       | 410.4       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 1000       | 0.5       | 8.2       | 9.8       | (0.3, 0.5, 0.7, 0.4)           | (0.3, 0.5, 0.7, 0.4)           | (0.3, 0.5, 0.7, 0.4)          |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 10000       | 2.0       | 41.0       | 39.3       | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 19.5       | 426.0       | 404.1       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
| [#](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 8.8       | 4.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 2.9       | 1.0       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 25.4       | 6.8       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 2.9       | 1.0       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 4.9       | 1.0       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 40.1       | 7.8       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example104.cs)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 2.0       | 1.0       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example104.cs)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 6.8       | 1.0       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example104.cs)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 57.7       | 8.8       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example105.cs)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 1000       | `fail`       | 2.9       | 1.0       | `null`           | 1501500           | 1501500          |
| [#](/Assets/CScripts/Examples/Example105.cs)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 7.8       | 1.0       | `null`           | 1.500183E+08           | 1.500183E+08          |
| [#](/Assets/CScripts/Examples/Example105.cs)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 72.3       | 11.1       | `null`           | 1.500022E+10           | 1.500022E+10          |
| [#](/Assets/CScripts/Examples/Example106.cs)       | payload(): number;       | √       | CSharpCallScript       | 1000       | `fail`       | 2.0       | 1.0       | `null`           | 6000           | 6000          |
| [#](/Assets/CScripts/Examples/Example106.cs)       | payload(): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 4.9       | 1.0       | `null`           | 60000           | 60000          |
| [#](/Assets/CScripts/Examples/Example106.cs)       | payload(): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 46.3       | 8.9       | `null`           | 600000           | 600000          |
| [#](/Assets/CScripts/Examples/Example107.cs)       | payload(Transform): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 12.7       | 8.8       | `null`           | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)          |
| [#](/Assets/CScripts/Examples/Example107.cs)       | payload(Transform): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 65.5       | 74.3       | `null`           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [#](/Assets/CScripts/Examples/Example107.cs)       | payload(Transform): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 574.7       | 743.4       | `null`           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [#](/Assets/CScripts/Examples/Example108.cs)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 20.0       | 8.4       | `null`           | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)          |
| [#](/Assets/CScripts/Examples/Example108.cs)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 69.4       | 90.9       | `null`           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [#](/Assets/CScripts/Examples/Example108.cs)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 633.7       | 1020.9       | `null`           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [#](/Assets/CScripts/Examples/Example109.cs)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 10.7       | 10.7       | `null`           | (0.3, 0.5, 0.7, 0.4)           | (0.3, 0.5, 0.7, 0.4)          |
| [#](/Assets/CScripts/Examples/Example109.cs)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 92.8       | 102.6       | `null`           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [#](/Assets/CScripts/Examples/Example109.cs)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 841.5       | 1015.3       | `null`           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |