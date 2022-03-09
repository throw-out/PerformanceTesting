
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
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 1000000       | 6.1       | 1839.9       | 2340.2       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 1000000       | 6.8       | 2067.5       | 3380.6       | `null`           | `null`           | `null`          |
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 1000000       | 6.1       | 1839.9       | 2340.2       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 1000000       | 5.9       | 2328.9       | 2629.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 1000000       | 6.8       | 3078.5       | 3315.3       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 1000000       | 322.3       | 4623.5       | 4121.7       | (0.2, 0.2, 0.3, -0.9)           | (0.2, 0.2, 0.3, -0.9)           | (0.2, 0.2, 0.3, -0.9)          |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 1000000       | 203.4       | 4195.5       | 4088.9       | (0.1, 0.1, 0.2, 1.0)           | (0.1, 0.1, 0.2, 1.0)           | (0.1, 0.1, 0.2, 1.0)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 1000       | 0.0       | 4.9       | 4.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 16.6       | 22.7       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 197.0       | 234.1       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | ScriptCallCSharp       | 1000000       | 6.1       | 1839.9       | 2340.2       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 1000       | 1.0       | 3.9       | 5.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 10000       | 0.0       | 31.9       | 32.4       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 1.0       | 208.1       | 333.8       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | ScriptCallCSharp       | 1000000       | 6.8       | 2067.5       | 3380.6       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 1000       | 0.0       | 4.9       | 3.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 40.1       | 25.8       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 1.0       | 231.3       | 265.4       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | ScriptCallCSharp       | 1000000       | 5.9       | 2328.9       | 2629.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 1000       | 0.0       | 3.9       | 3.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 28.3       | 31.4       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 1.0       | 317.6       | 339.0       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 1000000       | 6.8       | 3078.5       | 3315.3       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 1000       | 0.0       | 5.2       | 6.4       | 1501500           | 1501500           | 1501500          |
| [#](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 42.1       | 34.2       | 1.500183E+08           | 1.50015E+08           | 150015000          |
| [#](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 2.0       | 344.3       | 379.6       | 1.500022E+10           | 1.500015E+10           | 15000150000          |
| [#](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 1000000       | 19.5       | 3201.3       | 3752.6       | 1.500443E+12           | 1.500001E+12           | 1500001500000          |
| [#](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 1000       | 0.0       | 3.9       | 14.7       | 6000           | 6000           | 6000          |
| [#](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 18.1       | 26.5       | 60000           | 60000           | 60000          |
| [#](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 100000       | 1.0       | 202.4       | 281.2       | 600000           | 600000           | 600000          |
| [#](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | ScriptCallCSharp       | 1000000       | 9.8       | 2046.0       | 2756.6       | 6000000           | 6000000           | 6000000          |
| [#](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 1000       | 2.9       | 25.4       | 18.6       | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)          |
| [#](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 10000       | 2.0       | 47.3       | 31.3       | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [#](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 100000       | 22.5       | 339.0       | 307.5       | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [#](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 1000000       | 215.3       | 3369.9       | 3088.4       | (-0.3, -0.3, -0.3, -0.9)           | (-0.3, -0.3, -0.3, -0.9)           | (-0.3, -0.3, -0.3, -0.9)          |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 1000       | 1.0       | 5.9       | 5.4       | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)          |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 10000       | 3.9       | 55.7       | 39.9       | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 32.2       | 451.4       | 436.8       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 1000000       | 322.3       | 4623.5       | 4121.7       | (0.2, 0.2, 0.3, -0.9)           | (0.2, 0.2, 0.3, -0.9)           | (0.2, 0.2, 0.3, -0.9)          |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 1000       | 1.0       | 7.8       | 9.8       | (0.3, 0.5, 0.7, 0.4)           | (0.3, 0.5, 0.7, 0.4)           | (0.3, 0.5, 0.7, 0.4)          |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 10000       | 2.0       | 41.0       | 41.0       | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 21.5       | 401.1       | 399.8       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 1000000       | 203.4       | 4195.5       | 4088.9       | (0.1, 0.1, 0.2, 1.0)           | (0.1, 0.1, 0.2, 1.0)           | (0.1, 0.1, 0.2, 1.0)          |
| [#](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 7.3       | 4.9       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 2.9       | 1.0       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 26.0       | 7.8       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example101.cs)       | payload(): void;       | √       | CSharpCallScript       | 1000000       | `fail`       | 261.4       | 73.3       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 3.9       | 1.0       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 5.9       | 1.0       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 39.1       | 7.8       | `null`           | `null`           | `null`          |
| [#](/Assets/CScripts/Examples/Example103.cs)       | payload(number): void;       | √       | CSharpCallScript       | 1000000       | `fail`       | 350.7       | 71.9       | `null`           | `null`           | `null`          |