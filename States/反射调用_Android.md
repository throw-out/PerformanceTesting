
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
| Date            | 2022-03-31 14:55:04               |
# 数据对照
* Static vs Instance | 	`静态函数 vs 实例函数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 327.7       | 260.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 424.9       | 424.3       | `null`           | `null`           | `null`          |
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 327.7       | 260.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 411.4       | 311.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.1       | 569.9       | 435.5       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 51.0       | 1141.2       | 708.9       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 28.6       | 1087.6       | 743.1       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 10000       | 0.2       | 38.2       | 30.4       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 327.7       | 260.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | ×       | ScriptCallCSharp       | 10000       | 0.3       | 48.3       | 47.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 424.9       | 424.3       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int);       | √       | ScriptCallCSharp       | 10000       | 0.3       | 47.2       | 33.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.0       | 411.4       | 311.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.4       | 60.7       | 43.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.1       | 569.9       | 435.5       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.4       | 71.8       | 49.9       | 1.500183E+08           | 1.50015E+08           | 150015000          |
| [:page_facing_up:](/)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.6       | 604.5       | 481.7       | 1.500022E+10           | 1.500015E+10           | 15000150000          |
| [:page_facing_up:](/)       | float Payload();       | √       | ScriptCallCSharp       | 10000       | 0.5       | 38.9       | 29.3       | 60000           | 60000           | 60000          |
| [:page_facing_up:](/)       | float Payload();       | √       | ScriptCallCSharp       | 100000       | 0.5       | 362.1       | 292.9       | 600000           | 600000           | 600000          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 10000       | 5.9       | 117.7       | 66.8       | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 100000       | 32.1       | 870.0       | 495.6       | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 10000       | 6.8       | 124.1       | 72.6       | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 51.0       | 1141.2       | 708.9       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 10000       | 3.8       | 118.1       | 78.3       | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 28.6       | 1087.6       | 743.1       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
| [:page_facing_up:](/)       | payload(): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 17.3       | 12.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 62.0       | 36.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 15.4       | 4.7       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 128.3       | 37.4       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 29.0       | 5.3       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 272.2       | 42.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 35.7       | 6.1       | `null`           | 1.500183E+08           | 1.500183E+08          |
| [:page_facing_up:](/)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 335.8       | 53.0       | `null`           | 1.500022E+10           | 1.500022E+10          |
| [:page_facing_up:](/)       | payload(): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 12.4       | 5.3       | `null`           | 60000           | 60000          |
| [:page_facing_up:](/)       | payload(): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 118.4       | 43.9       | `null`           | 600000           | 600000          |
| [:page_facing_up:](/)       | payload(Transform): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 171.1       | 156.1       | `null`           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [:page_facing_up:](/)       | payload(Transform): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 1572.2       | 1536.2       | `null`           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [:page_facing_up:](/)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 188.4       | 161.4       | `null`           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [:page_facing_up:](/)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 1961.8       | 1588.1       | `null`           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 288.3       | 198.8       | `null`           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [:page_facing_up:](/)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 2776.5       | 1985.5       | `null`           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |