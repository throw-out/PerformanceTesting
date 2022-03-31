
# 软件版本
| Name            | Value             |
| :----           | :----:            |
| Unity           | 2019.4.28f1c1               |
| puerts          | 15               |
| xLua            | 105               |
# 系统环境
| Name            | Value             |
| :----           | :----:            |
| System          | Android OS 12 / API-31 (SKQ1.211006.001/V13.0.2.0.SJKCNXM)               |
| Memory          | 7613MB             |
| CPU             | ARM64 FP ASIMD AES               |
| CPU-Core        | 8               |
| CPU-Frequency   | 5.683GHz            |
| Editor          | False               |
| Date            | 2022-03-31 14:56:31               |
# 数据对照
* Static vs Instance | 	`静态函数 vs 实例函数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 9.0       | 13.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 20.9       | 35.4       | `null`           | `null`           | `null`          |
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 9.0       | 13.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 13.6       | 17.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 22.4       | 26.7       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 17.6       | 100.9       | 68.3       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 8.6       | 177.3       | 69.9       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 3.4       | 2.4       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 9.0       | 13.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | ×       | ScriptCallCSharp       | 10000       | 0.0       | 3.3       | 4.4       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 20.9       | 35.4       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 2.8       | 2.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 13.6       | 17.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 3.4       | 3.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 22.4       | 26.7       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.0       | 5.9       | 4.0       | 1.500183E+08           | 1.50015E+08           | 150015000          |
| [:page_facing_up:](/)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.1       | 29.5       | 27.5       | 1.500022E+10           | 1.500015E+10           | 15000150000          |
| [:page_facing_up:](/)       | float Payload();       | √       | ScriptCallCSharp       | 10000       | 0.0       | 2.1       | 1.8       | 60000           | 60000           | 60000          |
| [:page_facing_up:](/)       | float Payload();       | √       | ScriptCallCSharp       | 100000       | 0.1       | 11.0       | 16.1       | 600000           | 600000           | 600000          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 10000       | 0.9       | 16.7       | 10.5       | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 100000       | 8.6       | 88.6       | 49.3       | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 10000       | 1.7       | 12.8       | 6.9       | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 17.6       | 100.9       | 68.3       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 10000       | 1.0       | 18.3       | 9.0       | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 8.6       | 177.3       | 69.9       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
| [:page_facing_up:](/)       | payload(): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 6.1       | 3.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 45.8       | 27.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 11.9       | 3.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 108.9       | 29.3       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 24.7       | 3.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 241.4       | 30.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 28.1       | 3.8       | `null`           | 1.500183E+08           | 1.500183E+08          |
| [:page_facing_up:](/)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 271.9       | 36.4       | `null`           | 1.500022E+10           | 1.500022E+10          |
| [:page_facing_up:](/)       | payload(): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 8.8       | 3.5       | `null`           | 60000           | 60000          |
| [:page_facing_up:](/)       | payload(): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 76.4       | 32.9       | `null`           | 600000           | 600000          |
| [:page_facing_up:](/)       | payload(Transform): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 40.1       | 38.9       | `null`           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [:page_facing_up:](/)       | payload(Transform): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 370.9       | 390.6       | `null`           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [:page_facing_up:](/)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 61.0       | 40.3       | `null`           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [:page_facing_up:](/)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 576.1       | 399.0       | `null`           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 98.8       | 62.7       | `null`           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [:page_facing_up:](/)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 1027.9       | 639.2       | `null`           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |