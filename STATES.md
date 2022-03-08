
# System Environment
* System: Windows 10  (10.0.22000) 64bit
* Memory: 32605MB
* CPU: Intel(R) Core(TM) i7-9750H CPU @ 2.60GHz
* CPU-Count: 12
* CPU-Frequency: 2592
* Graphics: Direct3D11
* Graphics-Name: NVIDIA GeForce GTX 1660 Ti
# All Data| File      | Method    |  Static   | Call      | csDuration(ms)    | jsDuration(ms)    | luaDuration(ms)   | csResult  | jsResult  | luaResult |
| :----:    | :----     |  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 1000       | 1.0       | 4.9       | 3.9       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 10000       | 0.0       | 24.9       | 25.4       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 100000       | 1.0       | 200.4       | 280.1       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 1000       | 0.0       | 3.9       | 4.9       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 10000       | 0.0       | 22.4       | 38.1       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 100000       | 1.0       | 206.9       | 372.8       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 1000       | 0.0       | 10.7       | 3.9       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 10000       | 1.0       | 23.4       | 34.2       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 100000       | 1.0       | 240.1       | 297.7       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 1000       | 0.0       | 3.9       | 3.9       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 10000       | 0.0       | 35.1       | 34.2       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 100000       | 1.0       | 318.7       | 385.5       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 1000       | 0.0       | 6.8       | 6.8       | 1501500       | 1501500       | 1501500       |
| [#](./Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 10000       | 0.0       | 39.0       | 43.9       | 1.500183E+08       | 1.50015E+08       | 150015000       |
| [#](./Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 100000       | 2.0       | 373.8       | 466.5       | 1.500022E+10       | 1.500015E+10       | 15000150000       |
| [#](./Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 1000       | 0.0       | 2.0       | 2.9       | 6000       | 6000       | 6000       |
| [#](./Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 10000       | 0.0       | 18.5       | 29.3       | 60000       | 60000       | 60000       |
| [#](./Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 100000       | 1.0       | 232.3       | 303.5       | 600000       | 600000       | 600000       |
| [#](./Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 1000       | 1.0       | 21.5       | 12.7       | (0.3, 0.3, 0.3, -0.8)       | (0.3, 0.3, 0.3, -0.8)       | (0.3, 0.3, 0.3, -0.8)       |
| [#](./Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 10000       | 2.9       | 36.1       | 38.1       | (-0.1, -0.1, -0.1, 1.0)       | (-0.1, -0.1, -0.1, 1.0)       | (-0.1, -0.1, -0.1, 1.0)       |
| [#](./Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 100000       | 24.4       | 366.5       | 397.3       | (-0.5, -0.4, -0.4, 0.6)       | (-0.5, -0.4, -0.4, 0.6)       | (-0.5, -0.4, -0.4, 0.6)       |
| [#](./Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 1000       | 1.0       | 6.8       | 5.9       | (-0.4, -0.5, -0.7, -0.2)       | (-0.4, -0.5, -0.7, -0.2)       | (-0.4, -0.5, -0.7, -0.2)       |
| [#](./Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 10000       | 3.9       | 52.7       | 57.6       | (0.4, 0.5, 0.7, 0.0)       | (0.4, 0.5, 0.7, 0.0)       | (0.4, 0.5, 0.7, 0.0)       |
| [#](./Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 100000       | 35.1       | 560.8       | 522.2       | (-0.1, -0.1, -0.2, -1.0)       | (-0.1, -0.1, -0.2, -1.0)       | (-0.1, -0.1, -0.2, -1.0)       |