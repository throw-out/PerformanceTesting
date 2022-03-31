
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
| Date            | 2022-03-31 14:40:53               |
# 数据对照
* Static vs Instance | 	`静态函数 vs 实例函数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 17.9       | 4.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 8.0       | 10.9       | `null`           | `null`           | `null`          |
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 17.9       | 4.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 7.0       | 4.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 9.0       | 5.0       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 13.0       | 42.0       | 22.0       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 7.0       | 56.0       | 23.0       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 2.0       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 17.9       | 4.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | ×       | ScriptCallCSharp       | 10000       | 0.0       | 1.0       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 8.0       | 10.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 2.0       | 0.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 7.0       | 4.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 3.0       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 9.0       | 5.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 5.0       | 1.0       | 1.500183E+08           | 1.50015E+08           | 150015000          |
| [:page_facing_up:](/)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 1.0       | 16.0       | 6.0       | 1.500022E+10           | 1.500015E+10           | 15000150000          |
| [:page_facing_up:](/)       | float Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 2.0       | 1.0       | 60000           | 60000           | 60000          |
| [:page_facing_up:](/)       | float Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 7.0       | 4.0       | 600000           | 600000           | 600000          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 10000       | 5.1       | 8.8       | 4.0       | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 100000       | 8.0       | 37.0       | 18.0       | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 10000       | 2.0       | 8.7       | 3.0       | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 13.0       | 42.0       | 22.0       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 10000       | 1.0       | 9.6       | 4.0       | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 7.0       | 56.0       | 23.0       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
| [:page_facing_up:](/)       | payload(): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 5.0       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 25.0       | 4.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 4.0       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 34.0       | 5.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 6.0       | 1.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 48.0       | 5.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 8.0       | 1.0       | `null`           | 1.500183E+08           | 1.500183E+08          |
| [:page_facing_up:](/)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 64.0       | 7.0       | `null`           | 1.500022E+10           | 1.500022E+10          |
| [:page_facing_up:](/)       | payload(): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 5.0       | 1.0       | `null`           | 60000           | 60000          |
| [:page_facing_up:](/)       | payload(): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 40.0       | 7.0       | `null`           | 600000           | 600000          |
| [:page_facing_up:](/)       | payload(Transform): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 21.0       | 15.0       | `null`           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [:page_facing_up:](/)       | payload(Transform): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 171.0       | 143.0       | `null`           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [:page_facing_up:](/)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 23.0       | 16.0       | `null`           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [:page_facing_up:](/)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 211.0       | 149.0       | `null`           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 34.0       | 24.0       | `null`           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [:page_facing_up:](/)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 324.1       | 230.1       | `null`           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |