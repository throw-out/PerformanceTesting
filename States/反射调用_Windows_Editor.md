
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
| Date            | 2022-03-31 14:05:12               |
# 数据对照
* Static vs Instance | 	`静态函数 vs 实例函数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 190.1       | 228.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 194.9       | 323.1       | `null`           | `null`           | `null`          |
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 190.1       | 228.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 216.0       | 248.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 279.1       | 309.1       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 31.0       | 429.1       | 376.1       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 20.0       | 395.1       | 373.1       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 26.2       | 23.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 190.1       | 228.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 10000       | 1.0       | 19.0       | 34.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 194.9       | 323.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 10000       | 1.0       | 22.0       | 25.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 216.0       | 248.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 27.0       | 31.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 279.1       | 309.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 1.0       | 32.0       | 36.0       | 1.500183E+08           | 1.50015E+08           | 150015000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 2.0       | 312.1       | 340.0       | 1.500022E+10           | 1.500015E+10           | 15000150000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 10000       | 1.0       | 19.0       | 25.0       | 60000           | 60000           | 60000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 100000       | 1.0       | 193.0       | 259.1       | 600000           | 600000           | 600000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 10000       | 3.0       | 52.0       | 40.0       | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 100000       | 21.0       | 313.1       | 290.1       | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 10000       | 4.0       | 51.0       | 38.5       | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 31.0       | 429.1       | 376.1       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 10000       | 2.0       | 41.7       | 42.0       | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 20.0       | 395.1       | 373.1       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 8.0       | 4.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 27.0       | 7.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 7.0       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 38.0       | 8.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example104.cs)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 7.0       | 2.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example104.cs)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 68.0       | 11.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example105.cs)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 8.0       | 1.0       | `null`           | 1.500183E+08           | 1.500183E+08          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example105.cs)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 78.0       | 13.0       | `null`           | 1.500022E+10           | 1.500022E+10          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example106.cs)       | payload(): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 6.0       | 2.0       | `null`           | 60000           | 60000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example106.cs)       | payload(): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 46.0       | 9.0       | `null`           | 600000           | 600000          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example107.cs)       | payload(Transform): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 55.0       | 72.0       | `null`           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example107.cs)       | payload(Transform): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 535.1       | 716.2       | `null`           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example108.cs)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 57.0       | 81.0       | `null`           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example108.cs)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 577.1       | 728.2       | `null`           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example109.cs)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 86.0       | 83.0       | `null`           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [:page_facing_up:](/Assets/CScripts/Examples/Example109.cs)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 754.2       | 844.2       | `null`           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |