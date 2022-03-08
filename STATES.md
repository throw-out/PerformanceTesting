
# System Environment
| :----           | :----:            |
| System          | Windows 10  (10.0.22000) 64bit               |
| Memory          | 32605MB             |
| CPU             | Intel(R) Core(TM) i7-9750H CPU @ 2.60GHz               |
| CPU-Count       | 12               |
| CPU-Frequency   | 2592               |
# Version
| :----           | :----:            |
| Unity           | 2019.4.28f1c1               |
| puerts          | 15               |
| xLua            | 105               |
# All Data
| File      | Method    |  Static   | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |
| :----:    | :----     |  :----    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 1000       | 1.0       | 4.9       | 4.9       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 10000       | 0.0       | 26.4       | 22.4       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 100000       | 1.0       | 198.1       | 232.3       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 1000       | 0.0       | 2.9       | 11.7       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 10000       | 0.0       | 21.5       | 39.0       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 100000       | 1.0       | 235.2       | 386.0       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 1000       | 1.0       | 3.9       | 4.4       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 10000       | 0.0       | 21.5       | 32.2       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 100000       | 1.0       | 258.5       | 262.8       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 1000       | 0.0       | 3.9       | 3.9       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 10000       | 0.0       | 34.2       | 42.9       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 100000       | 1.0       | 329.9       | 383.6       | `null`           | `null`           | `null`           |
| [#](./Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 1000       | 0.0       | 3.9       | 6.8       | 1501500           | 1501500           | 1501500           |
| [#](./Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 10000       | 1.0       | 29.3       | 42.0       | 1.500183E+08           | 1.50015E+08           | 150015000           |
| [#](./Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 100000       | 2.9       | 346.4       | 438.6       | 1.500022E+10           | 1.500015E+10           | 15000150000           |
| [#](./Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 1000       | 0.0       | 2.0       | 2.9       | 6000           | 6000           | 6000           |
| [#](./Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 10000       | 0.0       | 17.6       | 26.4       | 60000           | 60000           | 60000           |
| [#](./Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 100000       | 0.9       | 233.2       | 317.7       | 600000           | 600000           | 600000           |
| [#](./Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 1000       | 1.0       | 17.6       | 10.7       | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)           | (0.3, 0.3, 0.3, -0.8)           |
| [#](./Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 10000       | 3.9       | 46.8       | 30.3       | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)           | (-0.1, -0.1, -0.1, 1.0)           |
| [#](./Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 100000       | 23.4       | 338.7       | 295.8       | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)           | (-0.5, -0.4, -0.4, 0.6)           |
| [#](./Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 1000       | 1.0       | 5.9       | 4.9       | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)           | (-0.4, -0.5, -0.7, -0.2)           |
| [#](./Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 10000       | 3.9       | 56.5       | 42.2       | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)           | (0.4, 0.5, 0.7, 0.0)           |
| [#](./Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 100000       | 31.2       | 481.9       | 442.6       | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           | (-0.1, -0.1, -0.2, -1.0)           |