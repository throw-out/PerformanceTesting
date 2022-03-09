
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
| Editor          | False               |
| Date            | 2022-03-09 15:57:44               |
# 数据对照
* Static vs Instance | 	`静态函数 vs 实例函数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 20.5       | 3.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 1.0       | 8.8       | 9.1       | `null`           | `null`           | `null`          |
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 20.5       | 3.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 6.8       | 4.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 10.5       | 6.8       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 15.2       | 50.6       | 27.4       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 9.0       | 66.0       | 26.4       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 1000       | 0.0       | 3.9       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 2.9       | 0.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 20.5       | 3.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | ×       | ScriptCallCSharp       | 1000       | 0.0       | 1.9       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | ×       | ScriptCallCSharp       | 10000       | 0.0       | 1.4       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 1.0       | 8.8       | 9.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int);       | √       | ScriptCallCSharp       | 1000       | 0.0       | 2.0       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 2.0       | 1.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 6.8       | 4.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 1000       | 0.0       | 0.8       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 2.0       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 10.5       | 6.8       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 1000       | 0.0       | 3.0       | 1.0       | 1501500           | 1501500           | 1501500          |
| [:page_facing_up:](/)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 3.9       | 1.0       | 1.500183E+08           | 1.50015E+08           | 150015000          |
| [:page_facing_up:](/)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 22.7       | 7.3       | 1.500022E+10           | 1.500015E+10           | 15000150000          |
| [:page_facing_up:](/)       | float Payload();       | √       | ScriptCallCSharp       | 1000       | 0.0       | 2.9       | 0.0       | 6000           | 6000           | 6000          |
| [:page_facing_up:](/)       | float Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 2.9       | 0.0       | 60000           | 60000           | 60000          |
| [:page_facing_up:](/)       | float Payload();       | √       | ScriptCallCSharp       | 100000       | 1.0       | 8.1       | 4.9       | 600000           | 600000           | 600000          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 1000       | 2.1       | 7.2       | 3.0       | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 10000       | 1.0       | 7.8       | 2.9       | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 100000       | 9.8       | 44.6       | 21.9       | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 1000       | 1.0       | 2.0       | 1.0       | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 10000       | 1.0       | 12.3       | 2.9       | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 15.2       | 50.6       | 27.4       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 1000       | 1.0       | 6.8       | 2.0       | (0.3, 0.5, 0.7, 0.4)           | (0.3, 0.5, 0.7, 0.4)           | (0.3, 0.5, 0.7, 0.4)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 10000       | 1.4       | 7.9       | 2.2       | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 9.0       | 66.0       | 26.4       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
| [:page_facing_up:](/)       | payload(): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 2.0       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 2.9       | 1.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 28.8       | 4.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 2.0       | 0.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 3.9       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 47.2       | 6.4       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 2.0       | 0.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 7.5       | 0.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 84.0       | 6.8       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 1000       | `fail`       | 1.0       | 0.0       | `null`           | 1501500           | 1501500          |
| [:page_facing_up:](/)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 8.3       | 1.0       | `null`           | 1.500183E+08           | 1.500183E+08          |
| [:page_facing_up:](/)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 75.2       | 6.8       | `null`           | 1.500022E+10           | 1.500022E+10          |
| [:page_facing_up:](/)       | payload(): number;       | √       | CSharpCallScript       | 1000       | `fail`       | 1.0       | 1.0       | `null`           | 6000           | 6000          |
| [:page_facing_up:](/)       | payload(): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 5.9       | 0.5       | `null`           | 60000           | 60000          |
| [:page_facing_up:](/)       | payload(): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 46.4       | 7.8       | `null`           | 600000           | 600000          |
| [:page_facing_up:](/)       | payload(Transform): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 4.9       | 2.0       | `null`           | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)          |
| [:page_facing_up:](/)       | payload(Transform): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 25.1       | 22.5       | `null`           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [:page_facing_up:](/)       | payload(Transform): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 203.6       | 175.0       | `null`           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [:page_facing_up:](/)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 3.9       | 1.9       | `null`           | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)          |
| [:page_facing_up:](/)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 27.2       | 19.5       | `null`           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [:page_facing_up:](/)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 234.7       | 160.8       | `null`           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 1000       | `fail`       | 3.9       | 3.9       | `null`           | (0.3, 0.5, 0.7, 0.4)           | (0.3, 0.5, 0.7, 0.4)          |
| [:page_facing_up:](/)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 41.6       | 29.3       | `null`           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [:page_facing_up:](/)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 412.9       | 286.9       | `null`           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |