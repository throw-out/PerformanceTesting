
# System Environment
* System: 	Windows 10  (10.0.22000) 64bit
* Memory: 	32605MB
* CPU: 	Intel(R) Core(TM) i7-9750H CPU @ 2.60GHz
* CPU-Count: 	12
* CPU-Frequency: 	2592
* Graphics: 	NVIDIA GeForce GTX 1660 Ti
* Graphics-Type: 	Direct3D11
# All Data
| File      | Method    |  Static   | Call      | csDuration(ms)    | jsDuration(ms)    | luaDuration(ms)   | csResult  | jsResult  | luaResult |
| :----:    | :----     |  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 1000       | 0.0       | 4.9       | 4.9       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 10000       | 0.0       | 29.3       | 25.4       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example1.cs)       | void Payload();       | √       | 100000       | 1.0       | 220.1       | 273.4       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 1000       | 0.0       | 2.9       | 5.9       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 10000       | 0.0       | 21.5       | 43.0       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example2.cs)       | void Payload();       | ×       | 100000       | 1.0       | 228.3       | 440.7       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 1000       | 0.0       | 3.9       | 3.9       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 10000       | 0.0       | 28.3       | 34.2       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example3.cs)       | void Payload(int);       | √       | 100000       | 1.0       | 262.5       | 304.5       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 1000       | 0.0       | 3.9       | 3.9       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 10000       | 0.0       | 32.2       | 44.4       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example4.cs)       | void Payload(int, int, float);       | √       | 100000       | 0.0       | 365.5       | 387.6       | `null`       | `null`       | `null`       |
| [#](./Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 1000       | 1.0       | 5.9       | 7.8       | 1501500       | 1501500       | 1501500       |
| [#](./Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 10000       | 0.0       | 35.1       | 49.8       | 1.500183E+08       | 1.50015E+08       | 150015000       |
| [#](./Assets/CScripts/Examples/Example5.cs)       | float Payload(int, int, float);       | √       | 100000       | 2.0       | 367.0       | 440.2       | 1.500022E+10       | 1.500015E+10       | 15000150000       |
| [#](./Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 1000       | 0.0       | 3.9       | 3.0       | 6000       | 6000       | 6000       |
| [#](./Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 10000       | 0.0       | 24.4       | 30.3       | 60000       | 60000       | 60000       |
| [#](./Assets/CScripts/Examples/Example6.cs)       | float Payload();       | √       | 100000       | 1.0       | 220.4       | 318.4       | 600000       | 600000       | 600000       |
| [#](./Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 1000       | 1.0       | 23.4       | 13.2       | (0.3, 0.3, 0.3, -0.8)       | (0.3, 0.3, 0.3, -0.8)       | (0.3, 0.3, 0.3, -0.8)       |
| [#](./Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 10000       | 2.0       | 53.3       | 39.0       | (-0.1, -0.1, -0.1, 1.0)       | (-0.1, -0.1, -0.1, 1.0)       | (-0.1, -0.1, -0.1, 1.0)       |
| [#](./Assets/CScripts/Examples/Example7.cs)       | Quaternion Payload(Transform);       | √       | 100000       | 27.1       | 466.1       | 363.1       | (-0.5, -0.4, -0.4, 0.6)       | (-0.5, -0.4, -0.4, 0.6)       | (-0.5, -0.4, -0.4, 0.6)       |
| [#](./Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 1000       | 1.0       | 6.8       | 4.9       | (-0.4, -0.5, -0.7, -0.2)       | (-0.4, -0.5, -0.7, -0.2)       | (-0.4, -0.5, -0.7, -0.2)       |
| [#](./Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 10000       | 3.9       | 72.2       | 50.8       | (0.4, 0.5, 0.7, 0.0)       | (0.4, 0.5, 0.7, 0.0)       | (0.4, 0.5, 0.7, 0.0)       |
| [#](./Assets/CScripts/Examples/Example8.cs)       | Quaternion Payload(Transform, float, float, float);       | √       | 100000       | 36.1       | 593.1       | 546.4       | (-0.1, -0.1, -0.2, -1.0)       | (-0.1, -0.1, -0.2, -1.0)       | (-0.1, -0.1, -0.2, -1.0)       |