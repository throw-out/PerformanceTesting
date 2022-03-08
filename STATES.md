
# System Environment
* System: Windows 10  (10.0.22000) 64bit
* Memory: 32605MB
* CPU: Intel(R) Core(TM) i7-9750H CPU @ 2.60GHz
* CPU-Count: 12
* CPU-Frequency: 2592
* Graphics: Direct3D11
* Graphics-Name: NVIDIA GeForce GTX 1660 Ti
# All Data
| File      | Method    |  Static   | Call      | csDuration(ms)    | jsDuration(ms)    | luaDuration(ms)   | csResult  | jsResult  | luaResult |
| :----:    | :----     |  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 1000       | 0.0       | 4.8       | 5.9       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 10000       | 0.0       | 25.4       | 23.6       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 100000       | 1.0       | 205.5       | 249.9       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 1000       | 0.0       | 2.9       | 4.9       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 10000       | 0.0       | 22.4       | 40.0       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 100000       | 1.0       | 224.5       | 375.8       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 1000       | 0.0       | 3.9       | 3.9       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 10000       | 0.0       | 22.4       | 30.3       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 100000       | 1.0       | 276.2       | 320.6       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 1000       | 0.0       | 5.9       | 6.8       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 10000       | 0.0       | 47.8       | 58.1       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 100000       | 1.0       | 345.5       | 408.0       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 1000       | 0.0       | 4.9       | 5.9       | 1501500       | 1501500       | 1501500       |
| [#](./Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 10000       | 0.0       | 36.1       | 49.8       | 1.500183E+08       | 1.50015E+08       | 150015000       |
| [#](./Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 100000       | 2.0       | 365.0       | 502.3       | 1.500022E+10       | 1.500015E+10       | 15000150000       |
| [#](./Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 1000       | 0.0       | 2.9       | 9.8       | 6000       | 6000       | 6000       |
| [#](./Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 10000       | 0.0       | 20.1       | 39.0       | 60000       | 60000       | 60000       |
| [#](./Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 100000       | 1.0       | 254.8       | 442.2       | 600000       | 600000       | 600000       |
| [#](./Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 1000       | 2.0       | 27.3       | 15.6       | (0.3, 0.3, 0.3, -0.8)       | (0.3, 0.3, 0.3, -0.8)       | (0.3, 0.3, 0.3, -0.8)       |
| [#](./Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 10000       | 5.9       | 50.8       | 57.6       | (-0.1, -0.1, -0.1, 1.0)       | (-0.1, -0.1, -0.1, 1.0)       | (-0.1, -0.1, -0.1, 1.0)       |
| [#](./Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 100000       | 39.0       | 509.5       | 487.4       | (-0.5, -0.4, -0.4, 0.6)       | (-0.5, -0.4, -0.4, 0.6)       | (-0.5, -0.4, -0.4, 0.6)       |
| [#](./Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 1000       | 1.0       | 8.8       | 8.8       | (-0.4, -0.5, -0.7, -0.2)       | (-0.4, -0.5, -0.7, -0.2)       | (-0.4, -0.5, -0.7, -0.2)       |
| [#](./Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 10000       | 3.9       | 52.7       | 86.4       | (0.4, 0.5, 0.7, 0.0)       | (0.4, 0.5, 0.7, 0.0)       | (0.4, 0.5, 0.7, 0.0)       |
| [#](./Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 100000       | 46.8       | 630.5       | 588.5       | (-0.1, -0.1, -0.2, -1.0)       | (-0.1, -0.1, -0.2, -1.0)       | (-0.1, -0.1, -0.2, -1.0)       |