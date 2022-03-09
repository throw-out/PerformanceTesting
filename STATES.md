
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
| CPU-Count       | 12               |
| CPU-Frequency   | 3294               |
# 数据对照
* Static vs Instance`静态函数vs实例函数性能对比`

| File      | Method    | Static    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 100000       | 1.0       | 190.5       | 233.0       | `null`           | `null`           | `null`           |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 100000       | 1.0       | 256.6       | 345.6       | `null`           | `null`           | `null`           |
* xyz vs Vector3`xyz传参对比vector传参`

| File      | Method    | Static    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 100000       | 31.3       | 469.0       | 411.4       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | 100000       | 19.5       | 415.2       | 335.1       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           |
# 所有数据
| File      | Method    | Static    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 1000       | 0.0       | 3.9       | 3.9       | `null`           | `null`           | `null`           |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 10000       | 0.0       | 16.6       | 23.5       | `null`           | `null`           | `null`           |
| [#](/Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 100000       | 1.0       | 190.5       | 233.0       | `null`           | `null`           | `null`           |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 1000       | 0.5       | 3.9       | 5.9       | `null`           | `null`           | `null`           |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 10000       | 0.0       | 19.5       | 36.2       | `null`           | `null`           | `null`           |
| [#](/Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 100000       | 1.0       | 256.6       | 345.6       | `null`           | `null`           | `null`           |
| [#](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 1000       | 0.0       | 3.9       | 3.9       | `null`           | `null`           | `null`           |
| [#](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 10000       | 0.0       | 21.5       | 36.2       | `null`           | `null`           | `null`           |
| [#](/Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 100000       | 1.0       | 236.5       | 263.2       | `null`           | `null`           | `null`           |
| [#](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 1000       | 0.0       | 2.9       | 16.6       | `null`           | `null`           | `null`           |
| [#](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 10000       | 0.0       | 25.8       | 40.3       | `null`           | `null`           | `null`           |
| [#](/Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 100000       | 0.0       | 315.6       | 341.3       | `null`           | `null`           | `null`           |
| [#](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 1000       | 0.0       | 4.9       | 6.8       | 1501500           | 1501500           | 1501500           |
| [#](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 10000       | 0.0       | 43.0       | 34.2       | 1.500183E+08           | 1.50015E+08           | 150015000           |
| [#](/Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 100000       | 2.0       | 358.2       | 380.7       | 1.500022E+10           | 1.500015E+10           | 15000150000           |
| [#](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 1000       | 0.0       | 3.0       | 3.9       | 6000           | 6000           | 6000           |
| [#](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 10000       | 0.0       | 22.5       | 31.3       | 60000           | 60000           | 60000           |
| [#](/Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 100000       | 1.0       | 210.6       | 292.8       | 600000           | 600000           | 600000           |
| [#](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 1000       | 1.0       | 19.8       | 12.7       | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)           |
| [#](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 10000       | 2.0       | 36.9       | 33.2       | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)           |
| [#](/Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 100000       | 24.4       | 350.0       | 308.7       | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)           |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 1000       | 0.0       | 5.9       | 5.4       | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)           |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 10000       | 2.9       | 54.7       | 39.1       | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)           |
| [#](/Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 100000       | 31.3       | 469.0       | 411.4       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | 1000       | 1.0       | 17.6       | 5.9       | (0.3, 0.5, 0.7, 0.4)           | (0.3, 0.5, 0.7, 0.4)           | (0.3, 0.5, 0.7, 0.4)           |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | 10000       | 2.6       | 53.7       | 37.4       | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)           | (-0.3, -0.5, -0.8, 0.1)           |
| [#](/Assets/CScripts/Examples/Example9.cs)       | Quaternion Payload(Transform, Vector3);       | √       | 100000       | 19.5       | 415.2       | 335.1       | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           | (-0.3, -0.5, -0.8, -0.3)           |