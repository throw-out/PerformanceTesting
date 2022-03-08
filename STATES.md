| Example   |  Method   | Call      | csTime    | jsTime    | luaTime   | csResult  | jsResult  | luaResult |
| :----     |  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |
| void Payload();       | True       | 1000       | 0.0ms       | 3.9ms       | 5.9ms       | `null`       | `null`       | `null`       |
| void Payload();       | True       | 10000       | 0.0ms       | 16.6ms       | 26.4ms       | `null`       | `null`       | `null`       |
| void Payload();       | True       | 100000       | 1.0ms       | 183.9ms       | 241.8ms       | `null`       | `null`       | `null`       |
| void Payload();       | False       | 1000       | 0.0ms       | 3.9ms       | 4.9ms       | `null`       | `null`       | `null`       |
| void Payload();       | False       | 10000       | 0.0ms       | 18.6ms       | 34.2ms       | `null`       | `null`       | `null`       |
| void Payload();       | False       | 100000       | 1.0ms       | 205.6ms       | 356.2ms       | `null`       | `null`       | `null`       |
| void Payload(int);       | True       | 1000       | 0.0ms       | 4.9ms       | 5.1ms       | `null`       | `null`       | `null`       |
| void Payload(int);       | True       | 10000       | 0.0ms       | 22.5ms       | 31.3ms       | `null`       | `null`       | `null`       |
| void Payload(int);       | True       | 100000       | 2.0ms       | 244.5ms       | 266.8ms       | `null`       | `null`       | `null`       |
| void Payload(int, int, float);       | True       | 1000       | 0.0ms       | 2.9ms       | 3.9ms       | `null`       | `null`       | `null`       |
| void Payload(int, int, float);       | True       | 10000       | 0.0ms       | 33.2ms       | 32.2ms       | `null`       | `null`       | `null`       |
| void Payload(int, int, float);       | True       | 100000       | 1.0ms       | 293.1ms       | 336.6ms       | `null`       | `null`       | `null`       |
| float Payload(int, int, float);       | True       | 1000       | 0.0ms       | 4.9ms       | 5.9ms       | 1501500       | 1501500       | 1501500       |
| float Payload(int, int, float);       | True       | 10000       | 1.0ms       | 30.3ms       | 39.1ms       | 1.500183E+08       | 1.50015E+08       | 150015000       |
| float Payload(int, int, float);       | True       | 100000       | 2.0ms       | 331.0ms       | 371.3ms       | 1.500022E+10       | 1.500015E+10       | 15000150000       |
| float Payload();       | True       | 1000       | 0.0ms       | 2.9ms       | 2.9ms       | 6000       | 6000       | 6000       |
| float Payload();       | True       | 10000       | 1.0ms       | 19.5ms       | 26.4ms       | 60000       | 60000       | 60000       |
| float Payload();       | True       | 100000       | 1.0ms       | 184.7ms       | 302.4ms       | 600000       | 600000       | 600000       |
| Quaternion Payload(Transform);       | True       | 1000       | 2.9ms       | 23.2ms       | 13.7ms       | (0.3, 0.3, 0.3, -0.8)       | (0.3, 0.3, 0.3, -0.8)       | `null`       |
| Quaternion Payload(Transform);       | True       | 10000       | 2.0ms       | 36.2ms       | 34.2ms       | (-0.1, -0.1, -0.1, 1.0)       | (-0.1, -0.1, -0.1, 1.0)       | `null`       |
| Quaternion Payload(Transform);       | True       | 100000       | 21.2ms       | 347.0ms       | 317.6ms       | (-0.5, -0.4, -0.4, 0.6)       | (-0.5, -0.4, -0.4, 0.6)       | `null`       |
| Quaternion Payload(Transform, float, float, float);       | True       | 1000       | 2.0ms       | 5.9ms       | 6.8ms       | (-0.4, -0.5, -0.7, -0.2)       | (-0.4, -0.5, -0.7, -0.2)       | (-0.4, -0.5, -0.7, -0.2)       |
| Quaternion Payload(Transform, float, float, float);       | True       | 10000       | 2.9ms       | 46.9ms       | 43.0ms       | (0.4, 0.5, 0.7, 0.0)       | (0.4, 0.5, 0.7, 0.0)       | (0.4, 0.5, 0.7, 0.0)       |
| Quaternion Payload(Transform, float, float, float);       | True       | 100000       | 34.2ms       | 458.6ms       | 416.2ms       | (-0.1, -0.1, -0.2, -1.0)       | (-0.1, -0.1, -0.2, -1.0)       | (-0.1, -0.1, -0.2, -1.0)       |