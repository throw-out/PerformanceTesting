| Example   |  Method   | Call      | csTime    | jsTime    | luaTime   | csResult  | jsResult  | luaResult |
| :----     |  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |
| Example1       | static void Payload();       | 1000       | 0.0ms       | 6.8ms       | 4.9ms       | `null`       | `null`       | `null`       |
| Example1       | static void Payload();       | 10000       | 1.0ms       | 19.7ms       | 25.4ms       | `null`       | `null`       | `null`       |
| Example1       | static void Payload();       | 100000       | 0.0ms       | 197.4ms       | 267.7ms       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 1000       | 0.0ms       | 3.9ms       | `fail`       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 10000       | 0.0ms       | 25.4ms       | `fail`       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 100000       | 1.0ms       | 238.4ms       | `fail`       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 1000       | 1.0ms       | 3.9ms       | 4.9ms       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 10000       | 0.0ms       | 26.4ms       | 39.1ms       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 100000       | 1.0ms       | 268.8ms       | 332.6ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 1000       | 0.0ms       | 5.8ms       | 4.9ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 41.0ms       | 40.1ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 100000       | 1.0ms       | 371.3ms       | 372.4ms       | `null`       | `null`       | `null`       |
| Example5       | static void Payload(int param1, int param2, float param3);       | 1000       | 0.0ms       | 4.9ms       | 6.8ms       | 1501500       | 1003000       | 1003000       |
| Example5       | static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 34.3ms       | 38.1ms       | 1.500183E+08       | 1.0003E+08       | 100030000       |
| Example5       | static void Payload(int param1, int param2, float param3);       | 100000       | 2.0ms       | 343.6ms       | 372.2ms       | 1.500022E+10       | 1.00003E+10       | 10000300000       |