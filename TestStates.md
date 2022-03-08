| Example   |  Method   | Call      | csTime    | jsTime    | luaTime   | csResult  | jsResult  | luaResult |
| :----     |  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |
| Example1       | static void Payload();       | 1000       | 0.0ms       | 4.9ms       | 5.9ms       | `null`       | `null`       | `null`       |
| Example1       | static void Payload();       | 10000       | 0.0ms       | 18.6ms       | 24.4ms       | `null`       | `null`       | `null`       |
| Example1       | static void Payload();       | 100000       | 0.0ms       | 184.2ms       | 243.0ms       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 1000       | 0.0ms       | 2.9ms       | `fail`       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 10000       | 0.0ms       | 18.1ms       | `fail`       | `null`       | `null`       | `null`       |
| Example2       | void Payload();       | 100000       | 1.0ms       | 193.5ms       | `fail`       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 1000       | 0.0ms       | 3.9ms       | 3.9ms       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 10000       | 0.0ms       | 25.4ms       | 27.4ms       | `null`       | `null`       | `null`       |
| Example3       | static void Payload(int param1);       | 100000       | 0.0ms       | 224.7ms       | 306.4ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 1000       | 0.0ms       | 3.9ms       | 4.9ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 30.3ms       | 34.2ms       | `null`       | `null`       | `null`       |
| Example4       | static void Payload(int param1, int param2, float param3);       | 100000       | 1.0ms       | 289.2ms       | 336.1ms       | `null`       | `null`       | `null`       |
| Example5       | static void Payload(int param1, int param2, float param3);       | 1000       | 0.0ms       | 6.8ms       | 6.8ms       | 1501500       | 1003000       | 1003000       |
| Example5       | static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 39.1ms       | 40.1ms       | 1.500183E+08       | 1.0003E+08       | 100030000       |
| Example5       | static void Payload(int param1, int param2, float param3);       | 100000       | 2.0ms       | 316.6ms       | 366.4ms       | 1.500022E+10       | 1.00003E+10       | 10000300000       |