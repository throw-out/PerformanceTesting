
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
| Date            | 2022-03-31 14:52:45               |
# 数据对照
* Static vs Instance | 	`静态函数 vs 实例函数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 12.8       | 14.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 22.0       | 40.8       | `null`           | `null`           | `null`          |
* ParameterCompare | 	`无参数 vs 有参数`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 12.8       | 14.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.1       | 20.6       | 19.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.1       | 34.7       | 28.3       | `null`           | `null`           | `null`          |
* xyz vs Vector3 | 	`xyz传参 vs Vector3传参`

| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 50.4       | 499.2       | 134.4       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 28.5       | 761.0       | 166.8       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
# 所有数据
| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 10000       | 0.3       | 12.1       | 5.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | √       | ScriptCallCSharp       | 100000       | 0.0       | 12.8       | 14.9       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | ×       | ScriptCallCSharp       | 10000       | 0.3       | 7.6       | 8.4       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload();       | ×       | ScriptCallCSharp       | 100000       | 0.0       | 22.0       | 40.8       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int);       | √       | ScriptCallCSharp       | 10000       | 0.3       | 6.9       | 5.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int);       | √       | ScriptCallCSharp       | 100000       | 0.1       | 20.6       | 19.0       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.3       | 7.9       | 5.7       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | void Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.1       | 34.7       | 28.3       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 10000       | 0.4       | 11.8       | 6.5       | 1.500183E+08           | 1.50015E+08           | 150015000          |
| [:page_facing_up:](/)       | float Payload(int, int, float);       | √       | ScriptCallCSharp       | 100000       | 0.5       | 47.0       | 36.4       | 1.500022E+10           | 1.500015E+10           | 15000150000          |
| [:page_facing_up:](/)       | float Payload();       | √       | ScriptCallCSharp       | 10000       | 0.4       | 6.1       | 4.5       | 60000           | 60000           | 60000          |
| [:page_facing_up:](/)       | float Payload();       | √       | ScriptCallCSharp       | 100000       | 0.6       | 18.3       | 18.7       | 600000           | 600000           | 600000          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 10000       | 5.9       | 79.8       | 32.4       | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform);       | √       | ScriptCallCSharp       | 100000       | 32.3       | 431.2       | 93.2       | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 10000       | 5.8       | 62.6       | 16.0       | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, float, float, float);       | √       | ScriptCallCSharp       | 100000       | 50.4       | 499.2       | 134.4       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 10000       | 3.7       | 90.6       | 24.1       | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [:page_facing_up:](/)       | Quaternion Payload(Transform, Vector3);       | √       | ScriptCallCSharp       | 100000       | 28.5       | 761.0       | 166.8       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |
| [:page_facing_up:](/)       | payload(): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 17.1       | 10.2       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 62.4       | 34.7       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 15.4       | 4.6       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 126.0       | 37.4       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 28.2       | 5.1       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number,number,number): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 265.0       | 43.8       | `null`           | `null`           | `null`          |
| [:page_facing_up:](/)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 35.7       | 6.7       | `null`           | 1.500183E+08           | 1.500183E+08          |
| [:page_facing_up:](/)       | payload(number,number,number): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 335.4       | 53.3       | `null`           | 1.500022E+10           | 1.500022E+10          |
| [:page_facing_up:](/)       | payload(): number;       | √       | CSharpCallScript       | 10000       | `fail`       | 12.7       | 5.2       | `null`           | 60000           | 60000          |
| [:page_facing_up:](/)       | payload(): number;       | √       | CSharpCallScript       | 100000       | `fail`       | 110.3       | 42.7       | `null`           | 600000           | 600000          |
| [:page_facing_up:](/)       | payload(Transform): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 171.7       | 210.7       | `null`           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)          |
| [:page_facing_up:](/)       | payload(Transform): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 1606.7       | 2066.5       | `null`           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)          |
| [:page_facing_up:](/)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 225.1       | 218.3       | `null`           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)          |
| [:page_facing_up:](/)       | payload(Transform,float,float,float): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 2148.4       | 2170.4       | `null`           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)          |
| [:page_facing_up:](/)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 10000       | `fail`       | 322.5       | 252.6       | `null`           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)          |
| [:page_facing_up:](/)       | payload(Transform,Vector3): void;       | √       | CSharpCallScript       | 100000       | `fail`       | 3306.4       | 2493.3       | `null`           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)          |