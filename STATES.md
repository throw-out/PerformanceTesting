| File      | Method    |  Static   | Call      | csDuration(ms)    | jsDuration(ms)    | luaDuration(ms)   | csResult  | jsResult  | luaResult |
| :----:    | :----     |  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |
| !(./pic/code_file.png)       | void Payload();       | √       | 1000       | 0.0       | 2.9       | 3.9       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload();       | √       | 10000       | 0.0       | 18.5       | 30.3       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload();       | √       | 100000       | 1.0       | 229.4       | 263.5       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload();       | ×       | 1000       | 0.0       | 2.0       | 3.9       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload();       | ×       | 10000       | 1.0       | 21.5       | 44.9       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload();       | ×       | 100000       | 0.9       | 200.1       | 387.8       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload(int);       | √       | 1000       | 0.0       | 2.0       | 2.0       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload(int);       | √       | 10000       | 0.0       | 20.5       | 27.3       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload(int);       | √       | 100000       | 1.0       | 244.0       | 346.5       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload(int, int, float);       | √       | 1000       | 0.0       | 4.9       | 4.9       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload(int, int, float);       | √       | 10000       | 0.0       | 32.2       | 38.1       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | void Payload(int, int, float);       | √       | 100000       | 1.0       | 321.1       | 422.1       | `null`       | `null`       | `null`       |
| !(./pic/code_file.png)       | float Payload(int, int, float);       | √       | 1000       | 1.0       | 4.9       | 6.8       | 1501500       | 1501500       | 1501500       |
| !(./pic/code_file.png)       | float Payload(int, int, float);       | √       | 10000       | 1.0       | 41.0       | 45.9       | 1.500183E+08       | 1.50015E+08       | 150015000       |
| !(./pic/code_file.png)       | float Payload(int, int, float);       | √       | 100000       | 2.9       | 351.1       | 407.9       | 1.500022E+10       | 1.500015E+10       | 15000150000       |
| !(./pic/code_file.png)       | float Payload();       | √       | 1000       | 0.0       | 2.9       | 3.0       | 6000       | 6000       | 6000       |
| !(./pic/code_file.png)       | float Payload();       | √       | 10000       | 0.0       | 27.3       | 30.3       | 60000       | 60000       | 60000       |
| !(./pic/code_file.png)       | float Payload();       | √       | 100000       | 1.0       | 220.6       | 338.7       | 600000       | 600000       | 600000       |
| !(./pic/code_file.png)       | Quaternion Payload(Transform);       | √       | 1000       | 2.0       | 26.4       | 12.7       | (0.3, 0.3, 0.3, -0.8)       | (0.3, 0.3, 0.3, -0.8)       | (0.3, 0.3, 0.3, -0.8)       |
| !(./pic/code_file.png)       | Quaternion Payload(Transform);       | √       | 10000       | 3.9       | 39.0       | 40.0       | (-0.1, -0.1, -0.1, 1.0)       | (-0.1, -0.1, -0.1, 1.0)       | (-0.1, -0.1, -0.1, 1.0)       |
| !(./pic/code_file.png)       | Quaternion Payload(Transform);       | √       | 100000       | 25.4       | 388.0       | 400.4       | (-0.5, -0.4, -0.4, 0.6)       | (-0.5, -0.4, -0.4, 0.6)       | (-0.5, -0.4, -0.4, 0.6)       |
| !(./pic/code_file.png)       | Quaternion Payload(Transform, float, float, float);       | √       | 1000       | 0.0       | 7.8       | 5.9       | (-0.4, -0.5, -0.7, -0.2)       | (-0.4, -0.5, -0.7, -0.2)       | (-0.4, -0.5, -0.7, -0.2)       |
| !(./pic/code_file.png)       | Quaternion Payload(Transform, float, float, float);       | √       | 10000       | 3.9       | 56.2       | 48.8       | (0.4, 0.5, 0.7, 0.0)       | (0.4, 0.5, 0.7, 0.0)       | (0.4, 0.5, 0.7, 0.0)       |
| !(./pic/code_file.png)       | Quaternion Payload(Transform, float, float, float);       | √       | 100000       | 33.7       | 537.3       | 490.9       | (-0.1, -0.1, -0.2, -1.0)       | (-0.1, -0.1, -0.2, -1.0)       | (-0.1, -0.1, -0.2, -1.0)       |