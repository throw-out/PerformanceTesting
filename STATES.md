
# System Environment
| Name            | Value             |
| :----           | :----:            |
| System          | Windows 10  (10.0.22000) 64bit               |
| Memory          | 32605MB             |
| CPU             | Intel(R) Core(TM) i7-9750H CPU @ 2.60GHz               |
| CPU-Count       | 12               |
| CPU-Frequency   | 2592               |
# Version
| Name            | Value             |
| :----           | :----:            |
| Unity           | 2019.4.28f1c1               |
| puerts          | 15               |
| xLua            | 105               |
# Group
* Static vs Instance

| File      | Method    | Static    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 10000       | 0.0       | 24.4       | 26.4       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 10000       | 0.0       | 20.5       | 32.2       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 100000       | 1.0       | 233.3       | 261.6       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 100000       | 1.0       | 224.5       | 340.2       | `null`           | `null`           | `null`           |
# All Data
| File      | Method    | Static    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 1000       | 0.0       | 4.9       | 4.9       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 10000       | 0.0       | 24.4       | 26.4       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 100000       | 1.0       | 233.3       | 261.6       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 1000       | 0.0       | 3.9       | 4.9       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 10000       | 0.0       | 20.5       | 32.2       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 100000       | 1.0       | 224.5       | 340.2       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 1000       | 0.0       | 2.9       | 2.9       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 10000       | 0.0       | 25.4       | 31.2       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 100000       | 0.0       | 243.6       | 298.7       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 1000       | 0.0       | 3.9       | 3.9       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 10000       | 0.0       | 29.3       | 31.3       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 100000       | 1.0       | 343.6       | 379.4       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 1000       | 0.0       | 4.9       | 5.9       | 1501500           | 1501500           | 1501500           |
| [#](./Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 10000       | 1.0       | 41.0       | 36.1       | 1.500183E+08           | 1.50015E+08           | 150015000           |
| [#](./Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 100000       | 2.0       | 339.4       | 381.1       | 1.500022E+10           | 1.500015E+10           | 15000150000           |
| [#](./Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 1000       | 0.0       | 3.0       | 2.9       | 6000           | 6000           | 6000           |
| [#](./Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 10000       | 0.0       | 26.4       | 27.3       | 60000           | 60000           | 60000           |
| [#](./Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 100000       | 1.0       | 235.2       | 318.2       | 600000           | 600000           | 600000           |
| [#](./Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 1000       | 2.0       | 19.6       | 11.7       | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)           |
| [#](./Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 10000       | 2.9       | 37.1       | 32.2       | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)           |
| [#](./Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 100000       | 24.4       | 350.4       | 320.9       | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)           |
| [#](./Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 1000       | 1.0       | 4.9       | 4.9       | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)           |
| [#](./Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 10000       | 3.0       | 61.5       | 45.5       | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)           |
| [#](./Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 100000       | 32.2       | 498.5       | 432.4       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           |