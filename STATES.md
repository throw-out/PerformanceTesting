| Example   |  Method   | Call      | csTime    | jsTime    | luaTime   | csResult  | jsResult  | luaResult |
| :----     |  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |
| Example1       | static void Payload();       | 1000       | 0.0ms       | 4.9ms       | 4.9ms       | `null`       | `null`       | `null`       |
| Example1       | static void Payload();       | 10000       | 0.0ms       | 19.5ms       | 25.2ms       | `null`       | `null`       | `null`       |
| Example1       | static void Payload();       | 100000       | 1.0ms       | 179.8ms       | 269.7ms       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 1000       | 0.0ms       | 3.9ms       | 4.9ms       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 10000       | 0.0ms       | 23.5ms       | 40.1ms       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 100000       | 1.0ms       | 216.9ms       | 347.9ms       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 1000       | 0.0ms       | 4.9ms       | 4.9ms       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 10000       | 0.0ms       | 27.4ms       | 27.4ms       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 100000       | 1.0ms       | 234.5ms       | 278.5ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 1000       | 0.0ms       | 3.9ms       | 4.9ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 31.3ms       | 37.6ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 100000       | 1.0ms       | 302.9ms       | 326.4ms       | `null`       | `null`       | `null`       |
| Example5       | static void Payload(int param1, int param2, float param3);       | 1000       | 0.0ms       | 5.9ms       | 4.9ms       | 1501500       | 1003000       | 1003000       |
| Example5       | static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 31.3ms       | 36.2ms       | 1.500183E+08       | 1.0003E+08       | 100030000       |
| Example5       | static void Payload(int param1, int param2, float param3);       | 100000       | 2.0ms       | 334.2ms       | 396.7ms       | 1.500022E+10       | 1.00003E+10       | 10000300000       |