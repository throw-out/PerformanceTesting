
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
| Editor          | True               |
| Date            | 2022-03-09 15:37:35               |
# 数据对照
* Static vs Instance | 	`静态函数 vs 实例函数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 1.0       | 5.1       | 4.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 7.8       | 16.6       | `null`           | `null`           | `null`          |
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 1.0       | 5.1       | 4.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 10.7       | 6.8       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 1.0       | 16.6       | 6.8       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 35.2       | 164.2       | 47.4       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 23.5       | 220.8       | 54.7       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 1000       | 0.0       | 5.9       | 2.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 1.0       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 1.0       | 5.1       | 4.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 1000       | 0.0       | 3.9       | 3.3       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 10000       | 0.0       | 2.0       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 7.8       | 16.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 1000       | 0.0       | 4.9       | 3.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 2.9       | 1.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 10.7       | 6.8       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 1000       | 1.0       | 3.4       | 2.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 2.9       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 1.0       | 16.6       | 6.8       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 1000       | 1.0       | 3.9       | 2.0       | 1501500           | 1501500           | 1501500          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 3.9       | 1.0       | 1.500183E+08           | 1.50015E+08           | 150015000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 2.0       | 26.4       | 10.7       | 1.500022E+10           | 1.500015E+10           | 15000150000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 1000       | 1.0       | 3.9       | 2.0       | 6000           | 6000           | 6000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 1.0       | 1.0       | 60000           | 60000           | 60000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 100000       | 1.0       | 9.3       | 5.9       | 600000           | 600000           | 600000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 1000       | 2.0       | 25.4       | 20.0       | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 10000       | 2.9       | 17.6       | 5.9       | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 100000       | 22.5       | 134.8       | 37.1       | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 1000       | 0.0       | 4.9       | 2.9       | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 10000       | 4.9       | 19.5       | 6.7       | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 35.2       | 164.2       | 47.4       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 1000       | 2.0       | 8.8       | 5.9       | (0.3, 0.5, 0.7, 0.4)           | (0.3, 0.5, 0.7, 0.4)           | (0.3, 0.5, 0.7, 0.4)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 10000       | 2.9       | 30.3       | 6.8       | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 23.5       | 220.8       | 54.7       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 8.8       | 8.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 2.6       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 26.4       | 8.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 4.9       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 3.9       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 40.1       | 7.8       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example104.cs)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 2.9       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example104.cs)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 5.9       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example104.cs)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 55.4       | 12.7       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example105.cs)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 1000       | `fail`       | 2.9       | 1.0       | `null`           | 1501500           | 1501500          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example105.cs)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 8.0       | 1.0       | `null`           | 1.500183E+08           | 1.500183E+08          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example105.cs)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 83.1       | 14.7       | `null`           | 1.500022E+10           | 1.500022E+10          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example106.cs)       | payload(): number;       | √       | CSharpCallScript       | 1000       | `fail`       | 2.0       | 1.0       | `null`           | 6000           | 6000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example106.cs)       | payload(): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 5.9       | 1.0       | `null`           | 60000           | 60000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example106.cs)       | payload(): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 47.9       | 9.3       | `null`           | 600000           | 600000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example107.cs)       | payload(Transform): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 11.7       | 9.8       | `null`           | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example107.cs)       | payload(Transform): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 60.6       | 78.7       | `null`           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example107.cs)       | payload(Transform): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 597.2       | 773.4       | `null`           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example108.cs)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 8.1       | 9.8       | `null`           | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example108.cs)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 66.4       | 77.2       | `null`           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example108.cs)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 655.5       | 854.3       | `null`           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example109.cs)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 11.7       | 11.7       | `null`           | (0.3, 0.5, 0.7, 0.4)           | (0.3, 0.5, 0.7, 0.4)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example109.cs)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 93.8       | 98.7       | `null`           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example109.cs)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 848.4       | 930.5       | `null`           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |