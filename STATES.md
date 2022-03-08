| Example   |  Method   | Call      | csTime    | jsTime    | luaTime   | csResult  | jsResult  | luaResult |
| :----     |  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |
| Example1       | static void Payload();       | 1000       | 1.0ms       | 3.9ms       | 4.9ms       | `null`       | `null`       | `null`       |
| Example1       | static void Payload();       | 10000       | 0.0ms       | 17.6ms       | 24.0ms       | `null`       | `null`       | `null`       |
| Example1       | static void Payload();       | 100000       | 1.0ms       | 188.6ms       | 235.5ms       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 1000       | 0.0ms       | 2.9ms       | 4.9ms       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 10000       | 0.0ms       | 18.6ms       | 36.2ms       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 100000       | 0.0ms       | 192.1ms       | 358.6ms       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 1000       | 0.0ms       | 5.9ms       | 2.9ms       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 10000       | 0.0ms       | 21.5ms       | 27.4ms       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 100000       | 0.0ms       | 221.8ms       | 269.7ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 1000       | 1.0ms       | 5.1ms       | 3.9ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 27.9ms       | 32.2ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 100000       | 1.0ms       | 295.0ms       | 329.3ms       | `null`       | `null`       | `null`       |
| Example5       | static float Payload(int param1, int param2, float param3);       | 1000       | 1.0ms       | 3.9ms       | 7.4ms       | 1501500       | 1501500       | 1501500       |
| Example5       | static float Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 31.3ms       | 36.2ms       | 1.500183E+08       | 1.50015E+08       | 150015000       |
| Example5       | static float Payload(int param1, int param2, float param3);       | 100000       | 2.0ms       | 308.9ms       | 381.2ms       | 1.500022E+10       | 1.500015E+10       | 15000150000       |
| Example6       | static float Payload();       | 1000       | 1.0ms       | 2.9ms       | 3.9ms       | 6000       | 6000       | 6000       |
| Example6       | static float Payload();       | 10000       | 0.0ms       | 22.5ms       | 29.3ms       | 60000       | 60000       | 60000       |
| Example6       | static float Payload();       | 100000       | 1.0ms       | 193.5ms       | 271.3ms       | 600000       | 600000       | 600000       |
| Example7       | static void Payload();       | 1000       | 2.0ms       | 23.2ms       | 13.7ms       | (-0.4, -0.5, -0.7, -0.2)       | (-0.4, -0.5, -0.7, -0.2)       | (-0.4, -0.5, -0.7, -0.2)       |
| Example7       | static void Payload();       | 10000       | 4.9ms       | 48.1ms       | 45.9ms       | (0.4, 0.5, 0.7, 0.0)       | (0.4, 0.5, 0.7, 0.0)       | (0.4, 0.5, 0.7, 0.0)       |
| Example7       | static void Payload();       | 100000       | 34.7ms       | 445.6ms       | 433.6ms       | (-0.1, -0.1, -0.2, -1.0)       | (-0.1, -0.1, -0.2, -1.0)       | (-0.1, -0.1, -0.2, -1.0)       |
| Example8       | static float Payload();       | 1000       | 0.0ms       | 3.9ms       | 3.9ms       | `null`       | `null`       | `null`       |
| Example8       | static float Payload();       | 10000       | 4.9ms       | 23.5ms       | 29.3ms       | `null`       | `null`       | `null`       |
| Example8       | static float Payload();       | 100000       | 31.3ms       | 228.1ms       | 318.4ms       | `null`       | `null`       | `null`       |