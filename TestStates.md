| Example   |  Method   | Call      | csTime    | jsTime    | luaTime   | csResult  | jsResult  | luaResult |
| :----     |  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |
| Example1       | static void Payload();       | 1000       | 0.0ms       | 4.9ms       | 5.9ms       | `null`       | `null`       | `null`       |
| Example1       | static void Payload();       | 10000       | 0.0ms       | 18.6ms       | 24.4ms       | `null`       | `null`       | `null`       |
| Example1       | static void Payload();       | 100000       | 0.0ms       | 182.7ms       | 238.4ms       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 1000       | 0.0ms       | 2.9ms       | `fail`       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 10000       | 0.0ms       | 19.5ms       | `fail`       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 100000       | 0.0ms       | 192.5ms       | `fail`       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 1000       | 0.0ms       | 5.9ms       | 4.9ms       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 10000       | 0.0ms       | 27.4ms       | 31.3ms       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 100000       | 0.0ms       | 252.1ms       | 279.2ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 1000       | 0.0ms       | 4.9ms       | 3.9ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 27.4ms       | 36.1ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 100000       | 1.0ms       | 291.5ms       | 354.4ms       | `null`       | `null`       | `null`       |
| Example5       | static void Payload(int param1, int param2, float param3);       | 1000       | 0.0ms       | 4.9ms       | 5.9ms       | 1501500       | 1003000       | 1003000       |
| Example5       | static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 33.0ms       | 37.2ms       | 1.500183E+08       | 1.0003E+08       | 100030000       |
| Example5       | static void Payload(int param1, int param2, float param3);       | 100000       | 2.0ms       | 321.6ms       | 369.2ms       | 1.500022E+10       | 1.00003E+10       | 10000300000       |