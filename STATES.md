| File      | Method    |  Static   | Call      | csDuration(ms)    | jsDuration(ms)    | luaDuration(ms)   | csResult  | jsResult  | luaResult |
| :----:    | :----     |  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |
| !(./pic/code_file.png)       | void Payload();       | √       | 1000       | 0.0       | 4.9       | 3.9       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload();       | √       | 10000       | 0.0       | 28.3       | 29.3       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload();       | √       | 100000       | 0.0       | 225.5       | 283.0       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload();       | ×       | 1000       | 0.0       | 3.9       | 6.8       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload();       | ×       | 10000       | 0.0       | 19.5       | 47.8       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload();       | ×       | 100000       | 1.0       | 229.4       | 400.7       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload(int);       | √       | 1000       | 0.0       | 3.9       | 3.9       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload(int);       | √       | 10000       | 0.0       | 23.4       | 30.3       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload(int);       | √       | 100000       | 0.0       | 240.6       | 298.7       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload(int, int, float);       | √       | 1000       | 0.0       | 3.9       | 4.9       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload(int, int, float);       | √       | 10000       | 1.0       | 31.2       | 34.2       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload(int, int, float);       | √       | 100000       | 1.0       | 331.9       | 380.7       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | float Payload(int, int, float);       | √       | 1000       | 0.0       | 4.9       | 6.9       | 1501500       | 1501500       | 1501500       |
| !(./pic/code_file.png)       | float Payload(int, int, float);       | √       | 10000       | 0.0       | 32.2       | 41.0       | 1.500183E+08       | 1.50015E+08       | 150015000       |
| !(./pic/code_file.png)       | float Payload(int, int, float);       | √       | 100000       | 2.0       | 359.2       | 427.1       | 1.500022E+10       | 1.500015E+10       | 15000150000       |
| !(./pic/code_file.png)       | float Payload();       | √       | 1000       | 0.0       | 2.9       | 3.9       | 6000       | 6000       | 6000       |
| !(./pic/code_file.png)       | float Payload();       | √       | 10000       | 0.0       | 23.4       | 35.1       | 60000       | 60000       | 60000       |
| !(./pic/code_file.png)       | float Payload();       | √       | 100000       | 1.0       | 229.4       | 319.2       | 600000       | 600000       | 600000       |
| !(./pic/code_file.png)       | Quaternion Payload(Transform);       | √       | 1000       | 1.0       | 20.5       | 11.7       | (0.3, 0.3, 0.3, -0.8)       | (0.3, 0.3, 0.3, -0.8)       | (0.3, 0.3, 0.3, -0.8)       |
| !(./pic/code_file.png)       | Quaternion Payload(Transform);       | √       | 10000       | 2.0       | 45.9       | 35.1       | (-0.1, -0.1, -0.1, 1.0)       | (-0.1, -0.1, -0.1, 1.0)       | (-0.1, -0.1, -0.1, 1.0)       |
| !(./pic/code_file.png)       | Quaternion Payload(Transform);       | √       | 100000       | 26.4       | 384.1       | 351.4       | (-0.5, -0.4, -0.4, 0.6)       | (-0.5, -0.4, -0.4, 0.6)       | (-0.5, -0.4, -0.4, 0.6)       |
| !(./pic/code_file.png)       | Quaternion Payload(Transform, float, float, float);       | √       | 1000       | 0.9       | 7.8       | 5.8       | (-0.4, -0.5, -0.7, -0.2)       | (-0.4, -0.5, -0.7, -0.2)       | (-0.4, -0.5, -0.7, -0.2)       |
| !(./pic/code_file.png)       | Quaternion Payload(Transform, float, float, float);       | √       | 10000       | 6.8       | 52.7       | 48.3       | (0.4, 0.5, 0.7, 0.0)       | (0.4, 0.5, 0.7, 0.0)       | (0.4, 0.5, 0.7, 0.0)       |
| !(./pic/code_file.png)       | Quaternion Payload(Transform, float, float, float);       | √       | 100000       | 33.2       | 538.8       | 548.5       | (-0.1, -0.1, -0.2, -1.0)       | (-0.1, -0.1, -0.2, -1.0)       | (-0.1, -0.1, -0.2, -1.0)       |